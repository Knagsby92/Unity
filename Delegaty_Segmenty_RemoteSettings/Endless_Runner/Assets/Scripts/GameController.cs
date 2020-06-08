using UnityEngine;
using System.Collections;
using TMPro;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEditor.Analytics;
using UnityEngine.Analytics;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public Transform player;
    public static GameController Instance;

    [SerializeField] int lifes = 3;
    int score = 0;
    int bestScore = 0;

    public static UnityAction DamageFade;
    public static UnityAction<float> UpdateTimerUI;
    public static UnityAction<int> UpdateScoreUI;
    public static UnityAction<int> UpdateLifesUI;
    public static UnityAction<int> UpdateBestScoreUI;

    float startTime = 0;
    string bestScoreName = "BestScore";
    float time = 0;
    int nextScene;


    private void Awake()
    {
        Instance = this;
        startTime = Time.time;
        bestScore = PlayerPrefs.GetInt(bestScoreName, 0);
        UpdateBestScoreUI?.Invoke(bestScore);
        UpdateLifesUI?.Invoke(lifes);

        player.GetComponent<PlayerController>().jumpHeight = UnityEngine.RemoteSettings.GetFloat("jumpHeight");
        AnalyticsResult result = Analytics.CustomEvent("NewGame");
       
        
    }
    public void IncreasePoints()
    {
        score++;
        UpdateScoreUI?.Invoke(score);
    }
    public void DecreaseLifes()
    {
        lifes--;
        UpdateLifesUI?.Invoke(lifes);
        DamageFade?.Invoke();
        if (lifes == 0)
        {
          
            string timeInSec = time.ToString("mm\\:ss");
            AnalyticsResult result = AnalyticsEvent.Custom("Died in : ", new Dictionary<string, object>
            {
                { "Id", 1},
                { "TimeDiedAt", timeInSec}
            });
            GameOver();
        }
    }
    public void GameOver()
    {
        if (score > bestScore)
        {
            AnalyticsResult result2 = AnalyticsEvent.Custom("PreviousHighScore", new Dictionary<string, object>
            {
                { "Id", 2},
                { "BeatenScore", bestScore},
                { "NewBestScore", score},
                { "Time",Time.time}
            });

            PlayerPrefs.SetInt(bestScoreName, score);
            Debug.Log(result2);
        }
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        UpdateTimerUI?.Invoke(time);
    }
    private void Quit()
    {
        AnalyticsResult data = Analytics.CustomEvent("GameOver");
        Analytics.FlushEvents();
    }
}
