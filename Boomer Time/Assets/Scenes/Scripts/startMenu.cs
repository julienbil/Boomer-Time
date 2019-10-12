using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    public static bool gameIsStarted = false;
    public GameObject startMenuUI;
    public GameObject instructionText;
    public GameObject retourButton;
    public GameObject but1Player;
    public GameObject but2Player;
    private Scene scene;

    public void start()
    {
        startMenuUI.SetActive(false);
        but1Player.SetActive(true);
        but2Player.SetActive(true);
    }
    public void instructionPath()
    {
        instructionText.SetActive(true);
        startMenuUI.SetActive(false);
        retourButton.SetActive(true);
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
              gameIsStarted = true;
              SceneManager.LoadScene("Scene2P");
                break;
            case 2:
                gameIsStarted = true;
                SceneManager.LoadScene("Scene2P");
                break;

        }
        
    }
   
}
