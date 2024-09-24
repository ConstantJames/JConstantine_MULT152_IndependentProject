using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class Script_PlayerMovement : MonoBehaviour
{

    // Player movement speed unit
    private float playerSpeed = 10f;
    public GameObject player;

    //Jump Timer
    public float buttonTime = 0.3f;
    private float jumpTime;
    private bool jumping;

    // Gets inputs from engine
    private float horizontalInput;
    private float verticalInput;
    private float jumpInput;

    //Rolling related
    private float rollTime;
    private bool rolling;
    private float rollButton = 0.15f;

    //Camera stuff
    public float camSpeed = 1000f;
    public float xPos;

    // Start is called before the first frame update
    void Start()
    {
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
        transform.Translate(Vector3.left * Time.deltaTime * playerSpeed * verticalInput );
        // Strafe motion
        transform.Translate(Vector3.forward *  Time.deltaTime * playerSpeed * horizontalInput );
        // Player Rotation
        transform.Rotate(Vector3.up * Time.deltaTime * xPos * camSpeed / 2);

        // Jump Timer Checks
        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;
            jumpTime = 0;
        }
        if(jumping)
        {
            jumpTime += Time.deltaTime;
            transform.Translate(Vector3.up * Time.deltaTime * playerSpeed * jumpInput );
        }
        if (Input.GetButtonUp("Jump") | jumpTime > buttonTime)
        {
            jumping = false;
        }

        //Dodge roll
    if (Input.GetKeyDown("left shift"))
        {
                rolling = true;
                rollTime = 0;
        }
    if (rolling)
        {
            rollTime += Time.deltaTime;
            transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed * horizontalInput * 3);
            transform.Translate(Vector3.left * Time.deltaTime * playerSpeed * verticalInput * 3);
        }
    if (Input.GetKeyUp("left shift")  |  rollTime > rollButton) 
        {
        rolling = false;
        }

    }
}
