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
            horizontalSpeed = Input.GetAxis("Horizontal");
            verticalSpeed = Input.GetAxis("Vertical");
        }

        //Vector3 lookDirection = new Vector3(0,0, Input.GetAxisRaw("Vertical") + Input.GetAxisRaw("Horizontal"));
        //transform.rotation = Quaternion.LookRotation(lookDirection);
        if(Input.GetAxisRaw("Vertical") + Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") == 0)
                transform.eulerAngles = new Vector3(0, 0, Mathf.Atan(Input.GetAxis("Vertical") / Input.GetAxis("Horizontal")) * 360 / (2 * Mathf.PI) - 90);
            else if (Input.GetAxis("Horizontal") > 0)
                transform.eulerAngles = new Vector3(0, 0, Mathf.Atan(Input.GetAxis("Vertical") / Input.GetAxis("Horizontal")) * 360 / (2 * Mathf.PI) - 90);
            else if (Input.GetAxis("Horizontal") < 0)
                transform.eulerAngles = new Vector3(0, 0, Mathf.Atan(Input.GetAxis("Vertical") / Input.GetAxis("Horizontal")) * 360 / (2 * Mathf.PI) + 90);
        }
            
        //Debug.Log(Input.GetAxisRaw("Vertical"));
        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        //Debug.Log(Input.GetAxisRaw("Vertical") / Input.GetAxisRaw("Horizontal"));
        //Debug.Log(Mathf.Atan(Input.GetAxisRaw("Vertical") / Input.GetAxisRaw("Horizontal")) * 360 / (2 * Mathf.PI));
        if (rb.velocity.sqrMagnitude < maxVelo.sqrMagnitude && canMove)
        {
            rb.AddForce(new Vector2(horizontalSpeed*speed/100, verticalSpeed*speed/100));
        }

    
    }
}
