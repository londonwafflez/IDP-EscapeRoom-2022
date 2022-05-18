using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableItem : MonoBehaviour
{
    Inventory m_inventory;
    public int itemIndex;
    bool used = false;
    bool runTrigger;
    
    void Start() {
        m_inventory = GameObject.Find("inventory").GetComponent<Inventory>();
        Debug.Log(m_inventory);
    }

    // Update is called once per frame
    void Update()
    {
        if (runTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.SetActive(false);
                Debug.Log(itemIndex + " used");
                m_inventory.itemGrabbed(itemIndex);
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!used) {
            runTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        runTrigger = false;
    }
}
