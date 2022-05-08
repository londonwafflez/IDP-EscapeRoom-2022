using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject obj;

    bool runTrigger = false;
    bool isActive = false;

    void Update()
    {
        if (runTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space))
            {
                obj.SetActive(!isActive); // false to hide, true to show
                isActive = !isActive;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        runTrigger = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        obj.SetActive(false);
        isActive = false;
        runTrigger = false;
    }
}