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
    public int distance;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Attack()
    {
        GameObject dumb = Instantiate(hitbox, player.transform.position , player.transform.rotation, player.transform);
        if (player.layer == 9)
        {
            dumb.layer = 8;
        }
        if (player.layer == 10)
        {
            dumb.layer = 11;
        }
        Destroy(dumb, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hello");
    }


}