using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : Trigger
{
    public Inventory inventory;
    public ClockPuzzle clockPuzzle;
    public Sprite openTrapDoor;

    // Start is called before the first frame update
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Start_Cut_Scene()
    {
        SceneManager.LoadScene("Start Cut Scene");
    }
    public void StoreRoom()
    {
        SceneManager.LoadScene("Store Room");
    }
        public void Library()
    {
        SceneManager.LoadScene("Library");
    }
    public void LivingRoom()
    {
        SceneManager.LoadScene("LivingRoom");
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
                gameObject.GetComponent<SpriteRenderer>().sprite = openTrapDoor;
                inventory.used("Key1");
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
            StoreRoom();
        } else {
            LivingRoom();
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
