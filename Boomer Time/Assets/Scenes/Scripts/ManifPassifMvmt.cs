using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManifPassifMvmt : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speedMax;
    public float speedMin;
    public Vector2 force;
    public float xMovement;
   

    private void Start()
    {
        transform.position = transform.position + new Vector3(0, Random.Range(-4f, 4f));
        force = new Vector2(-xMovement, Random.Range(-10f, 10f));
        rb.mass = rb.mass * Random.Range(1, 10) / 5;
    }


    void FixedUpdate()
    {
        float speed = Random.Range(10f * speedMin, 10f * speedMax)/2;
        Vector2 maxVelo = new Vector2(speed/100, speed/100);


        if (rb.velocity.sqrMagnitude < maxVelo.sqrMagnitude)
            rb.AddForce(force);
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.tag == "mur")
        {
            force = new Vector2(-xMovement, force.y*-1);
            rb.velocity = new Vector2(0, -rb.velocity.y);
            rb.AddForce(force);
        }
        
        
    }
}
