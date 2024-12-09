using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Player movement speed unit
    private float playerSpeed = 10f;
    public GameObject player;

    //Jump Timer
    public float buttonTime = 0.3f;
    private bool onGround = true;

    public float jumpForce;


    // Gets inputs from engine
    private float horizontalInput;
    private float verticalInput;
    private float jumpInput;

    //Rolling related
    private float rollTime;
    private bool rolling;
    private float rollButton = 0.15f;
    public float rollForce;

    //Camera stuff
    public float camSpeed = 1000f;
    public float xPos;

    //Animation
    Animator animator;

    //RigidBody
    private Rigidbody rbPlayer;

    //sound
    public AudioClip boing;
    public AudioClip swoosh;
    public AudioSource audioSource;
    public float volume = 0.5f;

    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {


        // Sets up inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        jumpInput = Input.GetAxis("Jump");
        xPos = Input.GetAxis("Mouse X");

        // Forward motion
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed * verticalInput );
        // Strafe motion
        transform.Translate(Vector3.right *  Time.deltaTime * playerSpeed * horizontalInput );
        // Player Rotation
        transform.Rotate(Vector3.up * Time.deltaTime * xPos * camSpeed / 2);

        //New Jump
        bool spaceDown = Input.GetButtonDown("Jump");
        if (spaceDown && onGround)
        {
            rbPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
            audioSource.PlayOneShot(boing, volume);
        }

        //Dodge roll
        if (Input.GetKeyDown("left shift"))
        {
                rolling = true;
                rollTime = 0;
            audioSource.PlayOneShot( swoosh, volume);
                
        }
    if (rolling)
        {
            rollTime += Time.deltaTime;
            rbPlayer.AddRelativeForce(Vector3.forward * Time.deltaTime * rollForce * verticalInput * 3, ForceMode.VelocityChange);
            rbPlayer.AddRelativeForce(Vector3.right * Time.deltaTime * rollForce * horizontalInput * 3, ForceMode.VelocityChange);
        }
    if (Input.GetKeyUp("left shift")  |  rollTime > rollButton) 
        {
        rolling = false;
        }

    if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Shoot", true);
        }
else
        {
            animator.SetBool("Shoot", false);
        }
        //Animate
        animator.SetFloat("Forward", verticalInput);
        animator.SetFloat("Sideways", horizontalInput);
        animator.SetFloat("Jumping", jumpInput);
        animator.SetBool("OnGround", onGround);
        animator.SetBool("Dash", rolling);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        
        if(collision.gameObject.CompareTag("Collision"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * playerSpeed * verticalInput);
        }

    }

}
