using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Pause : MonoBehaviour {

    public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void PauseGame()
    {
        FindObjectOfType<SCR_Timer>().isPaused = true;
        FindObjectOfType<SCR_InputManager>().isPaused = true;
        FindObjectOfType<SCR_Player>().isPaused = true;
        pauseMenu.SetActive(true);
        LeanTween.pauseAll();
    }

    public void ResumeGame()
    {
        FindObjectOfType<SCR_Timer>().isPaused = false;
        FindObjectOfType<SCR_InputManager>().isPaused = false;
        FindObjectOfType<SCR_Player>().isPaused = false;
        pauseMenu.SetActive(false);
        LeanTween.resumeAll();
    }

    public void ExitLevel()
    {
        Debug.Log("Aqui regresar al menu de inicio");
    }
}
