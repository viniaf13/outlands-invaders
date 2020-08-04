using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float loadDelay = 1.5f;

    private int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void RestartLevel()
    {
        StartCoroutine(LoadLevel(currentSceneIndex));
    }

    private IEnumerator LoadLevel(int sceneIndex)
    {
        yield return new WaitForSeconds(loadDelay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneIndex);
    }

}
