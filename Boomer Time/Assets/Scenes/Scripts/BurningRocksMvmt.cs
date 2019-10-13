using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningRocksMvmt : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(enemy, new Vector3(xPos, Random.Range(minY*100,maxY*100)/100, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Random.Range(-15,-10), -40) * Time.deltaTime * speed);
    }
}
