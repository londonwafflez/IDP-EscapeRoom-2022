using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRug : ChangeSprite
{
    public Sprite revealedRug;
    public Sprite basementRug;
    BoxCollider2D rugCollider;
    GameObject codeTranslator;
    Vector2 revRugOffset = new Vector2(-10, 0);
    Vector2 normRugOffset = new Vector2(0, 0);


    new void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rugCollider = GetComponent<BoxCollider2D>();
        codeTranslator = GameObject.Find("CodeTranslator");
        codeTranslator.SetActive(false);
        sprite0 = revealedRug;
        sprite1 = basementRug;
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

    protected override void spriteFunc(int spriteToBe)
    {
        if (spriteToBe == 0) {
            spriteRenderer.sprite = revealedRug;
            rugCollider.offset = revRugOffset;
        } else {
            spriteRenderer.sprite = basementRug;
            rugCollider.offset = normRugOffset;
        }
        if (codeTranslator != null) {
            codeTranslator.SetActive(spriteToBe == 0);
        }
    }
}
