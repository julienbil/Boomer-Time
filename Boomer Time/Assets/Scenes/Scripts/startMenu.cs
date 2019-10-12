using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class startMenu : MonoBehaviour
{
    public GameObject startMenuUI;
    public GameObject instructionText;
    public GameObject retourButton;
    public GameObject but1Player;
    public GameObject but2Player;
    public GameObject startBut;
    private Scene scene;
    public EventSystem m_EventSystem;
    public static bool nbeDeJoueur = false;

    public void start()
    {  
        startMenuUI.SetActive(false);
        but1Player.SetActive(true);
        but2Player.SetActive(true);
        m_EventSystem.SetSelectedGameObject(but1Player);
    }
    public void instructionPath()
    {    
        instructionText.SetActive(true);
        startMenuUI.SetActive(false);
        retourButton.SetActive(true);
        m_EventSystem.SetSelectedGameObject(retourButton);
    }
    public void quitter()
    {
        Application.Quit();
    }
    public void retour()
    {
        instructionText.SetActive(false);
        startMenuUI.SetActive(true);
        retourButton.SetActive(false);
        m_EventSystem.SetSelectedGameObject(startBut);
    }
    public void onePlayer()
    {
        chooseNbePlayer(1);
    }
    public void twoPlayers()
    {
        chooseNbePlayer(2);
    }
    public void chooseNbePlayer( int nombre)
    {
        switch (nombre)
        {
            case 1:
                PlayersReady.gameIsStarted = true;
                nbeDeJoueur = true;
              SceneManager.LoadScene("Scene1P");
                break;
            case 2:
                nbeDeJoueur = false;
                SceneManager.LoadScene("Scene2P");
                break;

        }
        
    }
   
}
