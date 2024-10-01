using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_EnemyHealth : MonoBehaviour
{

    public int eHealth = 4;
    public GameObject aimingPart;
    public GameObject healthPickup;


    // Start is called before the first frame update
    void Start()
    {
        eHealth = 4;
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
        }
        else if (other.gameObject.CompareTag("Projectile") && eHealth <= 1)
        {
            print("DEAD");
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(aimingPart);
            HealthSpawn();
            
        }
        else
        {
            print("Whoops");
        }
    }
    private void HealthSpawn()
    {
       healthPickup = Instantiate(healthPickup, transform.position, transform.rotation );
    }
}
