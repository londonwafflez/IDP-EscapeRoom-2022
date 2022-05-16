using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whenDragged : MonoBehaviour
{
    public Inventory inventory;
    public DragBox dragBox;
    public int boxIdentity;
    Vector3 startPos;
    Vector2 mousePosition;

    void Start()
    {
        startPos = gameObject.transform.position;
    }

    void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }

    void OnMouseUp()
    {
        dragBox.checkItem(inventory.whatItemDragged(boxIdentity), gameObject.transform.position);
        transform.position = startPos;
    }
}
