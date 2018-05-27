//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchChibi : MonoBehaviour {

    public Sprite IMG_FullScreen;
    public Sprite IMG_NotFullScreen;

    Image myImage;

    void Start()
    {
        myImage = GetComponent<Image>();
    }

    void Update()
    {
        if (ChibiMode.isInChibiMode)
            myImage.sprite = IMG_FullScreen;
        else
            myImage.sprite = IMG_NotFullScreen;
    }
}
