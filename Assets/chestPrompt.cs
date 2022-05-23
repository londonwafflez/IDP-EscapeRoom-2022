using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestPrompt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("HintButton").GetComponent<Hints>().SetPrompt(4);
    }

}
