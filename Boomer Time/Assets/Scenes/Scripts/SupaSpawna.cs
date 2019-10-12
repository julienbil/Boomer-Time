using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupaSpawna : MonoBehaviour
{
    public GameObject enemy;
    public float cd=0,lastSpawn=0, xPos = 11;
    public int maxY = 3, minY = -3, minCD = 1, maxCD = 3, enemyMin=1, enemyMax=10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSpawn >= cd)
        {
            for(int i=0;i<Random.Range(enemyMin,enemyMax);i++)
                Instantiate(enemy, new Vector3(xPos, Random.Range(-3,3), 0), Quaternion.identity);
            cd = Random.Range(minCD, maxCD);
            lastSpawn = Time.time;
        }

    }
}
