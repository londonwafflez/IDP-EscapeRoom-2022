using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Awake() {
        if (SceneManager.GetActiveScene().name == "Library") {
            Destroy(this);
        }
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
