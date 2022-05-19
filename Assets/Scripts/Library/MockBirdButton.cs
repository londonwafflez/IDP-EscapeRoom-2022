using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockBirdButton : MonoBehaviour
{
    public GameObject MockBirdInside;

    // Update is called once per frame
    public void ChangeMockBird() 
    {
        if (GameObject.Find("MockBirdSide") != null) {
            MockBirdInside.SetActive(true);
        }
    }
}
