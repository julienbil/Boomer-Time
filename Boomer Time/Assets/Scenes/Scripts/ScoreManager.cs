using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public float scoreP1 = 0;
    public float scoreP2 = 0;
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI timerText;
    public float time=0;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        if (!startMenu.nbeDeJoueur)
        {
            if (SupaDestroya.dead1 && SupaDestroya.dead2)
            {
                /*score = scoreP1 + scoreP2;
                for(int i = 0; i < 10; i++)
                {
                    if(score > startMenu.scoreList[i])
                    {
                        startMenu.scoreList[i] = score;
                        i = 10;
                    }
                }*/
                SceneManager.LoadScene("Ending");
                SupaDestroya.dead1 = false;
                SupaDestroya.dead2 = false;
            }
        }
        if (startMenu.nbeDeJoueur)
        {
            if (SupaDestroya.dead1)
            {
               /* score = scoreP1 + scoreP2;
                for (int i = 0; i < 10; i++)
                {
                    if (score > startMenu.scoreList1[i])
                    {
                        startMenu.scoreList1[i] = score;
                        i = 10;
                    }
                }*/
                SceneManager.LoadScene("Ending");
                SupaDestroya.dead1 = false;
            }
        }
    }

    public void AddPoints(int player, int nb)
    {
        if(player == 1)
        {
            scoreP1 += nb;
        }
        else
        {
            scoreP2 += nb;
        }

        UpdateScore();
    }

    void UpdateScore()
    {
        time += Time.deltaTime;
        timerText.text = time.ToString("F");

        scoreP1 += 10 * Time.deltaTime;
        scoreP2 += 10 * Time.deltaTime;

        string score1 = ((int)scoreP1).ToString();
        string score1Norm = "";
        for(int i =0; i<8-score1.Length; i++) 
            score1Norm += "0";
        score1Norm += score1;
        string score2 = ((int)scoreP2).ToString();
        string score2Norm = "";
        for (int i = 0; i < 8 - score2.Length; i++)
            score2Norm += "0";
        score2Norm += score2;
        scoreText1.text = score1Norm;
        scoreText2.text = score2Norm;
    }
}
