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
    public bool dashing;
    public int dashspeed;
    public Vector2 maxVelo;
    public string horizon, verti,a;
    bool tornadoIsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Dash()
    {
        if (canMove && !dashing)
        {
            StartCoroutine(DashCooldown());
            rb.velocity += new Vector2(dashspeed * rb.velocity.x, dashspeed * rb.velocity.y);

            IEnumerator DashCooldown()
            {
                dashing = true;
                yield return new WaitForSeconds(0.4f);
                dashing = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            horizontalSpeed = Input.GetAxis(horizon);
            verticalSpeed = Input.GetAxis(verti);
        }
        if (canMove && tornadoIsActive)
        {
            horizontalSpeed = -Input.GetAxis(horizon);
            verticalSpeed = -Input.GetAxis(verti);
        }
        if (Input.GetButtonDown(a))
        {
            Dash();
        }

        //Vector3 lookDirection = new Vector3(0,0, Input.GetAxisRaw("Vertical") + Input.GetAxisRaw("Horizontal"));
        //transform.rotation = Quaternion.LookRotation(lookDirection);
        if (Input.GetAxisRaw(verti) + Input.GetAxisRaw(horizon) != 0 && canMove)
        {
            if (Input.GetAxis(horizon) == 0)
                transform.eulerAngles = new Vector3(0, 0, Mathf.Atan(Input.GetAxis(verti) / Input.GetAxis(horizon)) * 360 / (2 * Mathf.PI) - 90);
            else if (Input.GetAxis(horizon) > 0)
                transform.eulerAngles = new Vector3(0, 0, Mathf.Atan(Input.GetAxis(verti) / Input.GetAxis(horizon)) * 360 / (2 * Mathf.PI) - 90);
            else if (Input.GetAxis(horizon) < 0)
                transform.eulerAngles = new Vector3(0, 0, Mathf.Atan(Input.GetAxis(verti) / Input.GetAxis(horizon)) * 360 / (2 * Mathf.PI) + 90);
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


    public void ActivateTornado()
    {
        tornadoIsActive = true;
    }

    public void DeactivateTornado()
    {
        tornadoIsActive = false;
    }
}
