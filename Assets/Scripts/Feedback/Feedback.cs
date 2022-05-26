using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Feedback : MonoBehaviour
{
    public void HeartRateBefore()
    {
        SceneManager.LoadScene("HeartRateBefore");
    }
     public void Question1()
    {
        SceneManager.LoadScene("Question1");
    }
     public void Question2()
    {
        SceneManager.LoadScene("Question2");
    }
     public void Question3()
    {
        SceneManager.LoadScene("Question3");
    }
     public void Question4()
    {
        SceneManager.LoadScene("Question4");
    }
     public void Question5()
    {
        SceneManager.LoadScene("Question5");
    }
     public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
     public void GoToMenu()
    {
        SceneManager.LoadScene("GoToMenu");
    }
    
}
