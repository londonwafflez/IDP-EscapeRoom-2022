using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRug : MonoBehaviour
{
    //public GameObject obj;
    public Sprite revealedRug;
    public Sprite normalRug;
    bool runTrigger = false;
    SpriteRenderer spriteRenderer;
    GameObject codeTranslator;
    public BoxCollider2D RugCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        codeTranslator = GameObject.Find("CodeTranslator");
        codeTranslator.SetActive(false);
    }

    void Update()
    {
        if (runTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space))
            { 
                if(spriteRenderer.sprite == revealedRug) {
                    spriteRenderer.sprite = normalRug;
                    if (codeTranslator != null) {
                        codeTranslator.SetActive(false);
                    }
                } else {
                    spriteRenderer.sprite = revealedRug;
                    if (codeTranslator != null) {
                        codeTranslator.SetActive(true);
                    }
                }
                // Destroy(GetComponent<ChangeRug>());
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
