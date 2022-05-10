using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    // Start is called before the first frame update
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Start_Cut_Scene()
    {
        SceneManager.LoadScene("Start Cut Scene");
    }
    public void Scene3()
    {
        SceneManager.LoadScene("");
    }
    public void exitgame()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }

    /*void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.Space))
        {
            var nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                string nextSceneName = GetSceneNameByBuildIndex(nextSceneIndex);
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.Log("Next scene unavailable");
            }
        }
    }*/
}
