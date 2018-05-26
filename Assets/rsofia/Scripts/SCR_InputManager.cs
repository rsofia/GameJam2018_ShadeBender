using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_InputManager : MonoBehaviour {

    public SCR_Player player;

    private void Start()
    {
        if (player == null)
            player = FindObjectOfType<SCR_Player>();
    }

    private void Update ()
    {
        player.Move(Input.GetAxis("Horizontal"));
        player.LimitVelocity();
        Debug.DrawRay(player.piesPersonaje.position, Vector3.down);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            player.Jump();
        }

        if (Input.GetKeyDown(KeyCode.S))
            player.InvertColor();
	}
}
