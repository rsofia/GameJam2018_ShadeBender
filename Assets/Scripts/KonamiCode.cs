//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonamiCode : MonoBehaviour {

    List<KeyCode> KeyCodepresses;
    List<KeyCode> konamicode;

    void Start()
    {
        KeyCodepresses = new List<KeyCode>();
        konamicode = new List<KeyCode>(){KeyCode.JoystickButton3, KeyCode.JoystickButton3, KeyCode.JoystickButton0, KeyCode.JoystickButton0,
    KeyCode.JoystickButton2, KeyCode.JoystickButton1, KeyCode.JoystickButton2, KeyCode.JoystickButton1, KeyCode.JoystickButton6, KeyCode.JoystickButton7};
    }

    private void Update()
    {
        if(Input.anyKey)
        {
            Debug.Log(Input.inputString);
        }
    }

    void OnInput(KeyCode KeyCodeValue)
    {
        KeyCodepresses.Add(KeyCodeValue);
        if (KeyCodepresses.Count > konamicode.Count)
            KeyCodepresses.RemoveAt(0);
        if (KeyCodepresses == konamicode)
            Debug.Log("BOOM SCHAKALAKA ITS THE KONAMI COOOODE!");
    }
}
