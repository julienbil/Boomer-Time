using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SupaDestroya : MonoBehaviour
{
    public TextMeshProUGUI player1;
    public TextMeshProUGUI player2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "manifPassifs" || other.tag == "misc" || other.tag == "fish" || other.tag == "Powerup")
        {
                Destroy(other.gameObject);
        }

        if (other.tag == "Player" && other.gameObject.layer == 9)
        {
            dead1 = true;
            player1.text = "Mort";
            Destroy(other.gameObject);
        }
        else if (other.tag == "Player" && other.gameObject.layer == 10)
        {
            dead2 = true;
            player2.text = "Mort";
            Destroy(other.gameObject);
        }
    }
}
