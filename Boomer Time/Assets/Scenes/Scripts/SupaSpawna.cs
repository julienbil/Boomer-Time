using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupaSpawna : MonoBehaviour
{
    public GameObject camera;
    public int maxY = 3, minY = -3, variation = 0;
    public float xPos = 11;

    [Header("Enemy Spawner Settings")]
    public GameObject enemy;
    public float enemyCd=0,enemyLastSpawn=0, enemyMin=15f, enemyMax=45f, enemyMaxScale = 2;
    public int enemyMinCD = 1, enemyMaxCD = 3;

    [Header("PowerUp Spawner Settings")]
    public GameObject[] powerUp;
    public float powerUpCd = 0, powerUpLastSpawn = 0;
    public int powerUpMinCD = 8, powerUpMaxCD = 15;

    [Header("Event Spawner Settings")]
    public GameObject warning;
    public GameObject[] events;
    public float eventCd = 0, eventLastSpawn = 0;
    public int eventMinCD = 0, eventMaxCD = 1, eventPosY = -6;

    [Header("Collectibles Spawner Settings")]
    public GameObject[] collectible;
    public float collectibleCD = 0, collectibleLastSpawn = 0;
    public int collectibleMinCD = 0, collectibleMaxCD = 1;

    [Header("Obstacles Spawner Settings")]
    public GameObject[] obstacles;
    public float obstaclesCD = 0, obstaclesLastSpawn = 0;
    public int obstaclesMinCD = 0, obstaclesMaxCD = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyMin < 30)
        {
            enemyMin = 15 + (++variation * (15f / 15000));
            enemyMax = 45 + (++variation * (15f / 15000));
            enemyMaxScale = 2 + (++variation * (0.5f / 15000));
        }
        else if (enemyMin > 30)
        {
            enemyMin = 30;
            enemyMax = 70;
        }

        if (Time.time - enemyLastSpawn >= enemyCd)
        {
            for (int i = 0; i < Random.Range((int)enemyMin, (int)enemyMax); i++)
            {
                GameObject go = Instantiate(enemy, new Vector3(xPos, Random.Range(minY*100,maxY*100)/100f, 0), Quaternion.identity);
                go.transform.localScale = new Vector3(Random.Range(2*100,enemyMaxScale*100)/100, Random.Range(2*100,enemyMaxScale*100)/100f, 1);
            }

            enemyCd = Random.Range(enemyMinCD*100, enemyMaxCD*100)/100f;
            enemyLastSpawn = Time.time;
        }
        
        if (Time.time - powerUpLastSpawn >= powerUpCd)
        {
            Instantiate(powerUp[Random.Range(0,powerUp.Length)], new Vector3(xPos, Random.Range(minY * 100, maxY*100) /100f, 0), Quaternion.identity);
            powerUpCd = Random.Range(powerUpMinCD*100, powerUpMaxCD*100)/100f;
            powerUpLastSpawn = Time.time;
        }

        if (Time.time - eventLastSpawn >= eventCd)
        {
            warning.SetActive(true);
            if (Time.time - eventLastSpawn >= eventCd+3)
            {
                Destroy(Instantiate(events[Random.Range(0, events.Length)], new Vector3(camera.transform.position.x, camera.transform.position.y, 0), Quaternion.identity, transform),16f);
                eventCd = Random.Range(eventMinCD*100, eventMaxCD*100)/100f;
                eventLastSpawn = Time.time;
            }
        }

        if (Time.time - collectibleLastSpawn >= collectibleCD)
        {
            Instantiate(collectible[Random.Range(0, collectible.Length)], new Vector3(xPos, Random.Range(minY * 100, maxY * 100) / 100f, 0), Quaternion.identity);
            collectibleCD = Random.Range(collectibleMinCD*100, collectibleMaxCD*100)/100f;
            collectibleLastSpawn = Time.time;
        }

        if (Time.time - obstaclesLastSpawn >= obstaclesCD)
        {
            Instantiate(obstacles[Random.Range(0, obstacles.Length)], new Vector3(xPos+3, Random.Range(minY * 100, maxY * 100) / 100f, 0), Quaternion.identity);
            obstaclesCD = Random.Range(obstaclesMinCD*100, obstaclesMaxCD*100)/100f;
            obstaclesLastSpawn = Time.time;
        }

    }
}
