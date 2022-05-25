using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController3 : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController1 bottomBar;
    public SpriteRenderer bbar;
    public Behaviour dialogue;


    public void enabled()
    {
        bbar.enabled = true; 
        dialogue.enabled = true;
        bottomBar.PlayScene(currentScene);

    }

    void Update()
    {

        if (bbar.enabled == true)
        {
            if  (Input.GetKeyDown(KeyCode.Space))
            {
                if(bottomBar.IsCompleted())
                {
                    if(bottomBar.IsLastSentence())
                    {

                        bbar.enabled = false; 
                        dialogue.enabled = false;           
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