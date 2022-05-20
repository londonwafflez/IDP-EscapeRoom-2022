using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBox : MonoBehaviour
{
    protected Inventory m_inventory;
    public string checkingFor;
    public GameObject revealedObj;
    // public Sprite newSprite;
    // bool allowCheck = false;
    // SpriteRenderer spriteRenderer;
    public Vector2 topLeftBound;
    public Vector2 botRightBound;

    // Start is called before the first frame update
    void Start()
    {
        m_inventory = GameObject.Find("inventory").GetComponent<Inventory>();
        revealedObj.SetActive(false);
    }

    // void OnMouseDrag()
    // // void OnMouseEnter()
    // {
    //     Debug.Log("Mouse entered");
    //     allowCheck = true;
    // }

    // void OnMouseExit() {
    //     Debug.Log("Mouse exit");
    //     allowCheck = false;
    // }

    public virtual void checkItem(string spriteName, Vector2 spriteLoc)
    {
        Debug.Log("Checking " + spriteName);
        if ((spriteLoc.x > topLeftBound.x && spriteLoc.x < botRightBound.x) && (spriteLoc.y > botRightBound.y && spriteLoc.y < topLeftBound.y))
        {
            Debug.Log("Correct area");
            if (spriteName == checkingFor)
            {
                m_inventory.used(checkingFor);
                Debug.Log("found");
                revealedObj.SetActive(true);
            }
        }
        // allowCheck = false; 
    }
}
