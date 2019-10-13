using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Vector2 direction;
    public Rigidbody2D rb;
    public float forceY, forceX;

    void Start()
    {

            if(Random.Range(1,3)==1)
                direction = new Vector2(-1 * forceX, (-transform.position.y / 100) * forceY);
            else if(Random.Range(1, 3) ==1)
                direction = new Vector2(1 * forceX, (-transform.position.y / 100) * forceY);
            else
                direction = new Vector2(0, (-transform.position.y / 100) * forceY);

    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(direction);
        transform.eulerAngles += new Vector3(0, 0, 360*Time.deltaTime);
    }
}
