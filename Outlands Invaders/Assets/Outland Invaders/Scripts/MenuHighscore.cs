using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHighscore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            int highscore = PlayerPrefsController.GetHighscore();
            GetComponent<TextMeshProUGUI>().text = highscore.ToString("00000");
        }
        else
        {
            int currentscore = PlayerPrefsController.GetCurrentScore();
            GetComponent<TextMeshProUGUI>().text = currentscore.ToString("00000");
        }
    }
}
