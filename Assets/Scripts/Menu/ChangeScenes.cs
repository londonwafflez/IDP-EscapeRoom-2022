using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeScenes : Trigger
{
    public Inventory inventory;
    public ClockPuzzle clockPuzzle;
    public Sprite openTrapDoor;
    public GameObject usernameInput;
    Hints m_hints;

    // Start is called before the first frame update
    public void Menu()
    {
        if (GameObject.Find("UICanvas") != null) Destroy(GameObject.Find("UICanvas"));
        SceneManager.LoadScene("Menu");
    }
    public void Cut_Scene()
    {
        SceneManager.LoadScene("Cut Scene");
    }
    public void StorageRoom()
    {
        SceneManager.LoadScene("Storage Room");
        m_hints = GameObject.Find("HintButton").GetComponent<Hints>();
    }
        public void Library()
    {
        SceneManager.LoadScene("Library");
    }
    public void LivingRoom()
    {
        SceneManager.LoadScene("Living Room");
    }
    public void exitgame()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }


    void OnTriggerExit2D()
    {
        runTrigger = false;
    }

    protected override void toRun()
    {
        if (SceneManager.GetActiveScene().name == "Storage Room")
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
            else if (inventory.getActiveItem() == "Key1")
            {
                m_hints.SetPrompt(6);
            }
            else if (clockPuzzle.appliedRotation - 90 == correctPos)
            {
                Debug.Log("Something else is missing");
            }
            else
            {
                Debug.Log("More needs to be done to unlock the trapdoor");
            }
        } else if (gameObject.name == "TrapDoorOpen")
        {
            // StorageRoom();
        } else {
            // LivingRoom();

            if (GameObject.Find("API") != null) GameObject.Find("API").GetComponent<SendToGoogle>().Send();
            LivingRoom();
        }
    }    

    public void checkUserGoStorageRoom() {
        if (usernameInput.GetComponent<TMP_InputField>().text != null) {
            StorageRoom();
        }
    }

            /*var nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                string nextSceneName = GetSceneNameByBuildIndex(nextSceneIndex);
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.Log("Next scene unavailable");
            }*/

}
