using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SCR_EmitSound : MonoBehaviour {

    public AudioClip sound;
    protected AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
        source.clip = sound;
        source.loop = false;
    }

    public void PlaySound()
    {
        if (source == null)
        {
            source = GetComponent<AudioSource>();
            source.playOnAwake = false;
            source.clip = sound;
            source.loop = false;
        }
        source.Play();
    }
}
