using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponname;
    public float force;
    public Sprite sprite;
    public Rigidbody2D rb;
    public GameObject hitbox;
    public GameObject player;
    public Collider2D parentCollider;
    public Collider2D weaponCollider;
    public int distance;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        weaponCollider = gameObject.GetComponent<Collider2D>();
        parentCollider = gameObject.GetComponentInParent<Collider2D>();
        Physics2D.IgnoreCollision(parentCollider, weaponCollider, true);
    }

    void Attack()
    {
        GameObject dumb = Instantiate(hitbox, player.transform.position , player.transform.rotation);
        Destroy(dumb, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("X"))
        {
            Debug.Log("attack lol");
            Attack();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hello");
    }


}