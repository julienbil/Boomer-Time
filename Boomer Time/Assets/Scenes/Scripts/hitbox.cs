using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 direction;
    public int force;
    public float stunlength;
    // Start is called before the first frame update
    void Start()
    {  
        if (transform.parent.gameObject.layer == 9)
        direction = new Vector3(Input.GetAxis("Horizontal1"), Input.GetAxis("Vertical1"), 0);
        if (transform.parent.gameObject.layer == 10)
        direction = new Vector3(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"), 0);

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * force);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().beStunned(stunlength);
        }
     
    }

    // Update is called once per frame
    void Update()
    {
        //rb.transform.position += (direction * force * Time.deltaTime);
    }
}
