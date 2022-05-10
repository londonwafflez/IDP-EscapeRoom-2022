using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRug : MonoBehaviour
{
    //public GameObject obj;
    public Sprite revealedRug;
    bool runTrigger = false;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (runTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space))
            { 
                spriteRenderer.sprite = revealedRug;
                Destroy(GetComponent<ChangeRug>());
            }
        }
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
