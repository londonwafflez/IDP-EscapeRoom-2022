using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject obj;
    bool isActive = false;

    IEnumerator Wait() 
    {

        yield return 24;
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.Space))
        {
            obj.SetActive(!isActive); // false to hide, true to show
            isActive = !isActive;
            StartCoroutine(Wait());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        obj.SetActive(false);
        isActive = false;

    }
}