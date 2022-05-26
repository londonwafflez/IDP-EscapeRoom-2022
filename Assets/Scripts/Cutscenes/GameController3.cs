using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController3 : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController1 bottomBar;
    public Behaviour dialogue_canvas;
    public SpriteRenderer bar;


    public void Started()
    {
        bottomBar.PlayScene(currentScene);
    }

    void Update()
    {
        if (dialogue_canvas.enabled == true)
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