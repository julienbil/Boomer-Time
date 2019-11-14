using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRain : MonoBehaviour
{
    public float enemyCd = 0, enemyLastSpawn = 0;
    public float rainCD = 0.5f, rainLastSpawn = 0;
    public int xPosMin =-3, xPosMax=3, yPos=10;
    public int xRainPosMin = -15, xRainPosMax = 25, yRainPos = 5;
    public Sprite[] fishes;
    public GameObject fish;
    public GameObject rain;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
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

        if (Time.time - rainLastSpawn >= rainCD)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject ol = Instantiate(rain, new Vector3(Random.Range(xRainPosMin, xRainPosMax) + transform.position.x, 10, 0), Quaternion.identity, transform);
                ol.transform.localScale = new Vector3(3, Random.Range(2, 10), 1);
                Destroy(ol, 2);
            }
            rainLastSpawn = Time.time;
        }
    }
}
