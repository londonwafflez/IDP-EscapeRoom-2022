using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookDragBox : DragBox
{
    void Start()
    {
        m_inventory = GameObject.Find("inventory").GetComponent<Inventory>();
    }
    
    public override void checkItem(string spriteName, Vector2 spriteLoc)
    {
        for (int i = 0; i < 3; i++) {
            Debug.Log("Checking " + spriteName);
            if ((spriteLoc.x > topLeftBound.x && spriteLoc.x < botRightBound.x) && (spriteLoc.y > botRightBound.y && spriteLoc.y < topLeftBound.y))
            {
                Debug.Log("Correct area");
                if (spriteName[4] == i)
                {
                    m_inventory.used("book" + i + "front");
                    Debug.Log("found");
                    GameObject.Find("book" + i + "side").SetActive(true);
                    break;
                }
            }
        }
    }
}
