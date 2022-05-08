using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Variables
    GameObject boxHighlight;
    SpriteRenderer m_SpriteRenderer;

    KeyCode[] keyCodes = new KeyCode []{ KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7 };
    GameObject[] invBoxes = new GameObject[8];
    int activeInvBox = -1;
    int invItemCount = 7;

    //Start is called before the first frame update
    void Start()
    {
        invBoxes[0] = GameObject.Find("nothing"); // null object
        for (int i = 1; i < 8; i++) {
            invBoxes[i] = GameObject.Find("InvBox" + i);
            invBoxes[i].SetActive(false);
        } 
    }

    private void Update() {
        for (int i = 1; i < invItemCount + 1; i++)
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
}
