//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [HideInInspector]
    public AudioSource musicAuSrc;
    [HideInInspector]
    public AudioSource fxAuSrc;

    void Start()
    {
        musicAuSrc = GetComponents<AudioSource>()[0];
        fxAuSrc = GetComponents<AudioSource>()[1];
    }

    void Update()
    {

    }

    public void PlayEffect()
    {
        if (!fxAuSrc.isPlaying)
            fxAuSrc.Play();
    }
}
