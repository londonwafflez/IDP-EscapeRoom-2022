// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfTrigger : Trigger
{
    // public GameObject obj;
    public Sprite[] shelfSprites = new Sprite[9];
    public GameObject[] bookSides = new GameObject[3];
    public GameObject mockBirdBook, mockBirdInside, door;
    // public GameObject shelfZoomed;
    SpriteRenderer spriteRenderer;
    Inventory m_inventory;
    GameObject curBook, bookshelf6;
    int booksCorrect;
    bool alreadyRun = false;

    [HideInInspector]
    static int[] activeBooks = new int[3] { -1, -1, -1 };

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = obj.GetComponent<SpriteRenderer>();
        m_inventory = GameObject.Find("inventory").GetComponent<Inventory>();
        bookshelf6 = GameObject.Find("bookshelf(6)");
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
    }

    void checkDoor() {
        booksCorrect = 0;
        for (int i = 1; i < 4; i++) {
            if (activeBooks[i - 1] == i * 4 - 3) //Checks for 1, 5, 9
            {
                booksCorrect ++;
            }
        }

        if (booksCorrect >= 3 && !alreadyRun) {
            alreadyRun = true;
            door.SetActive(true);
            bookshelf6.GetComponent<Rigidbody2D>().simulated = true;
            bookshelf6.GetComponent<Rigidbody2D>().velocity = new Vector2(300, 0);
            GameObject.Find("ShelfTrigger (6)").SetActive(false);
            GameObject.Find("HintButton").GetComponent<Hints>().FinishedPuzzle();
        }
    }

    protected override void toRun() {
        do {
            if (m_inventory.getActiveItem() == "N/A" || !isActive || bookSides[0] == null)
            {
                int spriteIndex = charToInt(gameObject.name[14]) - 1;
                spriteRenderer.sprite = shelfSprites[spriteIndex];
                if (spriteIndex == 2) { 
                    mockBirdBook.SetActive(true); 
                    // mockBirdButton.SetActive(true); 
                }
                if (isActive && mockBirdBook != null) { 
                    if (mockBirdInside.activeSelf) {
                        mockBirdInside.SetActive(false);
                        break;
                    }
                    mockBirdBook.SetActive(false);
                }
                // spriteRenderer.sprite = shelfSprites[1];
                obj.SetActive(!isActive); // false to hide, true to show
                isActive = !isActive;
                
                if (bookSides[1] != null)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Debug.Log(activeBooks[i]);
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
                    checkDoor();
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
                obj.SetActive(false);
                isActive = false;
                checkDoor();
            }
        } while (false);
    }

    void OnTriggerExit2D()
    {
        runTrigger = false;
        obj.SetActive(false);
        isActive = false;
        if (bookSides[0] != null) {
            hideBooks();
            checkDoor();
        }
        if (mockBirdBook != null) {
            mockBirdBook.SetActive(false);
            // MockBirdButton.SetActive(true); 
            mockBirdInside.SetActive(false);
        }
    }

    public void changeActiveBooks(int index, int newVal)
    {
        Debug.Log("ShelfTrigger.cs recieved index: " + index + " val: " + newVal);
        activeBooks[index] = newVal;
        Debug.Log(activeBooks[index]);
    }
}
