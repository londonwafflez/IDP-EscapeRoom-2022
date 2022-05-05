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
            obj.SetActive(false); // false to hide, true to show
        }
    }
}