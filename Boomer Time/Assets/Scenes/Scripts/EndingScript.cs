using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndingScript : MonoBehaviour
{
    public TextMeshProUGUI optext;
    public Button rejouerBut,quitterBut,menuBut;

    private void Start()
    {
        optext.text = "Score final: "+((int)(ScoreManager.scoreP1 + ScoreManager.scoreP2)).ToString();
        ScoreManager.scoreP1 = 0;
        ScoreManager.scoreP2 = 0;
    }
    public void rejouer()
    {
        if (startMenu.nbeDeJoueur)
        {
            SceneManager.LoadScene("Street1P");
        }
        if (!startMenu.nbeDeJoueur)
        {
            SceneManager.LoadScene("Street2P");
        }
    }
    public void quitter()
    {
        Application.Quit();
    }
    public void menu()
    {
        SceneManager.LoadScene("Start");
    }
}
