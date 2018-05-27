//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionSelector : MonoBehaviour {

    public Dropdown DRP_Resolution;

	void Start () 
	{
        DRP_Resolution.onValueChanged.AddListener(delegate
        {
            ChangeResolution();
        });
    }
	
    public void ChangeResolution()
    {
        if(DRP_Resolution.value == 0)
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
        if (DRP_Resolution.value == 1)
            Screen.SetResolution(1280, 720, Screen.fullScreen);
        if (DRP_Resolution.value == 2)
            Screen.SetResolution(1024, 576, Screen.fullScreen);
    }
}
