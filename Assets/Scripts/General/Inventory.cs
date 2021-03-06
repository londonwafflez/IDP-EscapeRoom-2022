using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    //Variables
    GameObject boxHighlight;
    SpriteRenderer spriteRenderer;
    public GameObject popOut;
    Player player;

    KeyCode[] keyCodes = new KeyCode[] { KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7 };
    GameObject[] invBoxes = new GameObject[8];
    GameObject[] itemBoxes = new GameObject[8];
    bool[] activeItemBoxes = new bool[8] {true, false, false, false, false, false, false, false};
    public Sprite[] items = new Sprite[20];
    int activeInvBox = -1;
    int invItemCount = 0;
    int lastBoxIdentity;
    int nextBox = -1;
    int popOutItem;
    int popOutItem2;
    blacklight m_blacklight;
    // bool isZoomed = false;

    void setActiveItemBox(int i) {
        do {
                if (activeInvBox == i)
            {
                invBoxes[i].SetActive(false);
                activeInvBox = -1;
                if (popOut != null)
                    popOut.SetActive(false);
                try {m_blacklight.holdingBlacklight(false);} catch {}
                break;
            }

            if (activeInvBox != -1)
            {
                if (popOut != null)
                    popOut.SetActive(false);
                invBoxes[activeInvBox].SetActive(false);
            }
            invBoxes[i].SetActive(true);
            activeInvBox = i;

            try
            {
                if (itemBoxes[activeInvBox].GetComponent<SpriteRenderer>().sprite != null)
                    if (itemBoxes[activeInvBox].GetComponent<SpriteRenderer>().sprite.name == "Blacklight")
                    {
                        m_blacklight.holdingBlacklight(true);
                    }
                    else
                        m_blacklight.holdingBlacklight(false);
            } catch { }

            if ((activeInvBox == popOutItem || activeInvBox == popOutItem2) && popOut != null)
            {
                popOut.GetComponent<SpriteRenderer>().sprite = itemBoxes[activeInvBox].GetComponent<SpriteRenderer>().sprite;
                popOut.SetActive(true);
                Debug.Log("popoutitem active");
            }
            break;
        } while (false);
    }


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        m_blacklight = GameObject.Find("MainCharacter").GetComponent<blacklight>();

        invBoxes[0] = GameObject.Find("nothing"); // null object
        for (int i = 1; i < 8; i++) {
            invBoxes[i] = GameObject.Find("InvBox" + i);
            invBoxes[i].SetActive(false);
        }

        itemBoxes[0] = GameObject.Find("nothing"); // null object
        for (int i = 1; i < 8; i++) {
            itemBoxes[i] = GameObject.Find("itemBox" + i);
            itemBoxes[i].SetActive(false);
        }
    }

    void Update() {
        for (int i = 1; i < 7 + 1; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]) && !GameObject.Find("MainCharacter").GetComponent<Player>().getTyping())
            {   
                setActiveItemBox(i);
            }
        }
    }

    public void itemGrabbed(int itemIndex) {
        if (activeInvBox != -1) {
            invBoxes[activeInvBox].SetActive(false);
            activeInvBox = -1;
        }
        invItemCount++;

        for (int i = 0; i < activeItemBoxes.Length; i++) { 
            if (!activeItemBoxes[i]) {
                nextBox = i;
                activeItemBoxes[i] = true;
                break;
            }
        }

        spriteRenderer = itemBoxes[nextBox].GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = items[itemIndex];
        itemBoxes[nextBox].SetActive(true);
        if (itemIndex == 4 || itemIndex == 8)
        {
            if (popOutItem == null || popOutItem == 0) 
            {
                popOutItem = nextBox;
                Debug.Log("Popoutitem" + popOutItem);
            }
            else 
            {
                popOutItem2 = nextBox;
                Debug.Log("Popoutitem2" + popOutItem2);
            }
        }
        nextBox = -1;
    }
// next 4 inv 2
    public void used(string spriteName)
    {
        if (activeInvBox != -1)
        {
            invBoxes[activeInvBox].SetActive(false);
            activeInvBox = -1;
        }
        itemBoxes[lastBoxIdentity].SetActive(false);
        spriteRenderer.sprite = null;
        nextBox = lastBoxIdentity;
        activeItemBoxes[lastBoxIdentity] = false;
        
        invItemCount--;
    }
    // public void onZoom()
    // {
    //     isZoomed = true;
    // }

    // public string whatItemDragged(int boxIdentity)
    // {
    //     spriteRenderer = itemBoxes[boxIdentity].GetComponent<SpriteRenderer>();
    //     lastBoxIdentity = boxIdentity;
    //     return spriteRenderer.sprite.name;
    // }

    public void clickActive(int boxIdentity) {
        setActiveItemBox(boxIdentity);
    }

    public string getActiveItem()
    {
        if (activeInvBox == -1) { return "N/A"; }
        spriteRenderer = itemBoxes[activeInvBox].GetComponent<SpriteRenderer>();
        lastBoxIdentity = activeInvBox;
        try { return spriteRenderer.sprite.name; }
        catch { return "N/A"; }
    }
}
