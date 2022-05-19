using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proximityCheck : MonoBehaviour
{
    public GameObject blacklightcode;
    GameObject mc;
    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        mc = GameObject.Find("MainCharacter");
        inventory = GameObject.Find("inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(gameObject.transform.position, mc.transform.position) < 100 && inventory.getActiveItem() == "Blacklight" && mc.transform.position.x > 435) {
            blacklightcode.SetActive(true);
        } else {
            blacklightcode.SetActive(false);
        }
    }
}
