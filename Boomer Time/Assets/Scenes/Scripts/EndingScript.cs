using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    public Button rejouerBut,quitterBut,menuBut;
    public void rejouer()
    {
        if (startMenu.nbeDeJoueur)
        {
            SceneManager.LoadScene("SampleScene1P");
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
}
