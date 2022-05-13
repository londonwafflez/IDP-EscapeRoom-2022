using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCellDoor : ChangeSprite
{
    GameObject closedCellDoor;
    GameObject openCellDoor;

    new void Start() {
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

    new void spriteFunc(int spriteToBe) 
    {
        Debug.Log("spriteFunc in ChangeCellDoor.cs run");
        openCellDoor.SetActive(spriteToBe == 0);
        closedCellDoor.SetActive(spriteToBe == 1);
    }
}
