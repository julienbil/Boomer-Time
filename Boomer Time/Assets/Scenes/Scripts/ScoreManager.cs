using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int scoreP1 = 0;
    public int scoreP2 = 0;
    public Text scoreText1;
    public Text scoreText2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        scoreText1.text = "Score : " + scoreP1;
        scoreText2.text = "Score : " + scoreP2;
    }
}
