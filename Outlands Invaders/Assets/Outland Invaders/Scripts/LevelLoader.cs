using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float loadDelay = 1.5f;
    [SerializeField] int currentSceneIndex;

    /*private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }*/

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void RestartLevel()
    {
        StartCoroutine(LoadLevel(currentSceneIndex, loadDelay));
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex+1);
        currentSceneIndex++;
    }

    public void LoadWinScreen()
    {
        StartCoroutine(LoadLevel(currentSceneIndex+1, loadDelay * 4));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        currentSceneIndex = 0;
    }

    private IEnumerator LoadLevel(int sceneIndex, float delay)
    {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneIndex);
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
}
