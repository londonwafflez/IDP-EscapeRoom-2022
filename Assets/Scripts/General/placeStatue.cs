using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeStatue : Trigger
{
    Inventory inventory;
    Hints hints;
    ChangeActiveScene scene;
    public GameObject sceneStatue, artifactObjs;
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
        if (inventory.getActiveItem() == "invStatue" && !sceneStatue.activeSelf) {
            inventory.used("invStatue");
            sceneStatue.SetActive(true);
            statuesPlaced++;
            if (statuesPlaced >= 3) {
                // win
                hints.SetPrompt(13);
                artifactObjs.SetActive(true);

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
