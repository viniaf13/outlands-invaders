using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuHighscore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int highscore = PlayerPrefsController.GetHighscore();
        GetComponent<TextMeshProUGUI>().text = highscore.ToString("00000");
    }


}
