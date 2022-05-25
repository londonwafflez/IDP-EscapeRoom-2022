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

    protected virtual void toRun()
    {
        if (m_inventory.getActiveItem() == "teacup")
        {
            obj1.SetActive(!isActive); // false to hide, true to show
            isActive1 = !isActive1;
        } else
        {
            obj.SetActive(!isActive); // false to hide, true to show
            isActive = !isActive;
        }
    }
}
