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

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PlayerInRange", 2, 3);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        print("In range");

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerPos = playerTarget.transform.position;
            transform.LookAt(playerPos);
            fire = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        fire = false;
    }

    void PlayerInRange()
    {
        if (fire == true)
        {
            GameObject blast = Instantiate(enemyProjectile, transform.position, transform.rotation);
            blast.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,200, launchVelocity));
            Destroy(blast, 1);
            count++;
        }
    }


}
