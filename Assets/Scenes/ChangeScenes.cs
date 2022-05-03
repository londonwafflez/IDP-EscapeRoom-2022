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
    public void Storage_Room()
    {
        SceneManager.LoadScene("Storage Room");
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
}
