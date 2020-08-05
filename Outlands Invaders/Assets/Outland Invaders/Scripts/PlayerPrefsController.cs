using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string HIGHSCORE_KEY = "highscore";

    public static void SetHighscore(int score)
    {
        PlayerPrefs.SetInt(HIGHSCORE_KEY, score);
    }
    public static int GetHighscore()
    {
        return PlayerPrefs.GetInt(HIGHSCORE_KEY, 0);
    }
}
