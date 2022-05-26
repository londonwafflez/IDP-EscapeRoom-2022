using System.Text.RegularExpressions;
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
    public GameObject usernameInput, feedback;
    string username;

    // Start is called before the first frame update
    public void Menu()
    {
        if (GameObject.Find("UICanvas") != null) Destroy(GameObject.Find("UICanvas"));
        SceneManager.LoadScene("Menu");
    }
    public void Username()
    {
        SceneManager.LoadScene("Username");
    }
    public void StorageRoom()
    {
        SceneManager.LoadScene("Gameplay");
    }
       public void FirstScene()
    {
        SceneManager.LoadScene("1Home");
    }
    // public void LivingRoom()
    // {
    //     SceneManager.LoadScene("Living Room");
    // }
    public void exitgame()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }


    void OnTriggerExit2D()
    {
        runTrigger = false;
    }

    /*protected override void toRun()
    {
        if (SceneManager.GetActiveScene().name == "Storage Room")
        {
            int correctPos = 0; // Correct time is 12; see clockpuzzle.cs for full conversion

            if (inventory.getActiveItem() == "Key1" && clockPuzzle.appliedRotation - 90 == correctPos)
            {
                GameObject.Find("HintButton").GetComponent<Hints>().FinishedPuzzle();
                gameObject.GetComponent<SpriteRenderer>().sprite = openTrapDoor;
                inventory.used("Key1");
                if (GameObject.Find("API") != null) GameObject.Find("API").GetComponent<SendToGoogle>().Send();
                Library();
            }
            else if (inventory.getActiveItem() == "Key1")
            {
                Debug.Log("Something else is missing");
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
    }    */

    public void checkUserGoFirstCutScene() {
        if (Regex.IsMatch(usernameInput.GetComponent<TMP_InputField>().text, "^[a-zA-z]") && usernameInput.GetComponent<TMP_InputField>().text.Split().Length < 20) {
            username = usernameInput.GetComponent<TMP_InputField>().text;
            FirstScene();
        } 
        feedback.SetActive(true);
    }

    public void checkUserGoCutScene() {
        if (!Regex.IsMatch(usernameInput.GetComponent<TMP_InputField>().text, @"^[A-Za-z\s]*$")  && usernameInput.GetComponent<TMP_InputField>().text.Split().Length < 4) {
            Username();
        }
        feedback.SetActive(true);
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
    public string GetUsername() {
        return username;
    }
}
