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
        actualLanguage = DRP_Language.value;
    }
}
