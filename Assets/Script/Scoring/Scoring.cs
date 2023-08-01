/*
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public TMP_Text scoretext;
    public int score;

    public static Scoring Instance;
    void Start()
    {
        Instance = this;
        ShowScore();
    }

    public static void AddScore(int addedScore)
    {
        Instance.score += addedScore;
        Instance.ShowScore();
    }

    private void ShowScore() => scoretext.text = score.ToString();

}
*/