using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBox : MonoBehaviour
{
    public Inventory inventory; 
    public string checkingFor;
    GameObject blackLightCode;
    // public Sprite newSprite;
    bool allowCheck = false;
    // SpriteRenderer spriteRenderer;

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

    void OnMouseEnter()
    {
        Debug.Log("Mouse entered");
        allowCheck = true;
    }

    public void checkItem(string spriteName)
    {
        Debug.Log("Checking " + spriteName);
        Debug.Log(allowCheck);
        if(spriteName == checkingFor && allowCheck)
        {
            inventory.used(spriteName);
            Debug.Log("found");
            blackLightCode.SetActive(true);
        }
        allowCheck = false;
    }
}
