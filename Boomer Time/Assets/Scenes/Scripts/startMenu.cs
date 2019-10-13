using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class startMenu : MonoBehaviour
{
    public GameObject startMenuUI;
    public GameObject instructionPan;
    public GameObject retourButton;
    public GameObject choixNbeJoueurs;
    public GameObject panHs;
    public Button startBut;
    public Button instrucBut;
    public Button Hsbut;
    public Button quitBut;
    public GameObject but1PlayerHS;
    public GameObject but2PlayerHS;
    public GameObject but1Player;
    public GameObject but2Player;
    private Scene scene;
    public EventSystem m_EventSystem;
    private bool ok = false;
    public static bool nbeDeJoueur = false;
    public GameObject[] images;

    void Start()
    {
        m_EventSystem = EventSystem.current;
    }
    public void start()
    {
        for (int i = 0; i < images.Length; i++) { images[i].SetActive(false); }
        startBut.interactable = false;
        instrucBut.interactable = false;
        Hsbut.interactable = false;
        quitBut.interactable = false;
        choixNbeJoueurs.SetActive(true);
        m_EventSystem.SetSelectedGameObject(but1Player);
    }
    void Update()
    {
        if (Input.GetButtonDown("B1") || Input.GetButtonDown("B2"))
        {
            Debug.Log("bro");
            if (ok)
            {
                Debug.Log("bro1");
                retour();
            }
            
        }
    }
    public void instructionPath()
    {
        for (int i = 0; i < images.Length; i++) { images[i].SetActive(false); }
        startBut.interactable = false;
        instrucBut.interactable = false;
        Hsbut.interactable = false;
        quitBut.interactable = false;
        ok = true;
        instructionPan.SetActive(true);
        retourButton.SetActive(true);
        m_EventSystem.SetSelectedGameObject(retourButton);
    }
    public void highscore()
    {
        for (int i = 0; i < images.Length; i++) { images[i].SetActive(false); }
        startBut.interactable = false;
        instrucBut.interactable = false;
        Hsbut.interactable = false;
        quitBut.interactable = false;
        ok = true;
        retourButton.SetActive(true);
        panHs.SetActive(true);
        m_EventSystem.SetSelectedGameObject(but1PlayerHS);
    }
    public void quitter()
    {
        Application.Quit();
    }
    public void retour()
    {
        for (int i = 0; i < images.Length; i++) { images[i].SetActive(true); }
        startBut.interactable = true;
        instrucBut.interactable = true;
        Hsbut.interactable = true;
        quitBut.interactable = true;
        instructionPan.SetActive(false);
        retourButton.SetActive(false);
        panHs.SetActive(false);
        m_EventSystem.SetSelectedGameObject(startBut.gameObject);
        ok = false;
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
