using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public TextMeshProUGUI player1;
    public TextMeshProUGUI player2;

    private void OnDestroy()
    {
        if (gameObject.tag == "Player" && gameObject.layer == 9)
        {
            player1.text = "Mort";
        }
        else if (gameObject.tag == "Player" && gameObject.layer == 10)
        {
            player2.text = "Mort";
        }
    }
}
