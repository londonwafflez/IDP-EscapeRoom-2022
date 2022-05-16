using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPuzzle : MonoBehaviour
{
    public GameObject clockPuzzle;
    public GameObject clockHand;
    public GameObject clockDoor;
    public GameObject trigger;
    public GameObject insideClock;
    float offset = -90;
    float firstThreshold = 0;
    float interval = 30;
    public float appliedRotation;
    int curHour;
    int waitTime = 35;
    bool wait;

    void Start()
    {
/*        clockPuzzle.SetActive(true);
        clockHand = GameObject.Find("ClockHand");
        clockDoor = GameObject.Find("ClockDoor");
        trigger = GameObject.Find("TriggerClockFace");
        insideClock = GameObject.Find("InsideClock");
        clockPuzzle.SetActive(false);
        insideClock.SetActive(false);*/
        string dt = DateTime.Now.ToString("hh");
        curHour = int.Parse(dt);
    }

    void Update()
    {
        if (wait)
        {
            waitTime--;
            if (waitTime == 0)
            {
                clockPuzzle.SetActive(false);
                clockDoor.SetActive(false);
                // trigger.SetActive(false);
                insideClock.SetActive(true);
                wait = false;
            }
        }
    }
    
    float RoundToNearestTime(float rotation)
    {
        bool isPos = true;
        if (rotation < 0)
        {
            isPos = false;
            rotation *= -1;
        }

        double output =
            Math.Round((rotation - firstThreshold) / interval)
                * interval + firstThreshold;

        if (!isPos)
        {
            output *= -1;
        }
        return (float)output;
    }

    void OnMouseDrag()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        appliedRotation = RoundToNearestTime(rotation_z);
        clockHand.transform.rotation = Quaternion.Euler(0f, 0f, appliedRotation + offset);
    }

    void OnMouseUp()
    {
        int correctPos;
        if (curHour < 10)
        {
            correctPos = curHour * -30;
        }
        else
        {
            correctPos = (12 - curHour) * 30;
        }

        if (appliedRotation - 90 == correctPos)
        {
            wait = true;
        }
    }
}