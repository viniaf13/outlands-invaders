using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] GameObject currentScore = default;
    [SerializeField] GameObject highscore = default;

    private int totalScore = 0;
    private int maxScore = 0;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI highscoreText;

    void Start()
    {
        scoreText = currentScore.GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score: " + totalScore.ToString("00000");

        maxScore = PlayerPrefsController.GetHighscore();
        highscoreText = highscore.GetComponent<TextMeshProUGUI>();
        highscoreText.text = "Highscore: " + maxScore.ToString("00000");
    }

    public void AddToScore(int amount)
    {
        totalScore += amount;
        scoreText.text = "Score: " + totalScore.ToString("00000");
    }

    public void EndScoreSession()
    {
        PlayerPrefsController.SetCurrentScore(totalScore);
        if (totalScore > maxScore)
        {
            PlayerPrefsController.SetHighscore(totalScore);
        }
    }
}
