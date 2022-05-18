//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfTrigger : Trigger
{
    // public GameObject obj;
    public Sprite[] shelfSprites = new Sprite[9];
    // public GameObject shelfZoomed;
    SpriteRenderer spriteRenderer;
    Inventory m_inventory;
    GameObject curItem;
    int[] activeBooks = new int[3] { -1, -1, -1 };

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = obj.GetComponent<SpriteRenderer>();
        m_inventory = GameObject.Find("inventory").GetComponent<Inventory>();

    }

    protected override void toRun() {
        if (m_inventory.getActiveItem() == "N/A" || !isActive)
        {
            int spriteIndex = int.Parse(gameObject.name[14].ToString()) - 1;
            spriteRenderer.sprite = shelfSprites[spriteIndex];
            // spriteRenderer.sprite = shelfSprites[1];
            obj.SetActive(!isActive); // false to hide, true to show
            isActive = !isActive;
        } 
        else if (m_inventory.getActiveItem().Contains("book"))
        {
            curItem = GameObject.Find(m_inventory.getActiveItem());
            if (!curItem.activeSelf)
            {
                curItem.SetActive(true);
                activeBooks[curItem.name[4] - 1] = int.Parse(gameObject.name[14].ToString());
            } else
            {
                curItem.SetActive(false);
                activeBooks[curItem.name[4] - 1] = -1;
            }
        }
    }
}
