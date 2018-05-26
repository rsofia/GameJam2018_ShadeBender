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

    public AudioManager audioMngr;

    #region Main Panel Functions
    public void OnQuitGameClicked()
    {
        Application.Quit();
    }

    public void OnExtrasClicked()
    {
        ExtrasPanel.SetActive(true);
        MainPanel.GetComponent<FadeIn>().FadeOutUI();
        ExtrasPanel.GetComponent<FadeIn>().FadeInUI();
    }

    public void OnOptionsClicked()
    {
        OptionsPanel.SetActive(true);
        //MainPanel.GetComponent<FadeIn>().FadeOutUI();
        //OptionsPanel.GetComponent<FadeIn>().FadeInUI();
        MainPanel.GetComponent<FadeIn>().shouldFadeOut = true;
        OptionsPanel.GetComponent<FadeIn>().shouldFadeIn = true;
        OptionsMainPanel.SetActive(true);
        optionsLevelMenu = 1;
    }

    public void OnStartGameClicked()
    {

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
                    MainPanel.GetComponent<FadeIn>().shouldFadeIn = true;

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
        ExtrasPanel.GetComponent<FadeIn>().shouldFadeOut = true;
        MainPanel.GetComponent<FadeIn>().shouldFadeIn = true;
    }
    #endregion
}
