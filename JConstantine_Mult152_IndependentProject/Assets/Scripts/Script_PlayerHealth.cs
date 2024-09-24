using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerHealth : MonoBehaviour
{
    public float health = 10f;
    public float maxHealth = 10f;
    public GameObject [] enemy;
    


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider enemy)
    {

        if (health <= 1)
        {
            print("DEAD");
            transform.Translate(Vector3.right * 85 * Time.deltaTime);
            transform.Translate(Vector3.up * 15 * Time.deltaTime);
        }
        else if (health > 1)
        {
            health = health - 1f;
            transform.Translate( Vector3.right * 85 * Time.deltaTime);
            transform.Translate(Vector3.up * 15 * Time.deltaTime);
        }
    }
    private void OnTriggerExit(Collider enemy)
    {
        if (health >= 1) 
        {
            print("PLAYER: "+ health);
        }
    }

}
