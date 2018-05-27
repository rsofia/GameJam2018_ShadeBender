//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageChanger : MonoBehaviour {

    public string EspaniolTexto;
    public string EnglishText;
    public string FrancaisTexte;

    Text TXT_Actual;
    private void Start()
    {
        TXT_Actual = GetComponent<Text>();
        FrancaisTexte = EnglishText + " in Swahili";
    }

    private void Update()
    {
        if (LanguageManager.actualLanguage == 0)
            TXT_Actual.text = EnglishText;
        if (LanguageManager.actualLanguage == 1)
            TXT_Actual.text = EspaniolTexto;
        if (LanguageManager.actualLanguage == 2)
            TXT_Actual.text = FrancaisTexte;
    }
}
