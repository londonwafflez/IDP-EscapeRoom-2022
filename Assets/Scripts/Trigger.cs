using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject obj;

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.Space))
        {
            obj.SetActive(true); // false to hide, true to show
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        obj.SetActive(false);
    }
}