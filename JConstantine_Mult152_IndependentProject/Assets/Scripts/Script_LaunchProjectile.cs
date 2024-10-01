using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_LaunchProjectile : MonoBehaviour
{

    public GameObject projectile;
    public float launchVelocity = 2500f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject blast = Instantiate(projectile, transform.position, transform.rotation);
            blast.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, 30, launchVelocity));
            Destroy(blast, 2);
            print("PEW");
        }

    }

}
