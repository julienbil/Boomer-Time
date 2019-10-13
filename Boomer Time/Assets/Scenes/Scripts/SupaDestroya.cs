using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupaDestroya : MonoBehaviour
{
    public Text player1;
    public Text player2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "manifPassifs" || other.tag == "misc" || other.tag == "fish")
        {
                Destroy(other.gameObject);
        }

        if (other.tag == "Player" && other.gameObject.layer == 9)
        {
            player1.text = "Player 1 a perdu :(";
            Destroy(other.gameObject);
        }
        else if (other.tag == "Player" && other.gameObject.layer == 10)
        {
            player2.text = "Player 2 a perdu :(";
            Destroy(other.gameObject);
        }
    }
}
