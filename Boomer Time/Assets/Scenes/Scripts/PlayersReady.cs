using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersReady : MonoBehaviour
{
    public static bool P1Ready = false;
    public static bool P2Ready = false;

    public GameObject start1;
    public GameObject start2;
    public Text text1;
    public Text text2;
    public Text textWaiting;
    public static bool gameIsStarted = false;
    public static bool ok = true;

    void Update()
    {
        if (ok)
        {
            checkUp();
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
            textWaiting.enabled = false; 
        }
        else if (P1Ready == true && P2Ready == false)
        {
            textWaiting.text = "En attente du joueur 2.";
        }
        else if (P1Ready == false && P2Ready == true)
        {
            textWaiting.text = "En attente du joueur 1.";
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