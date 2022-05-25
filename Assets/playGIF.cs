using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playGIF : MonoBehaviour
{
    Texture2D[] frames = new Texture2D[100];
    double framesPerSecond = 10.0;

    void Update()
    {
        int index = (int)(Time.time * framesPerSecond);
        index = index % frames.Length;
        GetComponent<Renderer>().material.mainTexture = frames[index];
    }
}
