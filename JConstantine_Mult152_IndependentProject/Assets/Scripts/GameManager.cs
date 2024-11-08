using System.Collections;
using System.Collections.Generic;
using System.Data;
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

    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerController>();
        gameOver = false;
        playerHealth = GameObject.Find("Player").GetComponent<Script_PlayerHealth>().health;
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        walls = GameObject.Find("MagicDoors");
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = GameObject.Find("Player").GetComponent<Script_PlayerHealth>().health;
        enemyCount = FindObjectsOfType<Script_EnemyHealth>().Length;

        if (playerHealth <= 1)
        {
            gameOver = true;
            GameOver();
        }
    }
    void GameOver()
    {
        enemy.GetComponent<Script_EnemyAim>().enabled = false;

       //Player Disable
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        
    }
}
