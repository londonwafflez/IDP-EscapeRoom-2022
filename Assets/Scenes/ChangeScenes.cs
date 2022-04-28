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
    public void Main()
    {
        SceneManager.LoadScene("Main");
    }
    public void Scene3()
    {
        SceneManager.LoadScene("Scene3");
    }
    public void exitgame()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }
}
