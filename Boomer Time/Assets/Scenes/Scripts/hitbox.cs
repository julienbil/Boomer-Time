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
  
        direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * force);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerMovement>().beStunned(stunlength);
    }

    // Update is called once per frame
    void Update()
    {
        //rb.transform.position += (direction * force * Time.deltaTime);
    }
}
