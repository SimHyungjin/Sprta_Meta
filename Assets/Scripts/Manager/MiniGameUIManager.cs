using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI resultText;

    public GameObject startPanel;
    public GameObject tippanel;

    public void SetStartPanel()
    {
        startPanel.gameObject.SetActive(false);
    }
    public void SetTipPanel()
    {
        tippanel.gameObject.SetActive(true);
    }
    public void UpdateScore(float score)
    {
        scoreText.text = score.ToString("F2");
    }
    public void currentScore(float score)
    {
        currentScoreText.text = score.ToString("F2");
    }
    public void BestScore(float score)
    {
        if(PlayerPrefs.HasKey("BestScore"))
        {
            float bestScore = PlayerPrefs.GetFloat("BestScore");
            if (bestScore > score)
            {
                MiniGameManager.Instance.BestScore = score;
                PlayerPrefs.SetFloat("BestScore", score);
                PlayerPrefs.Save();
            }  
        }
        else
        {
            MiniGameManager.Instance.BestScore = score;
            PlayerPrefs.SetFloat("BestScore", score);
            PlayerPrefs.Save();
        }
        bestScoreText.text = PlayerPrefs.GetFloat("BestScore").ToString("F2");
    }
    public void ResultText(float score)
    {
        if (score < 20f)
            resultText.text = "I think you pressed the a key";
        else
            resultText.text = "It's so slow";
    }

}
