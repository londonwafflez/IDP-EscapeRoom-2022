using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfTrigger : Trigger
{
    // public GameObject obj;
    public Sprite[] shelfSprites = new Sprite[9];
    // public GameObject shelfZoomed;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = obj.GetComponent<SpriteRenderer>();
    }

    protected override void toRun() {
        int spriteIndex = int.Parse(gameObject.name[14].ToString()) - 1;
        spriteRenderer.sprite = shelfSprites[spriteIndex];
        // spriteRenderer.sprite = shelfSprites[1];
        obj.SetActive(!isActive); // false to hide, true to show
        isActive = !isActive;
    }
}
