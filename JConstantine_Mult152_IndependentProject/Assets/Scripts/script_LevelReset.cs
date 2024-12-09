using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_LevelReset : MonoBehaviour
{
    public GameObject[] enemies; // Array to hold all enemy prefabs
    public Transform player; // Reference to the player
    public Vector3 playerStartPosition; // Player's starting position
    public Quaternion playerStartRotation;
    public GameObject[] objectsToEnable; // Array of objects to enable
    public GameManager gameManager;
    public bool active = false;
    public int numRepeat = 1;
    public GameObject health;
    public int startEnHealth = 4;
    public GameObject enemyPrefab;
    public int enNewHealth;
    public GameObject waveMan;
    void Start()
    {
        // Store the player's starting position
        playerStartPosition = player.position;
        playerStartRotation = player.transform.rotation;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

    private void Update()
    {

    }

    public void ResetLevel()
    {
        // Respawn all destroyed enemies

        foreach (GameObject obj in enemies)
        {
            Instantiate(enemyPrefab, obj.transform.position, obj.transform.rotation);

        }

        // Place the player back at the start
        player.position = playerStartPosition;
        player.transform.rotation = playerStartRotation;
        //Keeps track of repeats
       
        numRepeat++;

        gameManager.Repeat(numRepeat);
        enNewHealth = startEnHealth * numRepeat;
        waveMan.GetComponent<Script_EnemyWaves>().firstTime = false;
        waveMan.GetComponent<Script_EnemyWaves>().waveNum = 0;
        gameManager.StartGame();
        // Enable all objects that were disabled at the start
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager = gameManager.GetComponent<GameManager>();
        if ( other.gameObject.CompareTag("Player") &&  active == true)
        {
            if (numRepeat <= 1)
            {
                gameManager.VictoryScreen();
            }
            else
            {
                ResetLevel();
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            gameManager.middleScreenText.text = "Find all 3 scrolls to use the portal.";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameManager.middleScreenText.text = "";
    }

}
