using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_EnemyWaves : MonoBehaviour
{



   //Code made with partial help from copilot as well as the lessons.
    
    private Collider spawnArea;

    //New Stuff
    public GameObject enemyPrefab;
    public int waveNum = 0;
    private int enemyCount;
    public bool firstTime = false;
    int maxWaves = 4;
    GameObject walls;
    GameObject portal;
    public bool waveWork = true;
    public TextMeshProUGUI wavecounter;
    private bool oneEnd = false;



    // Start is called before the first frame update
    void Start()
    {
        spawnArea = GetComponent<Collider>();
        walls = GameObject.Find("MagicDoors");
        portal = GameObject.Find("RepeatPortal");
        wavecounter.text = "";
    }

    void SpawnWave(int enemyNum)
    {
        wavecounter.text = "WAVE: " + (waveNum + 1);
        for (int x = 0; x < enemyNum; x++)
        {
            
            
            if (waveNum < maxWaves )
            {
                Instantiate(enemyPrefab, GetRandomPositionInCollider(), enemyPrefab.transform.rotation);
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Script_EnemyHealth>().Length;
        if (enemyCount == 0 && firstTime == true && waveWork == true)
        {
            int enemyNum = (int)Mathf.Pow(2, waveNum);
            SpawnWave(enemyNum);
            waveNum++;
        }
        else if (enemyCount == 0 && waveWork == false)
            {
                WaveEnd();
            }
        if (waveNum == maxWaves)
        {
            waveWork = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (firstTime == false)
            {
                waveNum++;
                int enemyNum = (int)Mathf.Pow(1, waveNum);
                SpawnWave(enemyNum);
                firstTime = true;
                waveWork = true;
                walls.SetActive(true);
                wavecounter.text = "WAVE: " + waveNum;
            }
        }
    }

    Vector3 GetRandomPositionInCollider()
    {
        Vector3 minBounds = spawnArea.bounds.min;
        Vector3 maxBounds = spawnArea.bounds.max;

        float xPos = Random.Range(minBounds.x, maxBounds.x);
        float zPos = Random.Range(minBounds.z, maxBounds.z);
        Vector3 spawnPos = new Vector3(xPos, 12f, zPos);
        return spawnPos;
        
    }

    void WaveEnd()
    {
        if (oneEnd == false)
        {
            Debug.Log("Waves Over");
            walls.SetActive(false);
            portal.SetActive(true);
            wavecounter.text = "";
            oneEnd = true;
        }
    }
}
