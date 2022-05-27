// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeActiveScene : Trigger
{
    Inventory inventory;
    public ClockPuzzle clockPuzzle;
    public Sprite openTrapDoor;
    Hints m_hints;
    static bool[] roomsGoneTo = new bool[3] {true, false, false};
    static string lastScene;
    static string activeScene = "StorageRoom";
    public GameObject[] ScenePrefabs = new GameObject[3];
    CountdownTimer cdTimer;
    public BoxCollider2D openDoorBoxCollider, openDoorTrigger;

    void ChangeScenes(int newScene)
    {
        if (!roomsGoneTo[newScene]) cdTimer.LogTime(newScene - 1);
        ScenePrefabs[newScene].SetActive(true); 
        lastScene = activeScene;
        roomsGoneTo[newScene] = true;
        activeScene = ScenePrefabs[newScene].name;
        if (lastScene != null) GameObject.Find(lastScene).SetActive(false);
    }

    void Start()
    {
        cdTimer = GameObject.Find("TimerText").GetComponent<CountdownTimer>();
        m_hints = GameObject.Find("HintButton").GetComponent<Hints>();
        inventory = GameObject.Find("inventory").GetComponent<Inventory>();
    }

    public void StorageRoom()
    {
        ChangeScenes(0);
    }
    public void Library()
    {
        ChangeScenes(1);
    }
    public void LivingRoom()
    {
        ChangeScenes(2);
    }

    public void Win() 
    {
        // if (GameObject.Find("API") != null) GameObject.Find("API").GetComponent<SendToGoogle>().Send();
    }


    void OnTriggerExit2D()
    {
        runTrigger = false;
    }

    protected override void toRun()
    {
        if (getScene() == "StorageRoom")
        {
            int correctPos = 0; // Correct time is 12; see clockpuzzle.cs for full conversion

            if (inventory.getActiveItem() == "Key1" && clockPuzzle.appliedRotation - 90 == correctPos)
            {
                m_hints.FinishedPuzzle();
                gameObject.GetComponent<SpriteRenderer>().sprite = openTrapDoor;
                openDoorBoxCollider.enabled = true;
                openDoorTrigger.enabled = true;
                gameObject.transform.localScale = new Vector3(4, 4, 1);
                // gameObject.transform.localScale.y ;
                inventory.used("Key1");
                // if (GameObject.Find("API") != null) GameObject.Find("API").GetComponent<SendToGoogle>().Send();
                Library();
            }
            else if (gameObject.GetComponent<SpriteRenderer>().name == "trapdooropen" || roomsGoneTo[1]) 
            {
                Library();
            } else {
                m_hints.SetPrompt(6);
            }
        } 
        else if (gameObject.name == "TrapDoorOpen")
        {
            StorageRoom();
        } else if (gameObject.name == "door") {
            if (activeScene == "LivingRoom")
                Library();
            else 
                LivingRoom();
        }
    }

    public string getScene()
    {
        return activeScene;
    }
    
    // public bool isNewScene()
    // {
    //     Array.Find(roomsGoneTo, element => element == activeScene);
    // }
}