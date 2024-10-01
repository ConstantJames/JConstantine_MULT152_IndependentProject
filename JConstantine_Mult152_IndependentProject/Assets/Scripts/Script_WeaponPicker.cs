using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_WeaponPicker : MonoBehaviour
{
    // Start is called before the first frame update

    public int currentWeapon;
    public GameObject [] weapons;
    public bool unlock = false;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            print("Weapon 1");
            ChangeWeapon(0);
        }
        if (Input.GetKeyDown("2")&& unlock == true)
        {
                print("Weapon 2");
                ChangeWeapon(1);
        }
    }
    void ChangeWeapon (int num)
    {
        currentWeapon = num;
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == num);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Unlock"))
        {
            unlock = true;
            print("NEW SPELL UNLOCKED");
            Destroy(other.gameObject);
        }
    }
}
