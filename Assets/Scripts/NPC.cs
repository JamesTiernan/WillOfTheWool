using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour, IInteractable
{
    public NPCDialogue dialogueData;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;
    public Image portraitImage;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;


    void Start()
    {
        dialoguePanel = GameObject.Find("DialoguePanel");
        dialogueText = GameObject.Find("DialogueText").GetComponent<TMP_Text>();
        nameText = GameObject.Find("NPCNameText").GetComponent<TMP_Text>();
        portraitImage = GameObject.Find("DialoguePortrait").GetComponent<Image>();
        GameObject.Find("Close").GetComponent<Button>().onClick.AddListener(EndDialogue);
        dialoguePanel.SetActive(false);
    }

    public bool IsInteractable()
    {
        return !isDialogueActive;

    }

    public void Interact()
    {
        if (dialogueData == null)
            return;

        if (isDialogueActive)
        { NextLine(); }
        else
        { StartDialogue(); }
    }


    void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;

        nameText.SetText(dialogueData.name);
        portraitImage.sprite = dialogueData.npcImage;

        dialoguePanel.SetActive(true);


        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(dialogueData.dialogue[dialogueIndex]);
            isTyping = false;
        }
        else if (++dialogueIndex < dialogueData.dialogue.Length)
        { StartCoroutine(TypeLine()); }
        else { EndDialogue(); }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText("");
        foreach (char letter in dialogueData.dialogue[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typeSpeed);

        }
        isTyping = false;

        if (dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSeconds(dialogueData.autoProgressDelay);
            NextLine();
        }
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);

    }
}
