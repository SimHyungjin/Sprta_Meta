using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    private bool isPlayerInRange = false;

    private string[] dialogueLines = new string[]
    {
        "Hello",
        "Do you want to play a game?",
        "Okay, that's the answer, let's get started "
    };

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Z))  // Z키를 눌러 대화 시작
        {
            isPlayerInRange = false;
            DialogueManager.instance.StartDialogue(dialogueLines);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("접근");
            isPlayerInRange = true;
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
