using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    float startTime = 0;
    [SerializeField] GameObject damageFade;
    [SerializeField] TextMeshProUGUI timeValue;
    [SerializeField] TextMeshProUGUI scoreValue;
    [SerializeField] TextMeshProUGUI lifesValue;
    [SerializeField] TextMeshProUGUI bestScoreValue;

    void Awake()
    {
        GameController.DamageFade += OnDamagePanel;
        GameController.UpdateTimerUI += TimerUpdate;
        GameController.UpdateScoreUI += ScoreUpdate;
        GameController.UpdateLifesUI += LifesUpdate;
        GameController.UpdateBestScoreUI += BestScoreUpdate;
    }

    void OnDamagePanel()
    {
        damageFade.SetActive(true);
        Invoke("OffDamagePanel", 0.25f);
    }
    void TimerUpdate(float time)
    {
        timeValue.text = "Timer: " + TimeSpan.FromSeconds(Time.time - startTime).ToString("mm\\:ss");
    }
    void ScoreUpdate(int score)
    {
        scoreValue.text = "Score: " + score;
    }
    void LifesUpdate(int lifes)
    {
        lifesValue.text = "Lifes: " + lifes;
    }
    void BestScoreUpdate(int bestScore)
    {
        bestScoreValue.text = "Best score: " + bestScore;
    }
    void OffDamagePanel()
    {
        damageFade.SetActive(false);
    }
    private void OnDestroy()
    {
        GameController.DamageFade -= OnDamagePanel;
        GameController.UpdateTimerUI -= TimerUpdate;
        GameController.UpdateScoreUI -= ScoreUpdate;
        GameController.UpdateLifesUI -= LifesUpdate;
        GameController.UpdateBestScoreUI -= BestScoreUpdate;
    }

}
