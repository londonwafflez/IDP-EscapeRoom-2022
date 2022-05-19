//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfTrigger : Trigger
{
    // public GameObject obj;
    public Sprite[] shelfSprites = new Sprite[9];
    public GameObject[] bookSides = new GameObject[3];
    // public GameObject shelfZoomed;
    SpriteRenderer spriteRenderer;
    Inventory m_inventory;
    GameObject curBook;

    [HideInInspector]
    int[] activeBooks = new int[3] { -1, -1, -1 };

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = obj.GetComponent<SpriteRenderer>();
        m_inventory = GameObject.Find("inventory").GetComponent<Inventory>();
    }

    int charToInt(char ch)
    {
        return int.Parse(ch.ToString());
    }

    void hideBooks()
    {
        bookSides[0].SetActive(false);
        bookSides[1].SetActive(false);
        bookSides[2].SetActive(false);
        obj.SetActive(false);
        isActive = false;
    }

    protected override void toRun() {
        if (m_inventory.getActiveItem() == "N/A" || !isActive || bookSides[0] == null)
        {
            int spriteIndex = charToInt(gameObject.name[14]) - 1;
            spriteRenderer.sprite = shelfSprites[spriteIndex];
            // spriteRenderer.sprite = shelfSprites[1];
            obj.SetActive(!isActive); // false to hide, true to show
            isActive = !isActive;

            if (bookSides[1] != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (activeBooks[i] == charToInt(gameObject.name[14]))
                    {
                        Debug.Log(activeBooks[i] + " is equal to " + gameObject.name[14] + " at index " + i);
                        bookSides[i].SetActive(true);
                    }
                }
            }
            
            if (!isActive && bookSides[0] != null)
            {
                hideBooks();
            }
        } 
        else if (m_inventory.getActiveItem().Contains("book"))
        {
            curBook = bookSides[charToInt(m_inventory.getActiveItem()[4]) - 1];
            if (!curBook.activeSelf)
            {
                curBook.SetActive(true);
                m_inventory.used(m_inventory.getActiveItem());
                activeBooks[charToInt(curBook.name[4]) - 1] = charToInt(gameObject.name[14]);
            }/* else
            {
                curBook.SetActive(false);
                m_inventory.itemGrabbed(charToInt(curBook.name[4]) + 4);
                activeBooks[charToInt(curBook.name[4]) - 1] = -1;
            }*/
        } else
        {
            hideBooks();
        }
    }

    void OnTriggerExit2D()
    {
        runTrigger = false;
        if (bookSides[0] != null) {
            hideBooks();
        }
    }

    public void changeActiveBooks(int index, int newVal)
    {
        Debug.Log("ShelfTrigger.cs recieved index: " + index + " val: " + newVal);
        activeBooks[index] = newVal;
        Debug.Log(activeBooks[index]);
    }
}
