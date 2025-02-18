using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    static MiniGameManager miniGameManager;
    public static MiniGameManager Instance => miniGameManager;

    MiniGameUIManager uimanager;
    public MiniGameUIManager UIManager => uimanager;
    private float score;
    private float currentScore = 0;
    private float bestScore;

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
    }
}
