using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChager : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpriteRenderer playerSprite = collision.gameObject.GetComponentInChildren<SpriteRenderer>();

            if (playerSprite != null)
            {
                
                playerSprite.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
                Debug.Log("»ö º¯°æ" + playerSprite.color);
            }
        }
    }

}
