using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public EventSystem m_EventSystem;
    public GameObject resumeBut;

    void Update()
    {
        if (PlayersReady.gameIsStarted)
        {
            if (Input.GetButtonDown("Start"))
                 {
                     if (gameIsPaused)
                     {
                         Resume();
                     }
                     else
                     {
                         m_EventSystem.SetSelectedGameObject(resumeBut);
                         Pause();
                     }
            }
        }
       
    } 

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        
        if (startMenu.nbeDeJoueur)
        {
            SceneManager.LoadScene("Scene1P");
        }
        else
        {
            PlayersReady.gameIsStarted = false;
            SceneManager.LoadScene("Scene2P");
        }
        
    }

    public void Quit()
    {
        PlayersReady.gameIsStarted = false;
        SceneManager.LoadScene("Start");
    }
}
