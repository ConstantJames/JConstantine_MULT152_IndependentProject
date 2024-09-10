using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Script_CameraControl : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset = new Vector3 (3, 1, 0);
    public float camSpeed = 100f;
    public float xPos;
    public float yPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xPos = Input.GetAxis("Mouse X");
        yPos = Input.GetAxis("Mouse Y");

        transform.position = player.transform.position + offset;
        transform.Rotate(Vector3.up * Time.deltaTime * xPos * camSpeed);
        transform.Rotate(Vector3.left * Time.deltaTime * yPos * camSpeed);
    }
}
