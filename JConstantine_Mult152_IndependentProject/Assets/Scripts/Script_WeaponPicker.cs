using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_WeaponPicker : MonoBehaviour
{
    // Start is called before the first frame update

    public int currentWeapon;
    public GameObject [] weapons;
    public GameObject [] staffs;
    public bool unlock = false;
    public GameManager gameManager;
    private bool gameOver;
    private GameObject walls;
    private int enemyCount;

    void Start()
    {
        walls = GameObject.Find("MagicDoors");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameOver = GameObject.Find("GameManager").GetComponent<GameManager>().gameOver;
        enemyCount = FindObjectsOfType<Script_EnemyHealth>().Length;
        if (Input.GetKeyDown("1"))
        {
            if (!gameOver)
            {
                print("Weapon 1");
                ChangeWeapon(0);
            }
        }
        if (Input.GetKeyDown("2")&& unlock == true)
        {
            if (!gameOver)
            {
                print("Weapon 2");
                ChangeWeapon(1);
            }
        }
    }
    public void ChangeWeapon (int num)
    {
        currentWeapon = num;
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == num);
            staffs[i].SetActive(i == num);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Unlock"))
        {
            unlock = true;
            print("NEW SPELL UNLOCKED");
            Destroy(other.gameObject);
            StartCoroutine(NewWeapon());
        }
    }

    public IEnumerator NewWeapon()
    {
        gameManager.middleScreenText.text = "NEW WEAPON UNLOCKED. PRESS 2";
        yield return new WaitForSeconds(2f);
        gameManager.middleScreenText.text = "";
    }
}
