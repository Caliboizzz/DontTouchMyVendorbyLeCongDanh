using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public int scoreBudget;

    public static int GetScoreBudget;
    public TMP_Text scoretext;
    public static Scoring Instance;

    
    // Start is called before the first frame update
    private void Update()
    {
        Instance = this;
        GetScoreBudget=scoreBudget;
        ShowScore();
    }

    public static void AddScore(int addedScore)
    {
        Instance.scoreBudget += addedScore;
        Instance.ShowScore();
    }

    public static void ReduceScore(int ScoreReduce)
    {
        Instance.scoreBudget -= ScoreReduce;
        Instance.ShowScore();
    }


    private void ShowScore() => scoretext.text = scoreBudget.ToString();
}
