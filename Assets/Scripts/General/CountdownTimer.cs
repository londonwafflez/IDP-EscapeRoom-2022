using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float timeValue = 1800;
    public Text timerText;
    GameController2 dialogueScript;

    void Start() {
        dialogueScript = GameObject.Find("DialogueCanvas").GetComponent<GameController2>();
        DisplayTime(timeValue); 
    }

    void Update()
    {
        if (dialogueScript.isDialogueDone()) {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
            }
            DisplayTime(timeValue);   
        }
    }

    void DisplayTime(float timeTodisplay)
    {
        if(timeTodisplay < 0)
        {
            timeTodisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeTodisplay / 60);
        float seconds = Mathf.FloorToInt(timeTodisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SubtractHintTime() {
        timeValue -= 30;
    }
}
