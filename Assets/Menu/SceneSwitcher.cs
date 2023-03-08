using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string gameSceneName;

    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public void LoadGameScene()
    {
        StartCoroutine(LoadAndSetup());
    }

    IEnumerator LoadAndSetup()
    {
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
        Debug.Log("load started");
        
        // wait 1 frame for loading to complete
        yield return null;
        
        Player player = GameObject.FindObjectOfType<Player>();
        Debug.Log($"Found {player.name}");
    }
}
