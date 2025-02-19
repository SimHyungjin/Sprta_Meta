using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class SortingManager : MonoBehaviour
{
    private List<TilemapRenderer> tileRenderer = new List<TilemapRenderer>();
    private List<SpriteRenderer> spriteRenderer = new List<SpriteRenderer>();
    [SerializeField] private GameObject Player;

    private void Start()
    {
        GameObject[] tileObj = GameObject.FindGameObjectsWithTag("TileObstacle");
        GameObject[] spriteeObj = GameObject.FindGameObjectsWithTag("SpriteObstacle");
        foreach (GameObject obj in tileObj)
        {
            TilemapRenderer to = obj.GetComponent<TilemapRenderer>();
            if (to != null)
                tileRenderer.Add(to);
        }
        foreach (GameObject obj in spriteeObj)
        {
            SpriteRenderer so = obj.GetComponent<SpriteRenderer>();
            if (so != null)
                spriteRenderer.Add(so);
        }
    }
    private void Update()
    {
        foreach (TilemapRenderer obj in tileRenderer)
        {
            if (obj.transform.position.y > Player.transform.position.y)
            {
                obj.sortingOrder = 90;
            }
            else
                obj.sortingOrder = 200;
        }
        foreach (SpriteRenderer obj in spriteRenderer)
        {
            if (obj.transform.position.y > Player.transform.position.y)
            {
                obj.sortingOrder = 90;
            }
            else
                obj.sortingOrder = 200;
        }
    }
}
