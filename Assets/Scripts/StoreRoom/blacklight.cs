using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blacklight : MonoBehaviour
{
    bool run = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (run) {
            
        }
    }

    public void holdingBlacklight(bool holding) {
        run = holding;
    }
}
