using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Weapon2 : MonoBehaviour
{

    public GameObject projectile;
    public float launchVelocity = 1400f;
    public GameManager gameManager;
    private bool gameOver;
    public AudioClip pew;
    public AudioSource audioSource;
    public float volume = 0.5f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameOver = GameObject.Find("GameManager").GetComponent<GameManager>().gameOver;
        if (Input.GetButtonDown("Fire1"))
        {
            if (!gameOver)
            {
                GameObject blast = Instantiate(projectile, transform.position, transform.rotation);
                blast.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 90, launchVelocity));
                GameObject blast2 = Instantiate(projectile, transform.position, transform.rotation);
                blast2.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(30, 180, launchVelocity));
                GameObject blast3 = Instantiate(projectile, transform.position, transform.rotation);
                blast3.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-30, 180, launchVelocity));

                Destroy(blast, 1);
                Destroy(blast2, 1);
                Destroy(blast3, 1);
                print("BANG");
                audioSource.PlayOneShot(pew, volume);
            }
        }

    }

}
