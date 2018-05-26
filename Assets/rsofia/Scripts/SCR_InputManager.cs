﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_InputManager : MonoBehaviour {

    public SCR_Player player;
    public SCR_Pause pause;
    public bool isPaused = false;
    public Animator playerAnim;

    private void Start()
    {
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
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                playerAnim.SetBool("Jump", true);
                player.Jump();
            }

            if (Input.GetKeyDown(KeyCode.S))
                player.InvertColor();

            if(Input.GetKeyDown(KeyCode.JoystickButton7))
            {
                pause.PauseGame();
            }

            if(Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                playerAnim.SetTrigger("Dash");
                player.Dash();
            }
        }
       
	}
}
