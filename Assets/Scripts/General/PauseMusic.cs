using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMusic : MonoBehaviour
{
    public AudioSource music;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf) music.Pause();
        else music.Play();
    }
}