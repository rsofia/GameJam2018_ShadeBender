//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnhancedUI.EnhancedScroller;

public class LevelCellView : EnhancedScrollerCellView {

    public Button BTN_SelectLevel;
    public Image IMG_LevelImage;
    public Text TXT_LevelNumber;

    public void SetData(LevelData lvlData)
    {
        IMG_LevelImage.sprite = lvlData.LevelImage;
        TXT_LevelNumber.text = lvlData.LevelNumber + "";

        BTN_SelectLevel.onClick.RemoveAllListeners();
        BTN_SelectLevel.onClick.AddListener(() => OnSelectLevelClicked());
    }

    public void OnSelectLevelClicked()
    {
        Debug.Log("LEVEL SELECTED: " + TXT_LevelNumber.text);
        if(!PlayerPrefs.HasKey("rAngel"))
        {
            SCR_CustomizationColor.SetColors(Color.black, Color.white);
        }
        else
        {
            SCR_CustomizationColor.GetAllColors();
        }
    }

}
