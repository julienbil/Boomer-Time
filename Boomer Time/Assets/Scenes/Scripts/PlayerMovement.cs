using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public Rigidbody2D rb;
    public float horizontalSpeed;
    public float verticalSpeed;
    public bool canMove = true;
    public int acceleration;
    public Vector2 maxVelo;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            horizontalSpeed = Input.GetAxis("Mouse X");
            verticalSpeed = Input.GetAxis("Mouse Y");
        }

        if (rb.velocity.sqrMagnitude < maxVelo.sqrMagnitude)
        {
            rb.AddForce(new Vector2(horizontalSpeed*speed/100, verticalSpeed*speed/100));
        }

    
    }
}
