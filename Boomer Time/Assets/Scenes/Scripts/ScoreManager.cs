using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        int m, s, d;
        m = (int)(time / 60f);
        s = (int)(time%60);
        d = (int)(time * 100f);
        string decimalT = d.ToString();
        if(decimalT.Length==1)
            timerText.text = m.ToString() + ":" + s.ToString() + ":" + decimalT[decimalT.Length - 1];
        else
            timerText.text = m.ToString() + ":" + s.ToString() + ":" + decimalT[decimalT.Length - 2] + decimalT[decimalT.Length - 1];

        scoreP1 += 50 * Time.deltaTime;
        scoreP2 += 50 * Time.deltaTime;

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
