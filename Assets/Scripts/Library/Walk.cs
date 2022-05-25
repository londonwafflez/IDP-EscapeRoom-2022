using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    private SpriteRenderer sprite;
    public GameObject MainCharacter;
    public int thresh;
    public int thresh2;
    public int thresh3;

    void Start()
    {
         sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (MainCharacter.transform.position.y < thresh)
        {
            sprite.sortingOrder = 12;
            //if (MainCharacter.transform.position.y < thresh)
              //  sprite.sortingOrder = 13;
        }
        
            
        if (MainCharacter.transform.position.y > thresh)
        {
            sprite.sortingOrder = 9;
            if (MainCharacter.transform.position.y > thresh2)
            {
                sprite.sortingOrder = 7;
                if (thresh3 != null && (MainCharacter.transform.position.y > thresh3)) 
                {
                    sprite.sortingOrder = 5;
                }
            }
        }
    }
}
