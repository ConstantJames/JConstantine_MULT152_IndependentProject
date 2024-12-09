using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.InputSystem.Processors;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public bool gameOver = false;
    public GameObject player;
    public GameObject enemy;
    private PlayerController playerController;
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
    public int scrollMem = 0;
    private GameObject portal;
    public int repeatCount = 1;
    public bool repeatOnce = false;
    public bool menuSafety = false;
    public Scene activeScene;
    public GameObject launch1;
    public GameObject launch2;

    //UI Junk
    public GameObject quitButton;
    public GameObject startGameButton;
    public GameObject howToPlayButton;
    public GameObject backToTitleButton;
    public GameObject keepGoingButton;
    public GameObject wizardImage;
    public GameObject controlsImage;
    public GameObject backgroundUI;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scrollsText;
    public TextMeshProUGUI diedText;
    public TextMeshProUGUI middleScreenText;
    public TextMeshProUGUI loopText;




    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameOver = false;
        playerHealth = GameObject.Find("Player").GetComponent<Script_PlayerHealth>().health;
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        walls = GameObject.Find("MagicDoors");
        portal = GameObject.Find("RepeatPortal");
        
        UpdateHealthHUD(playerHealth);
        UpdateScrollsHUD(0);
        TitleScreen();
       UnityEngine. Cursor.lockState = CursorLockMode.Confined;
        UnityEngine.Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = GameObject.Find("Player").GetComponent<Script_PlayerHealth>().health;
        enemyCount = FindObjectsOfType<Script_EnemyHealth>().Length;
        collectCount = FindObjectsOfType<Collect>().Length;
        if (playerHealth <= 1)
        {
            gameOver = true;
            GameOver();
            if (menuSafety == false)
            {
                GameOverHUD();
            }
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
        if(enemyCount ==0)
        {
            walls.SetActive(false);
        }
    }
    void GameOver()
    {
        enemy.GetComponent<Script_EnemyAim>().enabled = false;
        //Player Disable
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        GameObject.Find("Player").GetComponent<Script_WeaponPicker>().ChangeWeapon(1);
        launch1.GetComponent<Script_LaunchProjectile>().enabled = false;
        launch2.GetComponent<Script_Weapon2>().enabled = false;
    }

    public void Repeat(int repeatCount)
    {
                
        if ( repeatUnlock == true)
        {
            repeatCount++;
            dirLight.colorTemperature = 20000.0f;

            print(repeatCount + "Repeat Works");
            loopText.text = "LOOP: " + (repeatCount);
            
        }


    }

    public void UpdateHealthHUD(float healthDelta)
    {
        playerHealth = healthDelta;
        if (playerHealth < 0)
        {
            playerHealth = 0;
        }
        if (playerHealth > 11)
        {
            playerHealth = 11;
        }
        healthText.text = "Health: " + (playerHealth-1);
        print(healthDelta + "HUDUPDATED");
    }

    public void UpdateScrollsHUD(int scrollAdd)
    {
        if (repeatUnlock == false)
        {
            int scrollCount = scrollMem + scrollAdd;
            scrollsText.text = "Scrolls: " + scrollCount;
            scrollMem = scrollCount;
        }
    }

    public void TitleScreen()
    {
        GameOver();
        backgroundUI.SetActive(true);
        startGameButton.SetActive(true);
        howToPlayButton.SetActive(true);
        quitButton.SetActive(true);
        backToTitleButton.SetActive(false);
        keepGoingButton.SetActive(false);
        wizardImage.SetActive(true);
        controlsImage.SetActive(false);
        healthText.text = "";
        scrollsText.text = "";
        diedText.text = "";
        middleScreenText.text = "";
        loopText.text = "";
        print("Titlescreen");
        UnityEngine.Cursor.visible = true;
    }

    public void GameOverHUD()
    {
        backgroundUI.SetActive(false);
        startGameButton.SetActive(false);
        howToPlayButton.SetActive(false);
        quitButton.SetActive(false);
        backToTitleButton.SetActive(true);
        keepGoingButton.SetActive(false);
        wizardImage.SetActive(false);
        controlsImage.SetActive(false);
        healthText.text = "";
        scrollsText.text = "";
        diedText.text = "YOU DIED!";
        menuSafety = true;
        print(menuSafety);
        UnityEngine.Cursor.visible = true;
    }

    public void HowToPlayHUD()
    {
        backgroundUI.SetActive(true);
        startGameButton.SetActive(false);
        howToPlayButton.SetActive(false);
        quitButton.SetActive(false);
        backToTitleButton.SetActive(true);
        keepGoingButton.SetActive(false);
        wizardImage.SetActive(false);
        controlsImage.SetActive(true);
        healthText.text = "";
        scrollsText.text = "";
        diedText.text = "";
        UnityEngine.Cursor.visible = true;
    }

    public void StartGame()
    {
        repeatCount = portal.GetComponent<script_LevelReset>().numRepeat;
        backgroundUI.SetActive(false);
        startGameButton.SetActive(false);
        howToPlayButton.SetActive(false);
        quitButton.SetActive(false);
        backToTitleButton.SetActive(false);
        keepGoingButton.SetActive(false);
        wizardImage.SetActive(false);
        controlsImage.SetActive(false);
        UpdateHealthHUD(playerHealth);
        UpdateScrollsHUD(scrollMem);
        diedText.text = "";
        middleScreenText.text = "";
        loopText.text = "LOOP: " + repeatCount;
        walls.SetActive(true);
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Player").GetComponent<Script_WeaponPicker>().ChangeWeapon(0);
        launch1.GetComponent<Script_LaunchProjectile>().enabled = true;
        launch2.GetComponent<Script_Weapon2>().enabled = true;
        menuSafety = false;
        UnityEngine.Cursor.visible = false;
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VictoryScreen()
    {
        backgroundUI.SetActive(true);
        startGameButton.SetActive(false);
        howToPlayButton.SetActive(false);
        quitButton.SetActive(false);
        backToTitleButton.SetActive(true);
        keepGoingButton.SetActive(true);
        wizardImage.SetActive(true);
        controlsImage.SetActive(false);
        middleScreenText.text = "You did it! You found all of the scrolls and unlocked the" +
            " \"Secret of Hy-Brasil\". Get it? Do you want to keep playing" +
            " and fight in the tougher dimensions?";
        healthText.text = "";
        loopText.text = "";
        scrollsText.text = "";
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        GameObject.Find("Player").GetComponent<Script_WeaponPicker>().ChangeWeapon(1);
        repeatCount = portal.GetComponent<script_LevelReset>().numRepeat;
        launch1.GetComponent<Script_LaunchProjectile>().enabled = false;
        launch2.GetComponent<Script_Weapon2>().enabled = false;
        UnityEngine.Cursor.visible = true;
    }
}
