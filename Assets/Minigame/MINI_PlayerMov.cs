using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]
public class MINI_PlayerMov : MonoBehaviour {

    private Rigidbody myRigidbody;
    public Animator anim;
    private float speed = 5;
    private bool isAlive = true;

    public GameObject gameOverMenu;
    public GameObject gameWonMenu;
    public GameObject child;
    [Header("Jump")]
    [Tooltip("La poscicion (centro) de los pies del personaje para checar si tocan el suelo")]
    public Transform piesPersonaje;
    private string floorTag = "Floor";
    private bool isGrounded = false;
    bool isRooted=false;
    private float jumpForce = 450;
    private float distanceToJump = 1;
    private float limitVelocity = 10;
    RaycastHit hit;

    AudioSource aSrc;
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        aSrc = GetComponent<AudioSource>();
        gameWonMenu.SetActive(false);
        gameOverMenu.SetActive(false);

    }

    void Update () {

        if (isAlive)
        {
            child.transform.localPosition = Vector3.zero;
            if (Physics.Raycast(piesPersonaje.position, Vector3.down, out hit, distanceToJump))
            {
                isRooted = hit.collider.tag == floorTag;
                anim.SetBool("isRooted",false);
            }
            else
            {
                anim.SetBool("isRooted", true);

            }
            if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Jump", true);
                aSrc.Play();
                Jump();
            }
            
            if(Input.GetKeyDown(KeyCode.JoystickButton7))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
            }

            //Move automatically
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            speed += Time.deltaTime/10;
            LimitVelocity();
        }
        
    }

    public void LimitVelocity()
    {
        if (myRigidbody.velocity.y > limitVelocity)
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, limitVelocity);
        else if (myRigidbody.velocity.y < -limitVelocity)
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, -limitVelocity);
    }

    public void Jump()
    {
        if (CanPlayerJump())
        {
            anim.SetTrigger("Jump");
            anim.SetBool("isRooted", false);
            myRigidbody.AddForce(new Vector3(0, jumpForce));
        }
    }

    private bool CanPlayerJump()
    {
        isGrounded = false;

        if (Physics.Raycast(piesPersonaje.position, Vector3.down, out hit, distanceToJump))
        {
            isGrounded = hit.collider.tag == floorTag;
        }

        return isGrounded;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            //Game Over
            anim.SetTrigger("hasDied");
            isAlive = false;
            other.GetComponent<SCR_EmitSound>().PlaySound();
            StartCoroutine(WaitToShowGameOver());
        }
        else if(other.tag == "Goal")
        {
            isAlive = false;
            other.GetComponent<SCR_EmitSound>().PlaySound();
            gameWonMenu.SetActive(true);
            gameWonMenu.GetComponentInChildren<Button>().Select();
        }
       if(other.tag == "EasterEgg")
        {
            Debug.Log("At easter egg");
            anim.SetTrigger("easterEgg");
            StartCoroutine(WaitToShowEasterEgg(other.transform));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Limite")
        {
            isAlive = false;
            anim.SetTrigger("Falling");
        }
    }

    IEnumerator WaitToShowGameOver()
    {
        yield return new WaitForSeconds(1.0f);
        gameOverMenu.SetActive(true);
        gameOverMenu.GetComponentInChildren<Button>().Select();

    }

    IEnumerator WaitToShowEasterEgg(Transform _easterEgg)
    {
        yield return new WaitForSeconds(2);
        _easterEgg.Find("Canvas").gameObject.SetActive(true);
        _easterEgg.Find("Canvas").gameObject.GetComponentInChildren<Button>().Select();

    }
}
