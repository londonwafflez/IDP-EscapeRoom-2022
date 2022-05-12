using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whenDragged : MonoBehaviour
{
    public Inventory inventory;
    public DragBox dragBox;
    public int boxIdentity;
    Vector3 startPos;

    void Start()
    {
        startPos = gameObject.transform.position;
    }

    void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }

    void OnMouseUp()
    {
        dragBox.checkItem(inventory.whatItemDragged(boxIdentity));
        transform.position = startPos;
    }
}
