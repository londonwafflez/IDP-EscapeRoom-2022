using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dollTrigger : Trigger
{
    Inventory m_inventory;
    public GameObject obj1;
    bool isActive1;

    // Start is called before the first frame update
    void Start()
    {
        m_inventory = GameObject.Find("inventory").GetComponent<Inventory>();
    }

    protected override void toRun()
    {
        if (m_inventory.getActiveItem() == "invTeaCup")
        {
            obj1.SetActive(!isActive); // false to hide, true to show
            isActive1 = !isActive1;
            GameObject.Find("HintsButton").GetComponent<Hints>().FinishedPuzzle();
        } else
        {
            obj.SetActive(!isActive); // false to hide, true to show
            isActive = !isActive;
        }
    }

    void OnTriggerExit2D() {
        obj.SetActive(false);
        obj1.SetActive(false);
        isActive = false;
        isActive1 = false;
        runTrigger = false;
    }
}
