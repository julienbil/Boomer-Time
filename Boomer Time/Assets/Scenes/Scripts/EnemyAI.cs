using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public float speed;
    private Transform target;
    private GameObject[] liste;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        liste = GameObject.FindGameObjectsWithTag("Player");
    }
    

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject player in liste)
        {
            float distActuelle = Mathf.Sqrt((Mathf.Pow(player.GetComponent<Transform>().transform.position.x, 2)) + (Mathf.Pow(player.GetComponent<Transform>().transform.position.y, 2)));
            float distTarget = Mathf.Sqrt((Mathf.Pow(target.transform.position.x - this.transform.position.x, 2)) + (Mathf.Pow(target.transform.position.y- this.transform.position.y, 2)));
            if (distActuelle < distTarget)
                target = player.GetComponent<Transform>();
        }
            
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
