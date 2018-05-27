using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_Scenes : MonoBehaviour {

	public void GoToMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMiniGame()
    {
        SceneManager.LoadScene("MiniGame");
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("SCN_Nivel_0");
    }
}
