using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed, variation=0, divider=2;
    public GameObject camera;
    public GameObject destroyer1, destroyer2, destroyer3, destroyer4, wall;
    public GameObject spawner;

    public float magnitude;

    bool shake = false;
    bool roll = false;
    Vector3 originPosition;
    Vector3 modifier;

    // Start is called before the first frame update
    void Start()
    {
        //speed = Mathf.Pow(2, speed / 4);
        modifier = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (speed < 1.15f)
            speed = 0.4f + Mathf.Pow(++variation, 1 / divider) / 100;
        else if (speed > 1.15f)
            speed = 1.15f;

        if(shake)
        {
            modifier = new Vector3(Random.Range(-1, 1)*magnitude, Random.Range(-1, 1)*magnitude);
        }
        if (roll)
        {

        }

        camera.transform.position += new Vector3(speed * Time.deltaTime, 0, 0) + modifier;
        destroyer1.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        destroyer2.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        destroyer3.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        destroyer4.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        wall.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        spawner.GetComponent<SupaSpawna>().xPos += speed * Time.deltaTime;
        originPosition += new Vector3(speed * Time.deltaTime, 0, 0);
    }


    public void ActivateShake()
    {
        shake = true;
        int rnd = Random.Range(1, 5);
        if (rnd == 1)
        {
            roll = true;
        }
        originPosition = transform.position;
    }

    public void DeactivateShake()
    {
        shake = false;
        roll = false;
        camera.transform.position = originPosition;
        modifier = new Vector3(0, 0, 0);
    }
}
