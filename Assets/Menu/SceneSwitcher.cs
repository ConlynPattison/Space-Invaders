using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string gameSceneName;
    public string creditsSceneName;
    public string menuSceneName;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        ScoreManager.OnGameOver += LoadCreditsScene;
    }

    public void LoadGameScene()
    {
        StartCoroutine(LoadAndSetup(gameSceneName));
    }

    public void LoadCreditsScene()
    {
        StartCoroutine(LoadAndSetup(creditsSceneName));
        StartCoroutine(DelayedLoadMenuScene());
    }

    public void LoadMenuScene()
    {
        StartCoroutine(LoadAndSetup(menuSceneName));
    }

    IEnumerator DelayedLoadMenuScene()
    {
        yield return new WaitForSeconds(10f);
        LoadMenuScene();
    }

    IEnumerator LoadAndSetup(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        yield return new WaitForSeconds(0.1f);
        
    }
}
