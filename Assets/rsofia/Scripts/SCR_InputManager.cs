﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_InputManager : MonoBehaviour {

    public SCR_Player player;
    public SCR_Pause pause;
    public bool isPaused = false;
    public Animator playerAnim;
    public static bool isLevelDone;

    private void Start()
    {
        isLevelDone = false;
        if (player == null)
            player = FindObjectOfType<SCR_Player>();
        if (pause == null)
            pause = FindObjectOfType<SCR_Pause>();

        playerAnim = GetComponentInChildren<Animator>();
        
    }

    private void Update ()
    {
        if(!isPaused)
        {
            player.Move(Input.GetAxis("Horizontal"));
            playerAnim.SetFloat("PlayerVelocity", System.Math.Abs(Input.GetAxis("Horizontal")));
            player.LimitVelocity();
            Debug.DrawRay(player.piesPersonaje.position, Vector3.down);

            if(Input.GetJoystickNames().Length > 0)
            {
                if (Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    playerAnim.SetBool("Jump", true);
                    player.Jump();
                }

                if (Input.GetKeyDown(KeyCode.JoystickButton7))
                {
                    pause.PauseGame();
                }

                if (Input.GetKeyDown(KeyCode.JoystickButton1) && !isLevelDone)
                {
                    playerAnim.SetTrigger("Dash");
                    player.Dash();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    playerAnim.SetBool("Jump", true);
                    player.Jump();
                }

                if (Input.GetKeyDown(KeyCode.P))
                {
                    pause.PauseGame();
                }

                if (Input.GetKeyDown(KeyCode.H))
                {
                    playerAnim.SetTrigger("Dash");
                    player.Dash();
                }
            }


            
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1) && isLevelDone)
        {
            Debug.Log("I am here");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
        }

    }
}
