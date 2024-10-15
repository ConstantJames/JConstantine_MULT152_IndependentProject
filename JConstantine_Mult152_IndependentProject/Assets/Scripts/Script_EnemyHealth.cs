using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_EnemyHealth : MonoBehaviour
{

    public int eHealth = 4;
    public GameObject aimingPart;
    public GameObject healthPickup;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        eHealth = 4;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile") && eHealth >= 1)
        {
            eHealth--;
            print(eHealth);
            Destroy(other.gameObject);
            print(GetComponent<Collider>());
            animator.Play("Hit");
        }
        else if (other.gameObject.CompareTag("Projectile") && eHealth <= 1)
        {
            print("DEAD");
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(aimingPart);
            HealthSpawn();
            animator.Play("Hit");

        }
        else
        {
            print("Whoops");
        }
    }
    private void HealthSpawn()
    {
       healthPickup = Instantiate(healthPickup, transform.position , transform.rotation );
    }

}
