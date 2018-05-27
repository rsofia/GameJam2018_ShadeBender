//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerLanguage : MonoBehaviour {

    public Sprite[] LanguageControllers;
    Image IMG;
	void Start () 
	{
        IMG = GetComponent<Image>();
	}
	
	void Update () 
	{
        if (LanguageManager.actualLanguage == 0)
            IMG.sprite = LanguageControllers[0];
        if (LanguageManager.actualLanguage == 1)
            IMG.sprite = LanguageControllers[1];
        if (LanguageManager.actualLanguage == 2)
            IMG.sprite = LanguageControllers[2];
    }
}
