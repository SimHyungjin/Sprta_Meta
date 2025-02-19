using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    private void Start()
    {
        if(GameManager.Instance.PlayingCount != 0)
            player.position = GameManager.Instance.SavePlayerPos;
    }
}
