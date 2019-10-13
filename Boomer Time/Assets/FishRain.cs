using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRain : MonoBehaviour
{
    public float enemyCd = 0, enemyLastSpawn = 0;
    public int xPosMin =-3, xPosMax=3, yPos=10;
    public Sprite[] fishes;
    public GameObject fish;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - enemyLastSpawn >= enemyCd)
        {
            for (int i = 0; i < 10; i++)
            {
                if(i<5)
                {
                    GameObject go = Instantiate(fish, new Vector3(Random.Range(xPosMin, xPosMax)+transform.position.x, Random.Range(yPos, yPos+5), 0), Quaternion.identity);
                    go.GetComponent<SpriteRenderer>().sprite = fishes[Random.Range(0, fishes.Length)];
                }  
                else
                {
                    GameObject go = Instantiate(fish, new Vector3(Random.Range(xPosMin, xPosMax)+transform.position.x, Random.Range(-yPos, -yPos-5), 0), Quaternion.identity);
                    go.GetComponent<SpriteRenderer>().sprite = fishes[Random.Range(0, fishes.Length)];
                }

            }

            enemyCd = Random.Range(200, 400)/100f;
            enemyLastSpawn = Time.time;
        }
    }
}
