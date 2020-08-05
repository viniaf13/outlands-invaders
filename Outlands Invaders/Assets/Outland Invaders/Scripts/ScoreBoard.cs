using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private int totalScore = 0;
    private TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score: " + totalScore.ToString("00000");
    }

    public void AddToScore(int amount)
    {
        totalScore += amount;
        scoreText.text = "Score: " + totalScore.ToString("00000");
    }
}
