using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public TMP_Text dialogueText;
    public GameObject dialoguePanel;
    private string[] dialogues;
    private int dialogueIndex;
    private bool onDialog;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Update()
    {
        if (onDialog == true && Input.GetKeyDown(KeyCode.Z))
        {
            DisplayNextLine();
        }
    }

    public void StartDialogue(string[] dialogue)
    {
        onDialog = true;
        dialogues = dialogue;
        dialogueText.text = dialogues[0];
        dialogueIndex = 1;
        dialoguePanel.SetActive(true);
    }
    public void DisplayNextLine()
    {
        if (dialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[dialogueIndex];
            dialogueIndex++;
        }
        else
            EndDialogue();
    }
    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        dialogueIndex = 0;
        onDialog = false;
    }


}
