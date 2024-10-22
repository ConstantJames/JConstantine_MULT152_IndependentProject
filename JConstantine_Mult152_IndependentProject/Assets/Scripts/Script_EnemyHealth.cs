using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_EnemyHealth : MonoBehaviour
{

    public int eHealth = 4;
    public GameObject aimingPart;
    public GameObject healthPickup;
    Animator animator;

    public AudioClip slime;
    public AudioSource audioSource;
    public float volume = 0.5f;

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
            audioSource.PlayOneShot(slime, volume);
        }
        else if (other.gameObject.CompareTag("Projectile") && eHealth <= 1)
        {
            print("DEAD");
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(aimingPart);
            HealthSpawn();
            animator.Play("Hit");
            audioSource.PlayOneShot(slime, volume);
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
