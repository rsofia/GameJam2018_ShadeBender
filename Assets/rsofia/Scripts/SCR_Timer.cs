﻿//-----------------------------------------------------------------------------
// Copyright 2017-2018 Golstats Todos los derechos reservados
// V1	luisbernardo@golstats.com	Luis Bazan     git-user: luisquid11
//----------------------------------------------------------------------------- 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_Timer : MonoBehaviour {

	public SCR_Player player;
    public Text txtTimerColor;
    public Text txtTimerTotal;
    [HideInInspector]
    public float timeColor = 15;
    [HideInInspector]
    public float totalLevelTime = 0;

    [HideInInspector]
    public bool isPaused = false;

    private void Start()
    {
        if (player == null)
            player = FindObjectOfType<SCR_Player>();
        timeColor = SCR_Level.tiempoACambiar;
    }

    private void Update()
    {
        if(!isPaused)
        {
            timeColor -= Time.deltaTime;
            totalLevelTime += Time.deltaTime;
            if (timeColor <= 0.0f)
            {
                timeColor = SCR_Level.tiempoACambiar;
                player.InvertColor();
            }
            txtTimerColor.text = (timeColor / 60).ToString("00") + ":" + (timeColor % 60).ToString("00");
            txtTimerTotal.text = (totalLevelTime / 60).ToString("00") + ":" + (totalLevelTime % 60).ToString("00");
        }
        
    }

    public void SetTimer(float _seconds)
    {
        timeColor = _seconds;
    }
}
