using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController2 : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public Behaviour dialogue_canvas;
    public SpriteRenderer bar;


    void Start()
    {
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