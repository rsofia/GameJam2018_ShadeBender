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

    float tiempoEstimado;
    float tiempoColores;
    bool isLeanTweenActivated;

    //Imagen
    //SCR_Level
    //      - Tiempo de nivel estimado
    //      - Tiempo de cambio de colores
    //      - Lean Tween is Activated
    public void SetData(LevelData lvlData)
    {
        IMG_LevelImage.sprite = lvlData.LevelImage;
        TXT_LevelNumber.text = lvlData.LevelNumber + "";

        tiempoEstimado = lvlData.time;
        tiempoColores = lvlData.colorTime;
        isLeanTweenActivated = lvlData.leanTween;

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

        SCR_Level.estimatedTimeInSeconds = tiempoEstimado;
        SCR_Level.tiempoACambiar = tiempoColores;
        SCR_Level.lerpEnemies = isLeanTweenActivated;

        var croppedTexture = new Texture2D((int)IMG_LevelImage.sprite.rect.width, (int)IMG_LevelImage.sprite.rect.height);
        var pixels = IMG_LevelImage.sprite.texture.GetPixels((int)IMG_LevelImage.sprite.textureRect.x,
                                                (int)IMG_LevelImage.sprite.textureRect.y,
                                                (int)IMG_LevelImage.sprite.textureRect.width,
                                                (int)IMG_LevelImage.sprite.textureRect.height);
        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();

        LevelGenerator.map = croppedTexture;
        UnityEngine.SceneManagement.SceneManager.LoadScene("SCN_Nivel_0");
    }

}
