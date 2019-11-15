using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndingScript : MonoBehaviour
{
    public TextMeshProUGUI optext, opname;
    public Button rejouerBut,menuBut;
    public static bool monkey = false;
    string nomString = "";
    char[] nom= { 'A','A','A' };
    int lettreI=0;
    bool nametime = false;

    private void Start()
    {
        //HighscoreManager.CheckNewHS1P(10000);
        if (startMenu.nbeDeJoueur)
            HighscoreManager.CheckNewHS1P((int)ScoreManager.scoreP1);
        else if (!startMenu.nbeDeJoueur)
            HighscoreManager.CheckNewHS2P((int)(ScoreManager.scoreP1 + ScoreManager.scoreP2));
        if (monkey == true)
            EnterName();
        optext.text = "Score final: "+((int)(ScoreManager.scoreP1 + ScoreManager.scoreP2)).ToString();
        ScoreManager.scoreP1 = 0;
        ScoreManager.scoreP2 = 0;
    }
    private void Update()
    {
        if (nametime)
        {
            if (lettreI < 3)
            {
                if (Input.GetAxis("Vertical") > 0.5f) //Input.GetAxis("Vertical") > 0.5f
                {
                    if (nom[lettreI] <= 65)
                    {
                        nom[lettreI] = (char)90;
                    }
                    else
                        nom[lettreI]--;
                    opname.text = "";
                    for (int i = 0; i < lettreI + 1; i++)
                        opname.text += nom[i];
                }
                if (Input.GetAxis("Vertical") < -0.5f) //Input.GetAxis("Vertical") > -0.5f
                {
                    if (nom[lettreI] >= 90)
                    {
                        nom[lettreI] = (char)65;
                    }
                    else
                        nom[lettreI]++;
                    opname.text = "";
                    for (int i = 0; i < lettreI + 1; i++)
                        opname.text += nom[i];
                }
                if (Input.GetButtonDown("B1")) //Input.GetButtonDown("B1")
                {
                    nomString+= nom[lettreI];
                    lettreI++;
                    opname.text = "";
                    for (int i = 0; i < lettreI+1 && i<3; i++)
                        opname.text += nom[i];
                }
            }
            else
            {
                if (startMenu.nbeDeJoueur)
                    HighscoreManager.ReceiveName1P(nomString);
                else if (!startMenu.nbeDeJoueur)
                    HighscoreManager.ReceiveName2P(nomString);
                opname.text = "";
                for (int i = 0; i < 3; i++)
                    nom[i]='A';
                rejouerBut.interactable = true;
                menuBut.interactable = true;
                opname.gameObject.SetActive(false);
                monkey = false;
                nametime = false;
            }
        }
    }
    public void rejouer()
    {
        if (startMenu.nbeDeJoueur)
        {
            SceneManager.LoadScene("Street1P");
        }
        if (!startMenu.nbeDeJoueur)
        {
            SceneManager.LoadScene("Scene2P");
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

    public void EnterName()
    {
        rejouerBut.interactable = false;
        menuBut.interactable = false;
        opname.gameObject.SetActive(true);
        lettreI = 0;
        nomString = "";
        for (int i = 0; i < 3; i++)
            nom[i]='A';
        opname.text = "";
        for (int i = 0; i < lettreI + 1; i++)
            opname.text += nom[i];
        nametime = true;
    }
}
