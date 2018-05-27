//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour {

    public Dropdown DRP_Language;
    public static int actualLanguage;
    void Start()
    {
        DRP_Language.onValueChanged.AddListener(delegate
        {
            SelectLanguage();
        });
    }

    public void SelectLanguage()
    {
        if(DRP_Language.value ==2 && actualLanguage!=2)
        {
            FindObjectOfType<SCR_MenuAudio>().SwitchAudio(1);
        }
        else if((DRP_Language.value == 1||DRP_Language.value==0) && actualLanguage == 2)
        {
            FindObjectOfType<SCR_MenuAudio>().SwitchAudio(0);
        }
        actualLanguage = DRP_Language.value;

    }
}
