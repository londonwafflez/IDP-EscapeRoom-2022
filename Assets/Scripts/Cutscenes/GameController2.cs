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
        if  (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.F))
        {
            if(bottomBar.IsCompleted())
            {
                if(bottomBar.IsLastSentence())
                {
                    dialogueDone = true;

                    // Move ghost out of screen and turn it to face correct way as leaving

                    if (ghost != null) {
                        ghost.GetComponent<SpriteRenderer>().flipX = true;
                        ghost.GetComponent<Rigidbody>().velocity = new Vector2(-100, 0);
                    }
                    // ghost.transform.rotation = new Quaternion(0, 0, 30, 0);

                    // for (int i = 0; i < 30; i++)
                    // {
                        
                    // }
/*
                    for (int i = 0; i < 100; i++)
                    {

                        ghost.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, i*2), Vector3.up);
                    }*/

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