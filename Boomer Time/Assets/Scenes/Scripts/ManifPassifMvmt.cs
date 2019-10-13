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
    public float xDepart;
    bool tornadeIsActive = false;
    float timer = 1f;
    Vector2 modifier = new Vector2();
    public GameObject blood;
    float lastCheck = 0;
   

    private void Start()
    {
        transform.position = transform.position + new Vector3(xDepart, Random.Range(-4f, 4f));
        force = new Vector2(-xMovement, Random.Range(-10f, 10f));
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan(force.y / force.x) * 360 / (2 * Mathf.PI) + 90);
        rb.mass = rb.mass * Random.Range(1, 10) / 5;
        //StartCoroutine(ActivateOnTimer());
    }


    void FixedUpdate()
    {
        float speed = Random.Range(10f * speedMin, 10f * speedMax)/2;
        Vector2 maxVelo = new Vector2(speed/100, speed/100);
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan(force.y / force.x) * 360 / (2 * Mathf.PI) + 90);
        if (rb.velocity.sqrMagnitude < maxVelo.sqrMagnitude)
            rb.AddForce(force + modifier);
        
        /*Quaternion quater = new Quaternion();
        quater.eulerAngles = new Vector3(0, 0, Mathf.Atan(rb.velocity.y / rb.velocity.x) * 360 / (2 * Mathf.PI) + 90);
        rb.MoveRotation(quater);*/
        /*
        if (tornadeIsActive)
        {
            modifier = new Vector2(Random.Range(-100f, 100f) * 10, Random.Range(-100f, 100f) * 10);
        }
        else
        {
            modifier = new Vector2(0, 0);
        }
        */

            if (tornadeIsActive)
            {
                modifier = new Vector2(Random.Range(-100f, 100f) * 10, Random.Range(-100f, 100f) * 10);
            }
            else
            {
                modifier = new Vector2(0, 0);
            }
        
        

    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.tag == "mur" || col.gameObject.tag == "manifPassifs")
        {
            force = new Vector2(-xMovement, force.y*-1);
            rb.velocity = new Vector2(0, -rb.velocity.y);
            rb.AddForce(force);
        }

        if (col.gameObject.name == "Player 1" || col.gameObject.name == "Player 2")
        {
            if (col.gameObject.GetComponent<PowerUps>().isLawnmower)
            {
                Instantiate(blood, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    /*
    private IEnumerator ActivateOnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            if (tornadeIsActive)
            {
                modifier = new Vector2(Random.Range(-100f, 100f) * 10, Random.Range(-100f, 100f) * 10);
            }
            else if(modifier != new Vector2(0, 0))
            {
                modifier = new Vector2(0, 0);
            }
        }
    }
    */

    public void TornadeActive()
    {
        tornadeIsActive = true;
    }

    public void TornadeInactive()
    {
        tornadeIsActive = false;
    }
}