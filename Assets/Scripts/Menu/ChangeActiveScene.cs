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
    public GameObject usernameInput;
    Hints m_hints;
    bool[] roomsGoneTo = new bool[3] {true, false, false};
    string activeScene = "StorageRoom";


    void ChangeScenes(string newScene)
    {
        if (GameObject.Find("API") != null) GameObject.Find("API").GetComponent<SendToGoogle>().Send();
        GameObject.Find(activeScene).SetActive(false);
        GameObject.Find(newScene).SetActive(true);
        activeScene = newScene;
    }

    void Start()
    {
        m_hints = GameObject.Find("HintButton").GetComponent<Hints>();
        inventory = GameObject.Find("inventory").GetComponent<Inventory>();
    }

    public void StorageRoom()
    {
        ChangeScenes("StorageRoom");
    }
    public void Library()
    {
        ChangeScenes("Library");
    }
    public void LivingRoom()
    {
        ChangeScenes("LivingRoom");
    }


    void OnTriggerExit2D()
    {
        runTrigger = false;
    }

    protected override void toRun()
    {
        if (activeScene == "StorageRoom")
        {

            int correctPos = 0; // Correct time is 12; see clockpuzzle.cs for full conversion

            if (inventory.getActiveItem() == "Key1" && clockPuzzle.appliedRotation - 90 == correctPos)
            {
                m_hints.FinishedPuzzle();
                gameObject.GetComponent<SpriteRenderer>().sprite = openTrapDoor;
                inventory.used("Key1");
                if (GameObject.Find("API") != null) GameObject.Find("API").GetComponent<SendToGoogle>().Send();
                Library();
            }
            else if (gameObject.name == "TrapDoorOpen")
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
}
