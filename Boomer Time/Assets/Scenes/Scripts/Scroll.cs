using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed;
    public GameObject camera;
    public GameObject destroyer;
    public GameObject mur, mur2, spawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        destroyer.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        mur.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        mur2.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        spawner.GetComponent<SupaSpawna>().xPos += speed * Time.deltaTime;
    }
}
