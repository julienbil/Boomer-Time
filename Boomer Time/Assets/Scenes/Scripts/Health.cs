using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    void Start() { }

    public void RemoveHealth(int dmg)
    {
        health -= dmg;
    }

    public void AddHealth(int heal)
    {
        health += heal;
    }

    // Update is called once per frame
    void Update()
    {
     if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
