using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameObject projectile;
    public GameObject player;
    public int enemyHealth = 4;

    public void Start()
    {
        enemyHealth = 4;
    }

    private void OnTriggerExit(Collider projectile)
    {

        if (enemyHealth <= 1)
            {
                Destroy(gameObject);
                print("Enemy Dead");
            }
            else if (enemyHealth > 1)
            {

            Damage();
                print("ENEMY: " + enemyHealth);
            }

    }

    void Damage()
    {
        enemyHealth--;
    }
}
