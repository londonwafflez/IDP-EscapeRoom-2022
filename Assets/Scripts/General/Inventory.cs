using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Variables
    GameObject boxHighlight;
    SpriteRenderer spriteRenderer;

    KeyCode[] keyCodes = new KeyCode[] { KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7 };
    GameObject[] invBoxes = new GameObject[8];
    GameObject[] itemBoxes = new GameObject[8];
    public Sprite[] items = new Sprite[7];
    int activeInvBox = -1;
    int invItemCount = 0;
    bool isZoomed = false;

    //Start is called before the first frame update
    void Start()
    {
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
            if (Input.GetKeyDown(keyCodes[i]))
            {
                Debug.Log("Key " + keyCodes[i]);
                if (activeInvBox == i)
                {
                    invBoxes[i].SetActive(false);
                    activeInvBox = -1;
                    break;
                }

                if (activeInvBox != -1)
                {
                    invBoxes[activeInvBox].SetActive(false);
                }
                invBoxes[i].SetActive(true);
                activeInvBox = i;
                break;
            }
        }
    }

    public void itemGrabbed(int itemIndex) {
        spriteRenderer = itemBoxes[invItemCount + 1].GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = items[itemIndex];
        itemBoxes[invItemCount + 1].SetActive(true);
        invItemCount++;
    }

    public void onZoom()
    {
        isZoomed = true;
    }
}
