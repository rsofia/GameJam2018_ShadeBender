using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class SCR_Player : MonoBehaviour {

    [Header("Movement")]
    private Rigidbody myRigidbody;
    private float speed = 50;
    private float standardLimit = 5;
    private Vector2 limitVelocity = new Vector2(5, 10);
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
    }
    
    #region MOVEMENT
    public void Move(float _direction)
    {
        myRigidbody.AddForce(Vector3.right * _direction * speed);
        LimitVelocity();
    }

    public void Dash()
    {
        if(canApplyDash)
        {
            Debug.Log("Velocity: " + myRigidbody.velocity);
            float direction = 1;
            if (myRigidbody.velocity.x < 0)
                direction = -1;
            myRigidbody.AddForce(Vector3.right * dashForce * direction);
            limitVelocity.x = tempLimitDash;
            StartCoroutine(WaitToResetDash());
        }
        
    }

    IEnumerator WaitToResetDash()
    {
        canApplyDash = false;
        yield return new WaitForSeconds(dashCooldown);
        myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y);
        limitVelocity.x = standardLimit;
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
        if(!isPaused)
        {
            switch (collision.gameObject.tag)
            {
                case "Enemy":
                    {
                        if (collision.gameObject.GetComponent<SCR_Enemy>() != null)
                        {
                            collision.gameObject.GetComponent<SCR_Enemy>().PlaySound();
                            RestHealth(collision.gameObject.GetComponent<SCR_Enemy>().damage);
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
                        if(!isPaused)
                            GameWon();
                    }
                    break;
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
                    other.GetComponent<SCR_EmitSound>().PlaySound();
                    RestHealth(1);
                }
                break;
            default:
                break;
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
        FinishLevel(lostMenu.transform);
        lostMenu.SetActive(true);
    }
    public void GameWon()
    {
        Debug.Log("Game won");
        FinishLevel(winMenu.transform);
        winMenu.SetActive(true);
    }

    private void FinishLevel(Transform _menu)
    {
        FindObjectOfType<SCR_Pause>().PauseGame(false);
        _menu.Find("TXT_Puntaje").GetComponent<Text>().text = "Final Score: " + CalculateFinalScore();

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

        if (timer.totalLevelTime <= levelProperties.estimatedTimeInSeconds / 3)
            extraScore += (100/ timer.totalLevelTime) * 100;
        else if (timer.totalLevelTime <= levelProperties.estimatedTimeInSeconds / 2)
            extraScore += (50 / timer.totalLevelTime) * 100;
        else if (timer.totalLevelTime <= levelProperties.estimatedTimeInSeconds)
            extraScore += (25 / timer.totalLevelTime) * 100;
        extraScore = Mathf.RoundToInt(extraScore);
        result = (score + extraScore).ToString();
        result = result + " \n Time:" + timer.totalLevelTime;
        return result;

    }
    #endregion
}
