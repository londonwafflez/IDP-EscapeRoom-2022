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
    public GameObject ghost;
    bool dialogueDone;

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
                    dialogueDone = true;

                    // Move ghost out of screen and turn it to face correct way as leaving
                    // ghost.transform.position = new Vector3()
                    // ghost.GetComponent<SpriteRenderer>()

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

    public bool isDialogueDone() {
        return dialogueDone; 
    }
}