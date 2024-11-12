using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        spawnArea = GetComponent<Collider>();
        walls = GameObject.Find("MagicDoors");
        portal = GameObject.Find("RepeatPortal");
    }

    void SpawnWave(int enemyNum)
    {
        for (int x = 0; x < enemyNum; x++)
        {
            
            
            if (waveNum < maxWaves )
            {
                Instantiate(enemyPrefab, GetRandomPositionInCollider(), enemyPrefab.transform.rotation);
                
            }
            if (waveNum == maxWaves)
            {
                WaveEnd();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Script_EnemyHealth>().Length;
        if (enemyCount == 0 && firstTime == true )
        {
            int enemyNum = (int)Mathf.Pow(2, waveNum);
            SpawnWave(enemyNum);
            waveNum++;

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
                walls.SetActive(true);
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
        Debug.Log("Waves Over");
        walls.SetActive(false);
        portal.SetActive(true);
    }
}
