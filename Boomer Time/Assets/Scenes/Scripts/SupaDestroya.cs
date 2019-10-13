using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupaDestroya : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "manifPassifs" || other.tag == "misc")
        {
                Destroy(other.gameObject);
        }
    }
}
