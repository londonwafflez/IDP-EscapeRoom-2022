using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockBirdButton : MonoBehaviour
{
    public GameObject MockBirdInside;
    bool opennedBefore = false;

    // Update is called once per frame
    public void ChangeMockBird() 
    {
        if (GameObject.Find("MockBirdSide") != null) {
            MockBirdInside.SetActive(true);
        }
        if (!opennedBefore) {
            GameObject.Find("HintButton").GetComponent<Hints>().FinishedPuzzle();
            opennedBefore = true;
        }
    }
}
