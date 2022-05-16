using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    private SpriteRenderer sprite;
    public GameObject MainCharacter;
    public int thresh;

    void Start()
    {
         sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (MainCharacter.transform.position.y < thresh)
        {
            sprite.sortingOrder = 11;
        }
        if (MainCharacter.transform.position.y > thresh)
        {
            sprite.sortingOrder = 9;
        }
    }
}
