using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ClockHand : MonoBehaviour {
    public GameObject clockHand;
    Vector3 mouse_pos;
    Vector3 object_pos;
    float angle;

    void OnMouseDrag () {
        Debug.Log("Mouse Down");
        mouse_pos = Input.mousePosition;
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        Vector3 aVector = new Vector3(0, 0, angle);
        clockHand.transform.rotation = Quaternion.Euler(aVector);
        // transform.RotateAround(point, axis, Time.deltaTime * 10);
    }
}