﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class SCR_Player : MonoBehaviour {

    [Header("Movement")]
    private Rigidbody myRigidbody;
    private float speed = 20;
    private Vector2 limitVelocity = new Vector2(15, 15);

    [Header("Jump")]
    [Tooltip("La poscicion (centro) de los pies del personaje para checar si tocan el suelo")]
    public Transform piesPersonaje;
    private string floorTag = "Floor";
    private bool isGrounded = false;
    private float jumpForce = 450;
    private float distanceToJump = 1;
    RaycastHit hit;

    [Header("Colors")]
    public bool isWhite = true;
    public Renderer myRenderer;
    public Material matWhite;
    public Material matBlack;
    public LayerMask maskToInteract;

    [Header("Health")]
    public List<Image> imgHealth = new List<Image>();
    private int healthPoints = 3;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        if (myRenderer == null)
            myRenderer = GetComponent<Renderer>();
        AssignRandomColor();
    }

    #region MOVEMENT
    public void Move(float _direction)
    {
        myRigidbody.AddForce(Vector3.right * _direction * speed);
        LimitVelocity();
    }

    public void LimitVelocity()
    {
        if (myRigidbody.velocity.x > limitVelocity.x)
            myRigidbody.velocity = new Vector3(limitVelocity.x, myRigidbody.velocity.y);
        else if(myRigidbody.velocity.x < -limitVelocity.x)
            myRigidbody.velocity = new Vector3(-limitVelocity.x, myRigidbody.velocity.y);

        if (myRigidbody.velocity.y > limitVelocity.y)
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, limitVelocity.y);
        else if (myRigidbody.velocity.y < -limitVelocity.y)
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, -limitVelocity.y);
    }

    public void Jump()
    {
        if(CanPlayerJump())
        {
            myRigidbody.AddForce(new Vector3(0, jumpForce));
        }
    }

    private bool CanPlayerJump()
    {
        isGrounded = false;
        if(Physics.Raycast(piesPersonaje.position, Vector3.down, out hit, distanceToJump))
        {
            isGrounded = hit.collider.tag == floorTag;
        }
        return isGrounded;
    }
    #endregion

    #region COLOR HANDLING
    public void AssignColor(bool _col)
    {
        //Stop ignoring previous collision
        Physics.IgnoreLayerCollision(0, (int)Mathf.Log(maskToInteract.value, 2), false);

        isWhite = _col;
        myRenderer.material = isWhite ? matWhite : matBlack;
        if (isWhite)
            maskToInteract = LayerMask.GetMask("Angel");
        else
            maskToInteract = LayerMask.GetMask("Demon");
        Physics.IgnoreLayerCollision(0, (int)Mathf.Log(maskToInteract.value, 2));
    }
    public void AssignRandomColor()
    {
        int random = Random.Range(0, 10);
        isWhite = random < 5 ? true : false;
        AssignColor(isWhite);
    }
    public void InvertColor()
    {
        AssignColor(!isWhite);
    }
    #endregion

    #region COLLISION DETECTION
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if(collision.gameObject.GetComponent<SCR_Enemy>() != null)
            {
                RestHealth(collision.gameObject.GetComponent<SCR_Enemy>().damage);
            }
        }
    }
    #endregion

    #region HEALTH
    public void AddHealth(int _healthAdded)
    {
        healthPoints += _healthAdded;
        DisplayHealth();
    }
    public void RestHealth(int _healthToRest)
    {
        healthPoints -= _healthToRest;
        if (healthPoints <= 0)
            GameOver();
        DisplayHealth();
    }
    private void DisplayHealth()
    {
        foreach (Image img in imgHealth)
        {
            img.gameObject.SetActive(false);
        }
        for(int i = 0; i < imgHealth.Count; i++)
        {
            if (i < healthPoints)
                imgHealth[i].gameObject.SetActive(true);
            else
            {
                imgHealth.RemoveAt(i);
            }
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
    #endregion
}
