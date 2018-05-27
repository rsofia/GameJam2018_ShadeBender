using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MenuAudio : MonoBehaviour {

    AudioSource mySongPlayer;
    AudioClip[] songs;
	// Use this for initialization
	void Start () {
        mySongPlayer = GameObject.FindObjectOfType<AudioSource>();
        mySongPlayer.Pause();
        mySongPlayer.clip = songs[0];
        mySongPlayer.Play();
	}
	
	// Update is called once per frame
	void Update () {
	    //if(LanguageManager.actualLanguage==2)
        //{

            
//        }
	}
}
