using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
//public GameObject obj;
    protected Sprite sprite0;
    protected Sprite sprite1;
    protected bool runTrigger = false;
    protected SpriteRenderer spriteRenderer;

    protected void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected void Update()
    {
        if (runTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space))
            { 
                Debug.Log("F or space clicked");
                if(spriteRenderer.sprite == sprite0) {
                    spriteFunc(0);
                } else {
                    spriteFunc(1);
                }
            }
        }
    }

    protected void spriteFunc(int spriteToBe) {

    }

    void OnTriggerEnter2D()
    {
        runTrigger = true;
    }

    void OnTriggerExit2D()
    {
        runTrigger = false;
    }
}
