using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

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
    public string number,name,score,highscoreBoard, number1, name1, score1, highscoreBoard1;
    public int scoreTemp,scoreTemp1;
    public TextMeshProUGUI highScoreBoard;
    public TextMeshProUGUI highScoreBoard1;
   /* public static List<int> scoreList = new List<int>();
    public static List<int> scoreList1 = new List<int>();
    public static List<string> nameList = new List<string>();
    public static List<string> nameList1 = new List<string>();
    public static List<string> numberList = new List<string>();*/


    void Start()
    {
            TextAsset textCVS = Resources.Load<TextAsset>("highscoreFile");
            string[] data = textCVS.text.Split(new char[] { '\n' });

            for (int i = 1; i < data.Length - 1; i++)
            {
                string[] rangee = data[i].Split(new char[] { ';' });
                number = rangee[0];
                name = rangee[1];
                score = rangee[2];
                highscoreBoard = (number + "\t" + name + "\t" + score);
                highScoreBoard.text = (highScoreBoard.text + "\n " + highscoreBoard);
               // scoreTemp = int.Parse(score);
               // scoreList.Add(scoreTemp);
            }
        
            TextAsset textCVS1 = Resources.Load<TextAsset>("highscoreFile1");
            string[] data1 = textCVS1.text.Split(new char[] { '\n' });

            for (int i = 1; i < data1.Length - 1; i++)
            {
            string[] rangee1 = data1[i].Split(new char[] { ';' });
            number1 = rangee1[0];
            name1 = rangee1[1];
            score1 = rangee1[2];
            highscoreBoard1 = (number1 + "\t" + name1 + "\t" + score1);
            highScoreBoard1.text = (highScoreBoard1.text + "\n " + highscoreBoard1);
            //scoreTemp1 = int.Parse(score1);
            //scoreList1.Add(scoreTemp1);
        }
        
        m_EventSystem = EventSystem.current;
        
    }
    public void start()
    {
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
            if (ok)
            {
                retour();
            }
            
        }
    }
    public void instructionPath()
    {
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
        but1PlayerHS.SetActive(true);
        but2PlayerHS.SetActive(true);
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
        highScoreBoard.gameObject.SetActive(false);
        highScoreBoard1.gameObject.SetActive(false);
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
              SceneManager.LoadScene("SampleScene1P");
                break;
            case 2:
                nbeDeJoueur = false;
                SceneManager.LoadScene("Scene2P");
                break;

        }
        
    }
    public void hs1Player()
    {
        highScoreBoard.gameObject.SetActive(true);
        but1PlayerHS.SetActive(false);
        but2PlayerHS.SetActive(false);
    }
    public void hs2Player()
    {
        highScoreBoard1.gameObject.SetActive(true);
        but1PlayerHS.SetActive(false);
        but2PlayerHS.SetActive(false);
    }
    
}
