using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float loadDelay = 1.5f;
    [SerializeField] int currentSceneIndex;

    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void RestartLevel()
    {
        StartCoroutine(LoadLevel(currentSceneIndex));
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex+1);
        currentSceneIndex++;
    }

    private IEnumerator LoadLevel(int sceneIndex)
    {
        yield return new WaitForSeconds(loadDelay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneIndex);
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
}
