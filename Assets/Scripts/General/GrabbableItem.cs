using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableItem : MonoBehaviour
{
    public Inventory inventory;
    public int itemIndex;
    bool used = false;
    bool runTrigger;
    
    void Start() {
        // inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (runTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.SetActive(false);
                Debug.Log(inventory);
                inventory.itemGrabbed(itemIndex);
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
