using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public int sortingOrder = 2;
    private SpriteRenderer sprite;
    public GameObject MainCharacter;

    void Start()
    {
         sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (MainCharacter.transform.position.y < 190)
        {
            sprite.sortingOrder = 11;
        }
        if (MainCharacter.transform.position.y > 190)
        {
            sprite.sortingOrder = 9;
        }
    }
}
