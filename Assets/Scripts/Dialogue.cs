using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;
using System;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    [SerializeField] string characterName;
    
    [Space]
    [Header("Dialogue")]
    [SerializeField] GameObject dialogueMask;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    
    [Space]
    [SerializeField, Range(0f, 0.1f)] float typingTime;
    

    [SerializeField] ReadDataCVS rd;
    [SerializeField] PlayerController player;
    
    List<DialogueLine> dialogueLines;

    bool isPlayerInRange;
    bool didDialogueStart;
    int lineIndex;
    int dialogueNumber;
    int firstDialogueLineNumber;

    // Start is called before the first frame update
    void Start()
    {
        dialogueLines = rd.GetDialogueLines();

        GetFirstDialogueLine();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange && Input.GetButtonDown("Interaction"))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[firstDialogueLineNumber + lineIndex].text)
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[firstDialogueLineNumber + lineIndex].text;
            }
        }
    }

    private void StartDialogue()
    {
        didDialogueStart  = true;
        dialoguePanel.SetActive(true);
        dialogueMask.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines[firstDialogueLineNumber + lineIndex + 1].lineNumber)
        {
            StartCoroutine(ShowLine());
        }
        else 
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMask.SetActive(true);
            Time.timeScale = 1f;
        }
    }
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach(char ch in dialogueLines[firstDialogueLineNumber + lineIndex].text)
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMask.SetActive(true);
        }
    }

    private void GetFirstDialogueLine()
    {
        int i = 0;
        bool seguir = true;

        List<DialoguePair> ldp = rd.GetActiveDialogeLine();

        while (i < dialogueLines.Count && seguir)
        {
            if (dialogueLines[i].receptor == characterName)
            {
                foreach (DialoguePair pair in ldp)
                {
                    if (pair.receptor == characterName)
                    {
                        dialogueNumber = pair.dialogueNumber;
                        firstDialogueLineNumber = i;
                        seguir = false;
                        break;
                    }
                }
            }
            i++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMask.SetActive(false);
        }
    }
}