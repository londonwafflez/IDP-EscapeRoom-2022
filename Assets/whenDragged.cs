using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whenDragged : MonoBehaviour
{
    public Inventory inventory;

    void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }
/*
    void OnMouse()
    {

    }*/
}
