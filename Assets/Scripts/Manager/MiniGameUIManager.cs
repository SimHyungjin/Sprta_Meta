using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
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
}
