//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChibiMode : MonoBehaviour {

    public static bool isInChibiMode;

	void Update () 
	{
        if (isInChibiMode)
            transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
        else
            transform.localScale = Vector3.one;
	}
}
