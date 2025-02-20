using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isTalking = false;
    [SerializeField] private int playingCount =0;
    public int PlayingCount { get => playingCount; set { playingCount = value; } }
    private Vector3 savePlayerPos;
    public Vector3 SavePlayerPos { get => savePlayerPos; set => savePlayerPos = value; }
    private float bestScore;
    public float BestScore { get => bestScore; set => bestScore = value; }
    private Color playerColor;
    public Color PlayerColor { get => playerColor; set => playerColor = value; }
    private bool isColor = false;
    public bool IsColor { get => isColor; set => isColor = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
