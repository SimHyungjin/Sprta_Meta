using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");

        if (GameManager.Instance.PlayingCount != 0)
            player.transform.position = GameManager.Instance.SavePlayerPos;

        if (GameManager.Instance.IsColor)
        {
            SpriteRenderer renderer = player.GetComponentInChildren<SpriteRenderer>();
            if (renderer != null)
            {
                renderer.color = GameManager.Instance.PlayerColor;
                Debug.Log(renderer.name);
                Debug.Log("색 변화");
                Debug.Log("색 :" + renderer.color);
            }
        }
    }

}
