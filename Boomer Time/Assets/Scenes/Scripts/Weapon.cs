using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponname;
    public int force;
    public Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Attack()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("X"))
        {
            Attack();
        }
    }
}