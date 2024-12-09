using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class Script_EnemyHealth : MonoBehaviour
{

    public int eHealth = 4;
    public int sHealth;
    public GameObject aimingPart;
    public GameObject healthPickup;
    Animator animator;

    public AudioClip slime;
    public AudioSource audioSource;
    public float volume = 0.5f;
    public bool safety = false;
    public bool gameOverCheck;
    public int rCount;
    GameManager gameManager;
    private bool fireSafety;
    private bool firstVisit = false;


    // Start is called before the first frame update
    void Start()
    {
        sHealth = eHealth;
        animator = GetComponent<Animator>();
        gameManager = GetComponent<GameManager>();
        rCount = 1;
    }

    // Update is called once per frame
    void Update()
    {

        gameOverCheck = GameObject.Find("GameManager").GetComponent<GameManager>().gameOver;
        rCount = GameObject.Find("GameManager").GetComponent<GameManager>().repeatCount;
        if (gameOverCheck == true)
        {
            animator.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (firstVisit == false)
        {
            firstVisit = true;
            eHealth = sHealth * rCount;
        }
        
        if (other.gameObject.CompareTag("Projectile") && eHealth > 1)
        {
            eHealth--;
            print(eHealth);
            Destroy(other.gameObject);
            animator.Play("Hit");
            audioSource.PlayOneShot(slime, volume);
        }
        else if (other.gameObject.CompareTag("Projectile") && eHealth <= 1)
        {
            animator.Play("Hit");
            audioSource.PlayOneShot(slime, volume);

            if (safety == false)
            {
                print("DEAD");
                Destroy(other.gameObject);
                Destroy(gameObject);
                Destroy(aimingPart);
                HealthSpawn();
                firstVisit = false;

            }

        }
        else
        {
            print("Whoops");
        }
    }
    private void HealthSpawn()
    {
        healthPickup = Instantiate(healthPickup, transform.position, transform.rotation);

    }

}
