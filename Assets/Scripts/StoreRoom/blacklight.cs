using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blacklight : MonoBehaviour
{
    bool run = false;
    public GameObject blacklightCircle;

    // Update is called once per frame
    void Update()
    {
        if (run) {
            blacklightCircle.transform.position = gameObject.transform.position;
        }
    }

    public void holdingBlacklight(bool holding) {
        run = holding;
        if (holding) {
            blacklightCircle.SetActive(true);
        }
        else {
            blacklightCircle.SetActive(false);
        }
    }
}
