using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadeEvent : MonoBehaviour
{
    GameObject[] joueurs;
    GameObject[] passifs;

    public Animator animator;

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
        animator.SetTrigger("ActivateTornado");

        StartCoroutine(ActivateOnTimer());
    }

    private IEnumerator ActivateOnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 6));
            animator.SetTrigger("EclairIn");
            animator.SetTrigger("Eclair");
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
        animator.SetTrigger("DeactivateTornado");
    }
    
}
