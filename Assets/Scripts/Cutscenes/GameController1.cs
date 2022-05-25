using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController1 : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public string nextScene;
    public Behaviour dialogue_canvas;


    void Start()
    {
        bottomBar.PlayScene(currentScene);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space))
        {
            if(bottomBar.IsCompleted())
            {
                if(bottomBar.IsLastSentence())
                {

                    dialogue_canvas.enabled = false;
                    SceneManager.LoadScene(nextScene);
                    
                }
                else
                {
                bottomBar.PlayNextSentence();
                }

            }



        }



    }

    




}