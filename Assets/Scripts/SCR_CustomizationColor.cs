using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CustomizationColor : MonoBehaviour
{

    public static Color colorAngel;
    public static Color colorDemon;

    static void SaveAllColors()
    {
        PlayerPrefs.SetFloat("rAngel", colorAngel.r);
        PlayerPrefs.SetFloat("gAngel", colorAngel.g);
        PlayerPrefs.SetFloat("bAngel", colorAngel.b);
        PlayerPrefs.SetFloat("rDemon", colorDemon.r);
        PlayerPrefs.SetFloat("gDemon", colorDemon.g);
        PlayerPrefs.SetFloat("bDemon", colorDemon.b);
    }
    public static void GetAllColors()
    {
        colorAngel = new Color(PlayerPrefs.GetFloat("rAngel", colorAngel.r), PlayerPrefs.GetFloat("gAngel", colorAngel.g), PlayerPrefs.GetFloat("bAngel", colorAngel.b));
        colorDemon = new Color(PlayerPrefs.GetFloat("rDemon", colorDemon.r), PlayerPrefs.GetFloat("gDemon", colorDemon.g), PlayerPrefs.GetFloat("bDemon", colorAngel.b));
    }
    public static void SetColors(Color _demonColor, Color _angelColor)
    {
        colorAngel = _angelColor;
        colorDemon = _demonColor;
        SaveAllColors();
    }

}
