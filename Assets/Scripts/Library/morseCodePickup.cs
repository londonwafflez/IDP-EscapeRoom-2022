using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class morseCodePickup : MonoBehaviour
{
    public void MorseTranslatorClicked()
    {
        gameObject.SetActive(false);
        GameObject.Find("inventory").GetComponent<Inventory>().itemGrabbed(8);
        Destroy(this.gameObject);
    }
}
