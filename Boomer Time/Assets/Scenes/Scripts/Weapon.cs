using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponname;
    public GameObject hitbox;
    public GameObject player;
    public int durability;

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
        durability--;
    }

    public void Throw()
    {
        GameObject dumb = Instantiate(hitbox, player.transform.position, player.transform.rotation);
        if (player.layer == 9)
        {
            dumb.layer = 8;
        }
        if (player.layer == 10)
        {
            dumb.layer = 11;
        }
        durability--;
    }

    // Update is called once per frame
    void Update()
    {
        if (durability <= 0)
        {
            durability = 0;
            gameObject.SetActive(false);
            player.GetComponent<PlayerWeapon>().currentWeapon = "None";
        }
    }
}