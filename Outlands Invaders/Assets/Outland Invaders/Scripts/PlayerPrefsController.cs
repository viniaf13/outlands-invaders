using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string HIGHSCORE_KEY = "highscore";
    const string CURRENTSCORE_KEY = "currentscore";

    public static void SetHighscore(int score)
    {
        PlayerPrefs.SetInt(HIGHSCORE_KEY, score);
    }
    public static int GetHighscore()
    {
        return PlayerPrefs.GetInt(HIGHSCORE_KEY, 0);
    }
    public static void SetCurrentScore(int score)
    {
        PlayerPrefs.SetInt(CURRENTSCORE_KEY, score);
    }
    public static int GetCurrentScore()
    {
        return PlayerPrefs.GetInt(CURRENTSCORE_KEY, 0);
    }
}
