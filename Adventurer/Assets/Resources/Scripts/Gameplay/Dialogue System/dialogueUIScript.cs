using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogueUIScript : MonoBehaviour
{
    public DialogueLine currentLine;
    public DialogueTree currentTree;
    public string[] dialogueRecord;
    [Header("UI Components")]
    public GameObject dialogueRecordUI;
    public GameObject[] dialogueResponseButtons;
    public TextMeshProUGUI dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        currentLine = currentTree.rootDialogue;
    }

    // Update is called once per frame
    void Update()
    {
        dialogueText.SetText(currentTree.npcName + ": " + currentLine);

        for(int i = 0; i < currentLine.availableOptions.Length;i++)
        {
            dialogueResponseButtons[i].SetActive(true);
        }
    }

    public void EndDialogue()
    {
        for(int i = 0; i < currentLine.availableOptions.Length;i++)
        {
            dialogueResponseButtons[i].SetActive(false);
        }
        currentLine = null;
        currentTree = null;
        Array.Clear(dialogueRecord, 0, dialogueRecord.Length);

        this.gameObject.SetActive(false);
    }

    public void DialogueOptionSelected(DialogueOption optionSelected)
    {
        currentLine = optionSelected.responseToOption;
    }
}
