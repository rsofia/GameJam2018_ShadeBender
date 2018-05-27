//Made by Luis Bazan
//luisbernardo@golstats.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    [Header("Main GameObjects")]
    public GameObject MainPanel;
    public Button firstSelectionMain;


    [Header("Options GameObjects")]
    public Button firstSelectionOptions;
    public Button firstSelectionInnerOptions;


    public GameObject OptionsPanel;
    public GameObject OptionsMainPanel;
    public GameObject AudioOptionsPanel;
    public GameObject VideoOptionsPanel;
    public GameObject GameOptionsPanel;
    public GameObject ControllerOptionsPanel;
    public Text OptionsTitle;
    public static int optionsLevelMenu = 0;

    [Header("Extras GameObjects")]
    public Button firstSelectionExtras;
    public GameObject ExtrasPanel;
    public GameObject mainExtraPanel;
    public GameObject LevelSelectionPanel;

    public AudioManager audioMngr;
    [Header("Customization GameObjects")]
    public Button firstSelectionCustom;
    public GameObject customizationPanel;
    public Image colorDemon;
    public Image colorAngel;
    public Slider sldrRDemon;
    public Slider sldrGDemon;
    public Slider sldrBDemon;
    public Slider sldrRAngel;
    public Slider sldrBAngel;
    public Slider sldrGAngel;



    #region Main Panel Functions
    public void OnQuitGameClicked()
    {
        Application.Quit();
    }

    public void OnExtrasClicked()
    {
        firstSelectionExtras.Select();

        ExtrasPanel.SetActive(true);

        ExtrasPanel.GetComponent<FadeIn>().shouldFadeOut = false;
        ExtrasPanel.GetComponent<FadeIn>().shouldFadeIn = true;
        MainPanel.GetComponent<FadeIn>().shouldFadeIn = false;
        MainPanel.GetComponent<FadeIn>().shouldFadeOut = true;
    }

    public void OnOptionsClicked()
    {
        firstSelectionOptions.Select();
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
        firstSelectionInnerOptions.Select();

        OptionsMainPanel.SetActive(false);
        AudioOptionsPanel.SetActive(true);
        OptionsTitle.text = "Audio";
        optionsLevelMenu = 2;
    }

    public void OnVideoClicked()
    {
        firstSelectionInnerOptions.Select();

        OptionsMainPanel.SetActive(false);
        VideoOptionsPanel.SetActive(true);
        OptionsTitle.text = "Video";
        optionsLevelMenu = 2;
    }

    public void OnGameOptionsClicked()
    {
        firstSelectionInnerOptions.Select();

        OptionsMainPanel.SetActive(false);
        GameOptionsPanel.SetActive(true);
        OptionsTitle.text = "Game Options";
        optionsLevelMenu = 2;
    }

    public void OnControllerClicked()
    {
        firstSelectionInnerOptions.Select();

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
                    firstSelectionMain.Select();
                    MainPanel.SetActive(true);

                    OptionsPanel.GetComponent<FadeIn>().shouldFadeOut = true;
                    OptionsPanel.GetComponent<FadeIn>().shouldFadeIn = false;
                    MainPanel.GetComponent<FadeIn>().shouldFadeIn = true;
                    MainPanel.GetComponent<FadeIn>().shouldFadeOut = false;

                    break;
                }
            case 2:
                {
                    firstSelectionInnerOptions.Select();

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
        firstSelectionMain.Select();

        MainPanel.GetComponent<FadeIn>().shouldFadeIn = true;
        MainPanel.GetComponent<FadeIn>().shouldFadeOut = false;
        ExtrasPanel.GetComponent<FadeIn>().shouldFadeOut = true;
        ExtrasPanel.GetComponent<FadeIn>().shouldFadeIn = false;
    }
    public void OnCustomizationClicked()
    {
        mainExtraPanel.SetActive(false);
        customizationPanel.SetActive(true);
        if(PlayerPrefs.HasKey("rAngel"))
        {
            colorAngel.color = SCR_CustomizationColor.colorAngel;
            sldrRAngel.value = colorAngel.color.r;
            sldrGAngel.value = colorAngel.color.g;
            sldrBAngel.value = colorAngel.color.b;


            colorDemon.color = SCR_CustomizationColor.colorDemon;
            sldrRDemon.value = colorDemon.color.r;
            sldrGDemon.value = colorDemon.color.g;
            sldrBDemon.value = colorDemon.color.b;

        }
        else
        {
            colorAngel.color = Color.white;
            sldrRAngel.value = 1;
            sldrGAngel.value = 1;
            sldrBAngel.value = 1;

            colorDemon.color = Color.black;
            sldrRDemon.value = 0;
            sldrGDemon.value = 0;
            sldrBDemon.value = 0;
        }


    }
    #endregion

    #region Customization Functions
    public void OnBackClickedCustom()
    {
        firstSelectionExtras.Select();
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
    public void UpdateRedAngel()
    {
        colorAngel.color = new Color(sldrRAngel.value,sldrGAngel.value, sldrBAngel.value);
        
    }
    public void UpdateGreenAngel()
    {
        colorAngel.color = new Color(sldrRAngel.value, sldrGAngel.value, sldrBAngel.value);

    }
    public void UpdateBlueAngel()
    {
        colorAngel.color = new Color(sldrRAngel.value, sldrGAngel.value, sldrBAngel.value);

    }
    public void UpdateGreenDemon()
    {
        colorDemon.color = new Color(sldrRDemon.value, sldrGDemon.value, sldrBDemon.value);

    }
    public void UpdateBlueDemon()
    {
        colorDemon.color = new Color(sldrRDemon.value, sldrGDemon.value, sldrBDemon.value);

    }
    public void UpdateRedDemon()
    {
        colorDemon.color = new Color(sldrRDemon.value, sldrGDemon.value, sldrBDemon.value);

    }
    #endregion
}
