using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_EnemyAim : MonoBehaviour
{

    public GameObject playerTarget;
    public GameObject enemyProjectile;
    public Vector3 playerPos;
    public float launchVelocity = 1000.0f;
    private int count = 0;
    public bool fire = false;
    public GameObject range;
    Animator animator;
    private float playerHealth;
    GameManager gameManager;
    public GameObject body;
    public int health;


    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("SlimeMesh").GetComponent<Animator>();
        playerHealth = 10.0f;
        animator = body.GetComponent<Animator>();
        health = GameObject.Find("SlimeMesh").GetComponent<Script_EnemyHealth>().eHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        print("In range");

       playerHealth = GameObject.Find("Player").GetComponent<Script_PlayerHealth>().health;
        animator = body.GetComponent<Animator>();

        if (other.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("PlayerInRange", 1, 3);
            fire = true;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        playerHealth = GameObject.Find("Player").GetComponent<Script_PlayerHealth>().health;

        if (other.gameObject.CompareTag("Player"))
        {
            playerPos = other.gameObject.transform.position;
            transform.LookAt(playerPos);
            fire = true;
        }
        if(playerHealth <= 1)
        {
            Stopping();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        fire = false;
        CancelInvoke("PlayerInRange");
    }

    void PlayerInRange()
    {
        if (fire == true)
        {
            GameObject blast = Instantiate(enemyProjectile, transform.position, transform.rotation);
            blast.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 350, launchVelocity));
            Destroy(blast, 1);
            count++;
            animator.Play("Attack");
        }
    }
    public void Stopping()
    {
        CancelInvoke("PlayerInRange");
    }

}
