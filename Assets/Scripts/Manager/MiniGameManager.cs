using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    static MiniGameManager miniGameManager;
    public static MiniGameManager Instance => miniGameManager;

    MiniGameUIManager uimanager;
    public MiniGameUIManager UIManager => uimanager;
    private float currentScore = 0;
    public float CurrentScore { get => currentScore; set { currentScore = value; } }
    private float bestScore = 0;
    public float BestScore { get => bestScore; set { bestScore = value; } }
    private bool endGame = false;
    public bool EndGame { get => EndGame; set { endGame = value; } }

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI BestScoreText;

    private void Awake()
    {
        miniGameManager = this;
        uimanager = FindAnyObjectByType<MiniGameUIManager>();
    }
    private void Start()
    {
        Time.timeScale = 0;
        uimanager.UpdateScore(0);
    }
    private void Update()
    {
        if (Time.timeScale == 0 && Input.GetKeyUp(KeyCode.Space))
        {
            uimanager.SetStartPanel();
            Time.timeScale = 1;
        }
        if(Time.timeScale == 1)
        {
            currentScore += Time.deltaTime;
            uimanager.UpdateScore(currentScore);
            if(currentScore > 10)
            {
                uimanager.SetTipPanel();
            }
        }
        if (endGame)
        {
            uimanager.ResultText(currentScore);
            uimanager.currentScore(currentScore);
            uimanager.BestScore(currentScore);
            if (Input.GetKeyUp(KeyCode.Space))
            {
                endGame = false;
                GameManager.Instance.ChangeScene("MainScene");
            }  
        }
    }
}
