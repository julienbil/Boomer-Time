using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayersReady : MonoBehaviour
{
    public static bool P1Ready = false;
    public static bool P2Ready = false;

    public GameObject start1;
    public GameObject start2;
    public Text text1;
    public Text text2;
    public Text ready1;
    public Text ready2;
    public Text textWaiting;
    public static bool gameIsStarted = false;
    public static bool ok = true;

    void Update()
    {
        if (ok)
        {
            checkUp();
        }
        if (Input.GetButtonDown("A1"))
        {
            but1();
        }
        if (Input.GetButtonDown("A2"))
        {
            but2();
        }
        if(Input.GetButtonDown("B1") && P1Ready)
        {
            P1Ready = false;
            start1.SetActive(true);
            ready1.enabled = false;
        }
        if (Input.GetButtonDown("B2") && P2Ready)
        {
            P2Ready = false;
            start2.SetActive(true);
            ready2.enabled = false;
        }

    }

    void checkUp()
    {
        if (P1Ready == true && P2Ready == true)
        {
            ok = false;
            Time.timeScale = 1f;
            text1.enabled = false;
            text2.enabled = false;
            ready1.enabled = false;
            ready2.enabled = false;
            textWaiting.enabled = false;
            SceneManager.LoadScene("SampleScene");
        }
        else if (P1Ready == true && P2Ready == false)
        {
            textWaiting.text = "En attente du joueur 2.";
            ready1.enabled = true;
        }
        else if (P1Ready == false && P2Ready == true)
        {
            textWaiting.text = "En attente du joueur 1.";
            ready2.enabled = true;
        }
        else
        {
            textWaiting.text = "";
        }
    }
    public void but1()
    {
        P1Ready = true;
        start1.SetActive(false);
    }
    public void but2()
    {
        P2Ready = true;
        start2.SetActive(false);
    }

}