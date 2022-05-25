using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeStatue : Trigger
{
    Inventory inventory;
    Hints hints;
    ChangeActiveScene scene;
    GameObject sceneStatue;
    static int statuesPlaced = 0;

    void Start()
    {
        inventory = GameObject.Find("inventory").GetComponent<Inventory>();
        scene = GameObject.Find("InSceneSceneChanger").GetComponent<ChangeActiveScene>();
        hints = GameObject.Find("HintButton").GetComponent<Hints>();
    }

    // Update is called once per frame
    protected override void toRun()
    {
        if (inventory.getActiveItem() == "statue") {
            inventory.used("statue");
            sceneStatue.SetActive(true);
            statuesPlaced++;
            if (statuesPlaced >= 3) {
                // win
                Debug.Log("win or something");
            }
        } else { 
            switch (scene.getScene()) {
                case "StorageRoom":
                    hints.SetPrompt(7);
                    break;

                case "Library":
                    hints.SetPrompt(10);
                    break;

                case "LivingRoom":
                    hints.SetPrompt(12);
                    break;
            }
            
        }
    }
}
