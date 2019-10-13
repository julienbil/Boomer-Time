using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadeMvmt : MonoBehaviour
{
    Vector2 direction;
    public float yDepart, speedY;
    public Rigidbody2D rb;

    void Start()
    {
        transform.position = transform.position + new Vector3(Random.Range(0, 6f), yDepart);
        direction = new Vector2((transform.parent.transform.position.x - transform.position.x)/100 + 0.2f, (transform.parent.transform.position.y - transform.position.y)/100 * speedY);
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //if (rb.velocity.sqrMagnitude < maxVelo.sqrMagnitude)
        rb.AddForce(direction);
    }
}
