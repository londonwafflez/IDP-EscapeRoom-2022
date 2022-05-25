using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCellDoor : ChangeSprite
{
    Inventory inventory;
    GameObject closedCellDoor;
    GameObject openCellDoor;

    new void Start() {
        inventory = GameObject.Find("inventory").GetComponent<Inventory>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        closedCellDoor = GameObject.Find("CellDoor");
        openCellDoor = GameObject.Find("CellDoorOpen");
        openCellDoor.SetActive(false);
    }

    // protected void Update()
    // {
    //     if (runTrigger)
    //     {
    //         if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space))
    //         { 
    //             Debug.Log("F or space clicked");
    //             if(spriteRenderer.sprite == sprite0) {
    //                 spriteFunc(0);
    //             } else {
    //                 spriteFunc(1);
    //             }
    //         }
    //     }
    // }

    protected override void spriteFunc(int spriteToBe) 
    {
        if(inventory.getActiveItem() == "CellKey")
        {
            openCellDoor.SetActive(spriteToBe == 1);
            closedCellDoor.SetActive(spriteToBe == 0);
            inventory.used("CellKey");
        }
    }
}
