using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController3 : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public Behaviour dialogue_canvas;
    public SpriteRenderer bar;
    bool isDone = false;



    void Update()
    {

        if (isDone == false)
        {
            if (bar.enabled == true && dialogue_canvas.enabled == true)
            {
                bottomBar.PlayScene(currentScene);
                isDone = true;
            }
        }

        if (isDone == true)
        {

            if  (Input.GetKeyDown(KeyCode.Space))
            {
                if(bottomBar.IsCompleted())
                {
                    if(bottomBar.IsLastSentence())
                    {

                        dialogue_canvas.enabled = false;
                        bar.enabled = false;               
                    }
                    else
                    {
                    bottomBar.PlayNextSentence();
                    }

                }
            }
        }
    }
}