using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadeEvent : MonoBehaviour
{
    GameObject[] joueurs;
    GameObject[] passifs;
    void Start()
    {
        joueurs = GameObject.FindGameObjectsWithTag("Player");
        passifs = GameObject.FindGameObjectsWithTag("manifPassifs");
        foreach (GameObject player in joueurs)
        {

        }
        foreach (GameObject passif in passifs)
        {
            passif.GetComponent<ManifPassifMvmt>().TornadeActive();
        }
    }

    /*
    void Update()
    {
        joueurs = GameObject.FindGameObjectsWithTag("Player");
        passifs = GameObject.FindGameObjectsWithTag("manifPassifs");
        foreach (GameObject player in joueurs)
        {

        }
        foreach (GameObject passif in passifs)
        {
            passif.GetComponent<ManifPassifMvmt>().TornadeInactive();
        }
    }
    */
}
