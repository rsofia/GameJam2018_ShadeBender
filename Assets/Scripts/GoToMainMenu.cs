//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMainMenu : MonoBehaviour {
	
	void Update () 
	{
        if (Input.GetKeyDown(KeyCode.JoystickButton7) && FadeText.canStart)
        {
            FadeText.hasStarted = true;
        }

    }
}
