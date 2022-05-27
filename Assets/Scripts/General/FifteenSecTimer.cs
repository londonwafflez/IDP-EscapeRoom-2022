using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FifteenSecTimer : MonoBehaviour
{
    public float timeValue = 16;
    public Text timeText;

    void Update()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue =+16;
        }

        DisplayTime(timeValue);
    }
    void DisplayTime(float timeTodisplay)
    {
        if(timeTodisplay < 0)
        {
            timeTodisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeTodisplay / 60);
        float seconds = Mathf.FloorToInt(timeTodisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
