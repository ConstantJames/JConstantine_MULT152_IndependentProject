using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool gameOver = false;
    public GameObject player;
    public GameObject enemy;
    private PlayerController playerCtrl;
    private Animator playerAnimator;
    private float playerHealth;
    private GameObject walls;
    private int enemyCount;
    public Light dirLight;
    public bool repeatUnlock = false;
    private int collectCount = 0;
    
    public int sEnemyHealth = 4;
    public int nEnemyHealth;
    public GameObject enemyPrefab;
    private GameObject scrolls;
    private GameObject portal;
    public int repeatCount;
    public bool repeatOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerController>();
        gameOver = false;
        playerHealth = GameObject.Find("Player").GetComponent<Script_PlayerHealth>().health;
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        walls = GameObject.Find("MagicDoors");
        
        portal = GameObject.Find("RepeatPortal");
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = GameObject.Find("Player").GetComponent<Script_PlayerHealth>().health;
        enemyCount = FindObjectsOfType<Script_EnemyHealth>().Length;
        collectCount = FindObjectsOfType<Collect>().Length;
        repeatCount = portal.GetComponent<script_LevelReset>().numRepeat;
        if (playerHealth <= 1)
        {
            gameOver = true;
            GameOver();
        }
        if (collectCount <1)
        {
            repeatUnlock = true;
            portal.GetComponent<script_LevelReset>().active = true;
        }

        if (repeatCount >=2 && repeatUnlock == true && repeatOnce == false)
        {
            repeatOnce = true;
        }
    }
    void GameOver()
    {
        enemy.GetComponent<Script_EnemyAim>().enabled = false;

        //Player Disable
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        

    }

    public void Repeat(int repeatCount)
    {
                
        if ( repeatUnlock == true)
        {
            repeatCount++;
            dirLight.colorTemperature = 20000.0f;

            print(repeatCount + "Repeat Works");

            FindObjectOfType<Script_EnemyHealth>().HealthUpdate();
            
        }

    }
}
