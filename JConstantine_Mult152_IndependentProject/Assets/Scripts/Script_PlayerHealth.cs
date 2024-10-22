using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerHealth : MonoBehaviour
{
    public float health = 10f;
    public float maxHealth = 10f;
    public float amount;
    public GameObject [] enemy;
    public GameManager gameManager;
    Animator animator;


    


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Ouch"))
        {
            print("WORKING");
            
        }

        if (health <= 1 && other.gameObject.CompareTag("Ouch"))
        {
            print("DEAD");
            transform.Translate(Vector3.back * 85 * Time.deltaTime);
            transform.Translate(Vector3.up * 15 * Time.deltaTime);
            Destroy(other.gameObject);
            gameManager.gameOver = true;
            animator.Play("Ouch");


        }
        else if (health > 1 && other.gameObject.CompareTag("Ouch"))
        {
            health--;
            transform.Translate( Vector3.back * 85 * Time.deltaTime);
            transform.Translate(Vector3.up * 15 * Time.deltaTime);
            Destroy(other.gameObject);
            animator.Play("Ouch");

        }
        if (other.gameObject.CompareTag("Health"))
        {
            float amount = Random.Range(1, 3);
            print(amount);
            health = amount + health;
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (health >= 1 && other.gameObject.CompareTag("Ouch")) 
        {
            print("PLAYER: "+ health);

        }
       
    }

}
