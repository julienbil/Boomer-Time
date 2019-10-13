using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadeEvent : MonoBehaviour
{
    GameObject[] joueurs;
    GameObject[] passifs;

    private void Start()
    {
        joueurs = GameObject.FindGameObjectsWithTag("Player");
        passifs = GameObject.FindGameObjectsWithTag("manifPassifs");
        foreach (GameObject player in joueurs)
        {
            player.GetComponent<PlayerMovement>().ActivateTornado();
        }
        foreach (GameObject passif in passifs)
        {
            passif.GetComponent<ManifPassifMvmt>().TornadeActive();
        }
    }

   

    void OnDestroy()
    {
        joueurs = GameObject.FindGameObjectsWithTag("Player");
        passifs = GameObject.FindGameObjectsWithTag("manifPassifs");
        foreach (GameObject player in joueurs)
        {
            player.GetComponent<PlayerMovement>().DeactivateTornado();
        }
        foreach (GameObject passif in passifs)
        {
            passif.GetComponent<ManifPassifMvmt>().TornadeInactive();
        }
    }
    
}
