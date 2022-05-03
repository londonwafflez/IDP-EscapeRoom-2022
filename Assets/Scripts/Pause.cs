using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {

        }
    }

    void OnMouseDown()
    {
        //GameObject's Collider is now a trigger Collider when the GameObject is clicked. It now acts as a trigger
        //m_ObjectCollider.isTrigger = true;
        //Output to console the GameObject’s trigger state
        //Debug.Log("Trigger On : " + m_ObjectCollider.isTrigger);
    }
}
