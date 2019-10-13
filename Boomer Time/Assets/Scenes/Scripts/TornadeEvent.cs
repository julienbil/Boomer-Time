using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TornadeEvent : MonoBehaviour
{
    GameObject[] joueurs;
    GameObject[] passifs;

    public Animator animator;
    public Image image;

    private void Start()
    {
        image.enabled = false;
        animator = GetComponent<Animator>();
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
        StartCoroutine(FadeOut());
    }

    private IEnumerator ActivateOnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 6));
            animator.SetTrigger("EclairIn");
            animator.SetTrigger("Eclair");
            image.enabled = true;
            FindObjectOfType<AudioMAnager>().Play("tonnerre");
        }
    }

    private IEnumerator FadeOut()
    {
        while (true)
        {
            yield return new WaitForSeconds(14.5f);
            animator.SetTrigger("Toto");
            image.enabled = false;
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
        StopAllCoroutines();
    }
    
}
