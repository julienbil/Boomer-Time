using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupaSpawna : MonoBehaviour
{
    public GameObject camera;
    public int maxY = 3, minY = -3;
    public float xPos = 11;

    [Header("Enemy Spawner Settings")]
    public GameObject enemy;
    public float enemyCd=0,enemyLastSpawn=0;
    public int enemyMinCD = 1, enemyMaxCD = 3, enemyMin=1, enemyMax=10;

    [Header("PowerUp Spawner Settings")]
    public GameObject[] powerUp;
    public float powerUpCd = 0, powerUpLastSpawn = 0;
    public int powerUpMinCD = 8, powerUpMaxCD = 15;

    [Header("Event Spawner Settings")]
    public GameObject warning;
    public GameObject[] events;
    public float eventCd = 0, eventLastSpawn = 0;
    public int eventMinCD = 0, eventMaxCD = 1, eventPosY = -6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - enemyLastSpawn >= enemyCd)
        {
            for (int i = 0; i < Random.Range(enemyMin, enemyMax); i++)
                Instantiate(enemy, new Vector3(xPos, Random.Range(minY*100,maxY*100)/100, 0), Quaternion.identity);
            enemyCd = Random.Range(enemyMinCD, enemyMaxCD);
            enemyLastSpawn = Time.time;
        }
        
        if (Time.time - powerUpLastSpawn >= powerUpCd)
        {
            Instantiate(powerUp[Random.Range(0,powerUp.Length)], new Vector3(xPos, Random.Range(-minY, maxY*100) /100, 0), Quaternion.identity);
            powerUpCd = Random.Range(powerUpMinCD, powerUpMaxCD);
            powerUpLastSpawn = Time.time;
        }
        if (Time.time - eventLastSpawn >= eventCd)
        {
            warning.SetActive(true);
            if (Time.time - eventLastSpawn >= eventCd+3)
            {
                Destroy(Instantiate(events[Random.Range(0, events.Length)], new Vector3(camera.transform.position.x, camera.transform.position.y, 0), Quaternion.identity),16f);
                eventCd = Random.Range(eventMinCD, eventMaxCD);
                eventLastSpawn = Time.time;
            }
        }
        
    }
}
