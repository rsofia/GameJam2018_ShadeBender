//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSprite : MonoBehaviour {

    public Sprite IMG_FullScreen;
    public Sprite IMG_NotFullScreen;

    Image myImage;

	void Start () 
	{
        myImage = GetComponent<Image>();
	}
	
	void Update () 
	{
        if (Screen.fullScreen)
            myImage.sprite = IMG_FullScreen;
        else
            myImage.sprite = IMG_NotFullScreen;           
	}
}
