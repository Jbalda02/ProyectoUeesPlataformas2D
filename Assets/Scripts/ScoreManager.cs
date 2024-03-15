using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int scoreCount;
    public TMP_Text scoreText;
    
    public void AddScore(int points)
    {
        scoreCount += points;
        UpdateScoreText();
    }

    public void ReduceScore(int points)
    {
        scoreCount -= points;
        UpdateScoreText();
    }

    public void ResetScore()
    {
        scoreCount = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + scoreCount;
    }

}