using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    private bool isPlayerInRange = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            string npcName = gameObject.name;
            int intKey = GameManager.Instance.PlayingCount;
            if (intKey == 0)
                intKey = 0;
            else
                intKey = 1;
            string key = $"{npcName}_{intKey}";

            DialogueManager.instance.CurrentKey = key;
            DialogueManager.instance.SetDialogues();  
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}

