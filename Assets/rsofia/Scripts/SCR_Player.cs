using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class SCR_Player : MonoBehaviour {

    public GameObject playerMesh;

    [Header("Movement")]
    private Rigidbody myRigidbody;
    private float speed = 15;
    private float standardLimit = 2;
    private Vector2 limitVelocity = new Vector2(2, 8);
    private float dashForce = 750;
    private float tempLimitDash = 25;
    private bool canApplyDash = true;
    private float dashCooldown = 2;

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
    private bool canBeDamaged = true;

    [Header("Puntaje")]
    private float score;
    public Text txtScore;
    private SCR_Level levelProperties;
    private SCR_Timer timer;

    [HideInInspector]
    public bool isPaused = false;

    [Header("UI")]
    public GameObject winMenu;
    public GameObject lostMenu;
    public AudioClip gameOverSound;
    public AudioSource source;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        if (myRenderer == null)
            myRenderer = GetComponent<Renderer>();
        levelProperties = FindObjectOfType<SCR_Level>();
        timer = FindObjectOfType<SCR_Timer>();
        AssignRandomColor();

        winMenu.SetActive(false);
        lostMenu.SetActive(false);

        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
        source.loop = false;
    }

    #region MOVEMENT
    public void Move(float _direction)
    {
        if (myRigidbody == null)
            myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.AddForce(Vector3.right * _direction * speed);
        LimitVelocity();

        if (_direction != 0)
        {
            playerMesh.transform.rotation = Quaternion.LookRotation(Vector3.right * _direction);
            playerMesh.transform.localPosition = Vector3.zero;
        }
    }

    public void Dash()
    {
        if(canApplyDash)
        {
            Debug.Log("Velocity: " + myRigidbody.velocity);
            float direction = 1;
            if (myRigidbody.velocity.x < 0)
                direction = -1;
            myRigidbody.AddForce(playerMesh.transform.right * dashForce * direction);
            limitVelocity.x = tempLimitDash;
            StartCoroutine(WaitToStopDash());
        }        
    }

    IEnumerator WaitToStopDash()
    {
        canApplyDash = false;
        yield return new WaitForSeconds(dashCooldown);
        myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y);
        limitVelocity.x = standardLimit;
        //Extra cooldown
        StartCoroutine(WaitToResetDash());
    }

    IEnumerator WaitToResetDash()
    {
        yield return new WaitForSeconds(0.5f);        
        canApplyDash = true;
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
            FindObjectOfType<SCR_InputManager>().playerAnim.SetBool("Jump", isGrounded);

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
        if (isWhite)
            myRenderer.material.SetColor("_Color", SCR_CustomizationColor.colorAngel);
        else
            myRenderer.material.SetColor("_Color", SCR_CustomizationColor.colorDemon);

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
        if(!isPaused)
        {
            switch (collision.gameObject.tag)
            {
                case "Enemy":
                    {
                        if (collision.gameObject.GetComponent<SCR_Enemy>() != null && canBeDamaged)
                        {
                            collision.gameObject.GetComponent<SCR_Enemy>().PlaySound();
                            RestHealth(collision.gameObject.GetComponent<SCR_Enemy>().damage);
                            StartCoroutine(WaitToDamageAgain());
                        }
                    }
                    break;
                case "Pickup":
                    {
                        SCR_Pickup temp = collision.gameObject.GetComponent<SCR_Pickup>();
                        if(temp.isAlive)
                        {
                            AddScore(temp.points);
                            temp.Pick();
                        }
                       
                    }
                    break;
                case "Goal":
                    {
                        if (!isPaused)
                        {
                            GameWon();
                            collision.gameObject.GetComponent<SCR_EmitSound>().PlaySound();
                        }
                    }
                    break;
                case "Floor":
                    {
                        if(isGrounded)
                        {
                            if (Physics.Raycast(piesPersonaje.position, Vector3.down, out hit, 5))
                            {
                                FindObjectOfType<SCR_InputManager>().playerAnim.SetBool("Jump", !isGrounded);
                            }
                        }
                        break;
                    }
                default:
                    break;
            }
        }
        
    }

    //Evitar usar trigger enter ya que puede causar problemas con ignore collision
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Hazard":
                {
                    if(canBeDamaged)
                    {
                        other.GetComponent<SCR_EmitSound>().PlaySound();
                        RestHealth(1);
                        StartCoroutine(WaitToDamageAgain());
                    }
                    
                }
                break;
            default:
                break;
        }
    }

    IEnumerator WaitToDamageAgain()
    {
        canBeDamaged = false;
        yield return new WaitForSeconds(0.45f);
        canBeDamaged = true;
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
        GetComponentInChildren<Animator>().SetTrigger("Dead");
        FinishLevel(lostMenu.transform);
        lostMenu.SetActive(true);
        source.clip = gameOverSound;
        source.Play();
    }
    public void GameWon()
    {
        Debug.Log("Game won");
        winMenu.SetActive(true);
        FinishLevel(winMenu.transform);
        FindObjectOfType<FileWriter>().WriteFile(SCR_Level.index);
    }

    private void FinishLevel(Transform _menu)
    {
        SCR_InputManager.isLevelDone = true;
        _menu.Find("TXT_Puntaje").GetComponent<Text>().text = CalculateFinalScore();
        FindObjectOfType<SCR_Pause>().PauseGame(false);
    }
    #endregion

    #region SCORE
    public void AddScore(float _score)
    {
        score += _score;
        DisplayScore();
    }
    private void DisplayScore()
    {
        txtScore.text = score.ToString();
    }
    private string CalculateFinalScore()
    {
        string result = "";
        float extraScore = 0;

        if (timer.totalLevelTime <= SCR_Level.estimatedTimeInSeconds / 3)
            extraScore += (100/ timer.totalLevelTime) * 100;
        else if (timer.totalLevelTime <= SCR_Level.estimatedTimeInSeconds / 2)
            extraScore += (50 / timer.totalLevelTime) * 100;
        else if (timer.totalLevelTime <= SCR_Level.estimatedTimeInSeconds)
            extraScore += (25 / timer.totalLevelTime) * 100;
        extraScore = Mathf.RoundToInt(extraScore);
        score += extraScore;
        result = score.ToString();
        result = result + " \n" + timer.totalLevelTime + "s";
        return result;

    }
    #endregion
}
