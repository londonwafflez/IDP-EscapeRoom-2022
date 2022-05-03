using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject obj;

    void Update()
    {
        if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.Space))
        {
            obj.SetActive(false);
        }
    }
/*
    void OnCollisionStay(Collision collision)
    {
        if (Input.GetKey(KeyCode.F))
        {
            obj.SetActive(false); // false to hide, true to show
        }
    }*/
}
