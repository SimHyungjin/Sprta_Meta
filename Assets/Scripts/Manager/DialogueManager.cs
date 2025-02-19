using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public TMP_Text dialogueText;
    public GameObject dialoguePanel;
    public SpriteRenderer changeScenepanel;
    public Transform player;
    private string[] dialogues;
    private int dialogueIndex;
    private bool onDialog;

    private string currentKey;
    public string CurrentKey { set => currentKey = value; }

    private readonly Dictionary<string, string[]> dialogueData = new Dictionary<string, string[]>
    {
        { "Chick_0", new string[] { "Hello", "Do you want to play a game?", "Well, no matter what you say, the game starts.", "Let's get started" } },
        { "Chick_1", new string[] { "Hello", "Are you going to play again?" } },
        { "Chick2_0", new string[] { "You've never played a game.", "Get out of here!" } },
        { "Chick2_1", new string[] { "You played a game.", } },
        { "Manual_0", new string[] { "If you want to play a game, Find the chicken." } },
        { "Manual_1", new string[] { "If you tell me how to play the game","I've done everything I can","Get out!" } }
    };

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Update()
    {
        if (dialogues != null && Input.GetKeyDown(KeyCode.Z))
        {
            GameManager.Instance.isTalking = true;
            ShowDialogue();
        }
    }
    public void SetDialogues()
    {
        dialogues = dialogueData[currentKey];
    }
    public void ShowDialogue()
    {
        if (dialogueIndex < dialogues.Length)
        {
            onDialog = true;
            dialogueText.text = dialogues[dialogueIndex];
            dialoguePanel.SetActive(true);
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
        GameManager.Instance.isTalking = false;
        GameManager.Instance.SavePlayerPos = player.transform.position;
        if (dialogues == dialogueData["Chick_0"] || dialogues == dialogueData["Chick_1"])
        {
            StartCoroutine(FadeIn(0.2f));
            Invoke(nameof(LoadJumpGameScene), 0.2f);
        }
        dialogues = null;
    }

    private void LoadJumpGameScene()
    {
        GameManager.Instance.ChangeScene("JumpGameScene");
    }

    private IEnumerator FadeIn(float duration)
    {
        float elapsed = 0f;
        Color startColor = changeScenepanel.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1f);
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            changeScenepanel.color = Color.Lerp(startColor, endColor, elapsed / duration);
            yield return null;
        }
        changeScenepanel.color = endColor;
    }

}

