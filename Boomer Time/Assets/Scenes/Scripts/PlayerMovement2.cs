using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public int speed1;
    public Rigidbody2D rb1;
    public float horizontalSpeed1;
    public float verticalSpeed1;
    public bool canMove1 = true;
    public bool dashing1;
    public int dashspeed1;
    public Vector2 maxVelo1;
    bool tornadoIsActive1 = false;

    // Start is called before the first frame update
    void Start()
    {
        rb1 = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Dash1()
    {
        if (canMove1 && !dashing1)
        {
            StartCoroutine(DashCooldown1());
            rb1.velocity += new Vector2(dashspeed1 * rb1.velocity.x, dashspeed1 * rb1.velocity.y);

            IEnumerator DashCooldown1()
            {
                dashing1 = true;
                yield return new WaitForSeconds(0.4f);
                dashing1 = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (canMove1)
        {
            horizontalSpeed1 = Input.GetAxis("Horizontal1");
            verticalSpeed1 = Input.GetAxis("Vertical1");
        }
        if (canMove1 && tornadoIsActive1)
        {
            horizontalSpeed1 = -Input.GetAxis("Horizontal1");
            verticalSpeed1 = -Input.GetAxis("Vertical1");
        }
        if (Input.GetButtonDown("A"))
        {
            Dash1();
        }

        //Vector3 lookDirection = new Vector3(0,0, Input.GetAxisRaw("Vertical") + Input.GetAxisRaw("Horizontal"));
        //transform.rotation = Quaternion.LookRotation(lookDirection);
        if (Input.GetAxisRaw("Vertical1") + Input.GetAxisRaw("Horizontal1") != 0 && canMove1)
        {
            if (Input.GetAxis("Horizontal1") == 0)
                transform.eulerAngles = new Vector3(0, 0, Mathf.Atan(Input.GetAxis("Vertical1") / Input.GetAxis("Horizontal1")) * 360 / (2 * Mathf.PI) - 90);
            else if (Input.GetAxis("Horizontal1") > 0)
                transform.eulerAngles = new Vector3(0, 0, Mathf.Atan(Input.GetAxis("Vertical1") / Input.GetAxis("Horizontal1")) * 360 / (2 * Mathf.PI) - 90);
            else if (Input.GetAxis("Horizontal1") < 0)
                transform.eulerAngles = new Vector3(0, 0, Mathf.Atan(Input.GetAxis("Vertical1") / Input.GetAxis("Horizontal1")) * 360 / (2 * Mathf.PI) + 90);
        }

        //Debug.Log(Input.GetAxisRaw("Vertical"));
        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        //Debug.Log(Input.GetAxisRaw("Vertical") / Input.GetAxisRaw("Horizontal"));
        //Debug.Log(Mathf.Atan(Input.GetAxisRaw("Vertical") / Input.GetAxisRaw("Horizontal")) * 360 / (2 * Mathf.PI));
        if (rb1.velocity.sqrMagnitude < maxVelo1.sqrMagnitude && canMove1)
        {
            rb1.AddForce(new Vector2(horizontalSpeed1 * speed1 / 100, verticalSpeed1 * speed1 / 100));
        }


    }


    public void ActivateTornado1()
    {
        tornadoIsActive1 = true;
    }

    public void DeactivateTornado1()
    {
        tornadoIsActive1 = false;
    }
}
