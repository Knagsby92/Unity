using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this);
    }
    public void LoadGame(string name)
    {
        StartCoroutine(LoadGameAsync(name));
    }
    private IEnumerator LoadGameAsync(string name)
    {
        SceneManager.LoadSceneAsync(1);
        while (SceneManager.GetActiveScene().buildIndex != 1)
        {
            yield return null;
        }
        GameController.instance.StartGame(name);
    }
    public void NewGame(string name)
    {
        SaveSystem.NewGame(name);
        StartCoroutine(LoadGameAsync(name));
    }
}
