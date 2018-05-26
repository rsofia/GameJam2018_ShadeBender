//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour {

	void Start () 
	{
		
	}
	
	void Update () 
	{
        RenderSettings.skybox.SetFloat("_Rotation", Time.time);
    }
}
