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


    public void Started()
    {
        bar.enabled = true;
        bottomBar.PlayScene(currentScene);
    }

    void Update()
    {

        if  (Input.GetKeyDown(KeyCode.Space))
        {
            if(bottomBar.IsCompleted())
            {
                if(bottomBar.IsLastSentence())
                {
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