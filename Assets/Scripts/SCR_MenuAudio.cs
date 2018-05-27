using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MenuAudio : MonoBehaviour {

    public AudioSource mySongPlayer;
    public AudioClip[] songs;
	// Use this for initialization
	void Start () {
        mySongPlayer.Pause();
        mySongPlayer.clip = songs[0];
        mySongPlayer.Play();
	}
	
    public void SwitchAudio(int _song)
    {
        mySongPlayer.Pause();
        mySongPlayer.clip = songs[_song];
        mySongPlayer.Play();
    }
}
