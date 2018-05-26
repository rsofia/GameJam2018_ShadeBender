//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject MainPanel;

    [Header("Options GameObjects")]
    public GameObject OptionsPanel;
    public GameObject OptionsMainPanel;
    public GameObject AudioOptionsPanel;
    public GameObject VideoOptionsPanel;
    public GameObject GameOptionsPanel;
    public GameObject ControllerOptionsPanel;
    public Text OptionsTitle;
    public static int optionsLevelMenu = 0;

    [Header("Extras GameObjects")]
    public GameObject ExtrasPanel;
    public GameObject mainExtraPanel;
    public GameObject LevelSelectionPanel;

    public AudioManager audioMngr;
    [Header("Extras GameObjects")]
    public GameObject customizationPanel;
    public Image colorDemon;
    public Image colorAngel;



    #region Main Panel Functions
    public void OnQuitGameClicked()
    {
        Application.Quit();
    }

    public void OnExtrasClicked()
    {
        ExtrasPanel.SetActive(true);
        ExtrasPanel.GetComponent<FadeIn>().shouldFadeOut = false;
        ExtrasPanel.GetComponent<FadeIn>().shouldFadeIn = true;
        MainPanel.GetComponent<FadeIn>().shouldFadeIn = false;
        MainPanel.GetComponent<FadeIn>().shouldFadeOut = true;
    }

    public void OnOptionsClicked()
    {
        OptionsPanel.SetActive(true);
        OptionsPanel.GetComponent<FadeIn>().shouldFadeOut = false;
        OptionsPanel.GetComponent<FadeIn>().shouldFadeIn = true;
        MainPanel.GetComponent<FadeIn>().shouldFadeIn = false;
        MainPanel.GetComponent<FadeIn>().shouldFadeOut = true;

        OptionsMainPanel.SetActive(true);
        optionsLevelMenu = 1;
    }

    public void OnStartGameClicked()
    {
        LevelSelectionPanel.SetActive(true);
        MainPanel.GetComponent<FadeIn>().shouldFadeOut = true;
        LevelSelectionPanel.GetComponent<FadeIn>().shouldFadeIn = true;
        FindObjectOfType<LevelSelectorController>().LoadLevels();
    }
    #endregion

    #region Options Main Panel
    public void OnAudioClicked()
    {
        OptionsMainPanel.SetActive(false);
        AudioOptionsPanel.SetActive(true);
        OptionsTitle.text = "Audio";
        optionsLevelMenu = 2;
    }

    public void OnVideoClicked()
    {
        OptionsMainPanel.SetActive(false);
        VideoOptionsPanel.SetActive(true);
        OptionsTitle.text = "Video";
        optionsLevelMenu = 2;
    }

    public void OnGameOptionsClicked()
    {
        OptionsMainPanel.SetActive(false);
        GameOptionsPanel.SetActive(true);
        OptionsTitle.text = "Game Options";
        optionsLevelMenu = 2;
    }

    public void OnControllerClicked()
    {
        OptionsMainPanel.SetActive(false);
        ControllerOptionsPanel.SetActive(true);
        OptionsTitle.text = "Controller";
        optionsLevelMenu = 2;
    }

    //I was too tired, didnt know what i was doing, trying my best, sorry for this useless switch
    public void OnBackClicked()
    {
        switch(optionsLevelMenu)
        {
            case 1:
                {
                    OptionsPanel.GetComponent<FadeIn>().shouldFadeOut = true;
                    OptionsPanel.GetComponent<FadeIn>().shouldFadeIn = false;
                    MainPanel.GetComponent<FadeIn>().shouldFadeIn = true;
                    MainPanel.GetComponent<FadeIn>().shouldFadeOut = false;

                    break;
                }
            case 2:
                {
                    OptionsTitle.text = "Options";
                    OptionsMainPanel.SetActive(true);
                    AudioOptionsPanel.SetActive(false);
                    VideoOptionsPanel.SetActive(false);
                    GameOptionsPanel.SetActive(false);
                    ControllerOptionsPanel.SetActive(false);
                    optionsLevelMenu = 1;
                    break;
                }
            default:
                break;
        }
    }
    #endregion

    #region Video Functions
    public void OnFullScreenClicked()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    #endregion

    #region Audio Functions
    public void MusicVolumeChange(float value)
    {
        audioMngr.musicAuSrc.volume = value;
    }
    #endregion

    #region Game Options Functions

    #endregion

    #region Controller Options Functions

    #endregion

    #region Extras Functions
    public void OnCreditsClicked()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnExtraBackClicked()
    {
        MainPanel.GetComponent<FadeIn>().shouldFadeIn = true;
        MainPanel.GetComponent<FadeIn>().shouldFadeOut = false;
        ExtrasPanel.GetComponent<FadeIn>().shouldFadeOut = true;
        ExtrasPanel.GetComponent<FadeIn>().shouldFadeIn = false;
    }
    public void OnCustomizationClicked()
    {
        mainExtraPanel.SetActive(false);
        customizationPanel.SetActive(true);
        if(PlayerPrefs.HasKey(""))
        {
            colorAngel.color = SCR_CustomizationColor.colorAngel;
            colorDemon.color = SCR_CustomizationColor.colorDemon;
        }
        else
        {
            colorAngel.color = Color.white;
            colorDemon.color = Color.black;
        }


    }
    #endregion

    #region Customization Functions
    public void OnBackClickedCustom()
    {
        mainExtraPanel.SetActive(true);
        customizationPanel.SetActive(false);
    }
    public void OnConfirmClickedCustom()
    {
        SCR_CustomizationColor.SetColors(colorDemon.color,colorAngel.color);
        mainExtraPanel.SetActive(true);
        customizationPanel.SetActive(false);
    }
    public void OnRestoreDefaultClicked()
    {
        colorDemon.color = Color.black;
        colorAngel.color = Color.white;
        SCR_CustomizationColor.SetColors(colorDemon.color, colorAngel.color);
        mainExtraPanel.SetActive(true);
        customizationPanel.SetActive(false);
    }
    public void UpdateColor(int _selection)
    {

    }

    #endregion
}
