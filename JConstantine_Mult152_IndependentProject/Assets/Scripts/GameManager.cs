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
    bool ouch;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GameObject.Find("Player_Wiz").GetComponent<PlayerController>();
        gameOver = false;
        playerHealth = GameObject.Find("Player_Wiz").GetComponent<Script_PlayerHealth>().health;
        ouch = GameObject.Find("Player_Wiz").GetComponent<Animator>().GetBool("Ouch");
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = GameObject.Find("Player_Wiz").GetComponent<Script_PlayerHealth>().health;

        if (playerHealth <= 1)
        {
            gameOver = true;
            GameOver();
        }
        if (ouch == true) 
        {
           playerAnimator = playerCtrl.GetComponent<Animator>();
            playerAnimator.Play("Ouch");
        }
    }
    void GameOver()
    {
        enemy.GetComponent<Script_EnemyAim>().enabled = false;

       //Player Disable
        GameObject.Find("Player_Wiz").GetComponent<PlayerController>().enabled = false;
    }
}
