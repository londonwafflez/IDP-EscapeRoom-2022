using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBox : MonoBehaviour
{
    public Inventory inventory; 
    public string checkingFor;
    GameObject blackLightCode;
    // public Sprite newSprite;
    // bool allowCheck = false;
    // SpriteRenderer spriteRenderer;
    public Vector2 topLeftBound;
    public Vector2 botRightBound; 

    // Start is called before the first frame update
    void Start()
    {
        // spriteRenderer = GetComponent.<SpriteRenderer>();
        blackLightCode = GameObject.Find("blacklightcode");
        blackLightCode.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void checkItem(string spriteName, Vector2 spriteLoc)
    {
        Debug.Log("Checking " + spriteName);
        if ((spriteLoc.x > topLeftBound.x && spriteLoc.x < botRightBound.x) && (spriteLoc.y > botRightBound.y && spriteLoc.y < topLeftBound.y))
        {
            Debug.Log("Correct area");
            if(spriteName == checkingFor)
            {
                inventory.used(spriteName);
                Debug.Log("found");
                blackLightCode.SetActive(true);
            }
        }
        // allowCheck = false; 
    }
}
