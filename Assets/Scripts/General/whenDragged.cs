using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class whenDragged : MonoBehaviour
{
    public Inventory inventory;
    // public GameObject invBox;
    public int boxIdentity;
    Vector3 invBoxPos;
    Vector2 mousePosition;

    void Start()
    {
        invBoxPos = gameObject.transform.position;
    }

    void OnMouseDown() {
        inventory.clickActive(boxIdentity);
    }

//     void Awake() {
//         if (SceneManager.GetActiveScene().name == "Library") {
//             Destroy(this);
//         }
//     }

//     void OnMouseDrag()
//     {
//         mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//         transform.position = mousePosition;
//     }

//     void OnMouseUp()
//     {
//         dragBox.checkItem(inventory.whatItemDragged(boxIdentity), gameObject.transform.position);
//         transform.position = invBoxPos;
//     }
}
