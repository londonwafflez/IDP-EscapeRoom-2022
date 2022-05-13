using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRug : ChangeSprite
{
    public Sprite revealedRug;
    public Sprite normalRug;
    GameObject codeTranslator;

    new void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        codeTranslator = GameObject.Find("CodeTranslator");
        codeTranslator.SetActive(false);
        sprite0 = revealedRug;
        sprite1 = normalRug;
    }

    // void Update()
    // {
    //     if (runTrigger)
    //     {
    //         if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space)) 
    //         {
    //             if(spriteRenderer.sprite == revealedRug) {
    //                 spriteRenderer.sprite = normalRug;
    //                 if (codeTranslator != null) {
    //                     codeTranslator.SetActive(false);
    //                 }
    //             } else {
    //                 spriteRenderer.sprite = revealedRug;
    //                 if (codeTranslator != null) {
    //                     codeTranslator.SetActive(true);
    //                 }
    //             }
    //             // Destroy(GetComponent<ChangeRug>());
    //         }
    //     }
    // }

    new void spriteFunc(int spriteToBe) 
    {
        if (spriteToBe == 0) {
            spriteRenderer.sprite = normalRug;
        } else {
            spriteRenderer.sprite = revealedRug;
        }
        if (codeTranslator != null) {
            codeTranslator.SetActive(spriteToBe == 1);
        }
    }
}
