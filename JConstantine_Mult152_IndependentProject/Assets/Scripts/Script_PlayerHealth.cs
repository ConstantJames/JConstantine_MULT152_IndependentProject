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
    private Animator animator;
    


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
        if (gameManager.gameOver == true)
        {
            animator.SetBool("Dead", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Ouch"))
        {
            print("WORKING");
            gameManager.UpdateHealthHUD(health);
        }

        if (health <= 1 && other.gameObject.CompareTag("Ouch"))
        {
            print("DEAD");
            Destroy(other.gameObject);
            gameManager.gameOver = true;
            animator.Play("Dead");
            gameManager.UpdateHealthHUD(health);

        }
        else if (health > 1 && other.gameObject.CompareTag("Ouch"))
        {
            health--;
            Destroy(other.gameObject);
            animator.Play("Ouch");
            gameManager.UpdateHealthHUD(health);
            print("DAMAGED");
        }
        if (other.gameObject.CompareTag("Health"))
        {
            float amount = Random.Range(1, 3);
            print(amount);
            health = amount + health;
            Destroy(other.gameObject);
            gameManager.UpdateHealthHUD(health);
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
