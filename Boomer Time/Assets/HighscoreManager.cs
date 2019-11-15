using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighscoreManager
{
    static public Highscore highscore1P = new Highscore();
    static public Highscore highscore2P = new Highscore();
    static public string nom = null;
    static public int pos=0;

    public static void CheckNewHS1P(int score)
    {
        bool found = false;
        for(int i = 0; i < highscore1P.score.Length&&!found; i++)
        {
            if (score > highscore1P.score[i])
            {
                Decalage(highscore1P,i);
                highscore1P.score[i] = score;
                EndingScript.monkey = true;
                pos = i;
                found = true;
            }
        }
    }

    public static void ReceiveName1P(string name)
    {
        highscore1P.nom[pos] = name;
        Save();
    }

    public static void ReceiveName2P(string name)
    {
        highscore2P.nom[pos] = name;
        Save();
    }

    public static void CheckNewHS2P(int score)
    {
        bool found = false;
        for (int i = 0; i < highscore2P.score.Length && !found; i++)
        {
            if (score > highscore1P.score[i])
            {
                Decalage(highscore2P, i);
                highscore2P.score[i] = score;
                EndingScript.monkey = true;
                pos=i;
                found = true;
            }
        }
    }

    public static string EntrerNom()
    {
        return "o";
    }

    public static void Load()
    {
        string json1P = File.ReadAllText(@"highscore1P.json");
        string json2P = File.ReadAllText(@"highscore2P.json");
        highscore1P = JsonUtility.FromJson<Highscore>(json1P.ToString());
        highscore2P = JsonUtility.FromJson<Highscore>(json2P.ToString());
    }

    public static void Save()
    {
        string json1P = JsonUtility.ToJson(highscore1P);
        string json2P = JsonUtility.ToJson(highscore2P);
        File.WriteAllText(@"highscore1P.json", json1P);
        File.WriteAllText(@"highscore2P.json", json2P);
    }

    public static void Decalage(Highscore highscore, int pos)
    {
        for(int i=highscore.score.Length-1;i>pos; i--)
        {
            highscore.score[i] = highscore.score[i - 1];
            highscore.nom[i] = highscore.nom[i - 1];
        }
    }
}
