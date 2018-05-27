//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour {

    public Dropdown DRP_Language;

    void Start () 
	{
        Debug.Log(DRP_Language.options[DRP_Language.value].text);
	}
	
	void Update () 
	{
		
	}
}
