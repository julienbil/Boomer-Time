using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed, variation=0, divider=2;
    public GameObject camera;
    public GameObject destroyer1, destroyer2, destroyer3, destroyer4, wall;
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        //speed = Mathf.Pow(2, speed / 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (speed < 1.15f)
            speed = 0.4f + Mathf.Pow(++variation, 1 / divider) / 100;
        else if (speed > 1.15f)
            speed = 1.15f;

        camera.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        destroyer1.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        destroyer2.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        destroyer3.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        destroyer4.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        wall.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        spawner.GetComponent<SupaSpawna>().xPos += speed * Time.deltaTime;
    }
}
