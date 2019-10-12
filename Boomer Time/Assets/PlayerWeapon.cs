using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public string currentWeapon;
    public GameObject baseball;
    public GameObject torch;
    public GameObject hammer;
    public GameObject tnt;
    public Collider2D weaponCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(weaponCollider, GetComponent<CircleCollider2D>(), true);
        Debug.Log(Physics2D.GetIgnoreCollision(weaponCollider, GetComponent<CircleCollider2D>()));
    }
}
