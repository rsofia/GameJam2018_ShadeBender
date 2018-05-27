using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SCR_Pause : MonoBehaviour {

    public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void PauseGame(bool _showPause = true)
    {
        FindObjectOfType<SCR_Timer>().isPaused = true;
        FindObjectOfType<SCR_InputManager>().isPaused = true;
        FindObjectOfType<SCR_Player>().isPaused = true;
        if (_showPause)
        {
            pauseMenu.SetActive(true);
            pauseMenu.GetComponentInChildren<Button>().Select();
            Debug.Log("Button selecte!");
        }
        LeanTween.pauseAll();
    }

    public void ResumeGame()
    {
        FindObjectOfType<SCR_Timer>().isPaused = false;
        FindObjectOfType<SCR_InputManager>().isPaused = false;
        FindObjectOfType<SCR_Player>().isPaused = false;
        pauseMenu.SetActive(false);
        if(SCR_Level.lerpEnemies)
            LeanTween.resumeAll();
    }

    public void ExitLevel()
    {
        //Load main menu
        SceneManager.LoadScene(1);
    }
}
