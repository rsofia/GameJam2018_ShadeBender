using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_InputManager : MonoBehaviour {

    public SCR_Player player;
    public SCR_Pause pause;
    public bool isPaused = false;

    private void Start()
    {
        if (player == null)
            player = FindObjectOfType<SCR_Player>();
        if (pause == null)
            pause = FindObjectOfType<SCR_Pause>();
    }

    private void Update ()
    {
        if(!isPaused)
        {
            player.Move(Input.GetAxis("Horizontal"));
            player.LimitVelocity();
            Debug.DrawRay(player.piesPersonaje.position, Vector3.down);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.Jump();
            }

            if (Input.GetKeyDown(KeyCode.S))
                player.InvertColor();

            if(Input.GetKeyDown(KeyCode.P))
            {
                pause.PauseGame();
            }
        }
       
	}
}
