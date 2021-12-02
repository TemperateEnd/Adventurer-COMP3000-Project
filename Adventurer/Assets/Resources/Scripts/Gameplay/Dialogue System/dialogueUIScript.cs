using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogueUIScript : MonoBehaviour
{
    public DialogueLine currentLine;
    public DialogueTree currentTree;
    [Header("UI Components")]
    public GameObject[] dialogueResponseButtons;
    public TextMeshProUGUI dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        ChangeLine(currentTree.rootDialogue);
    }

    // Update is called once per frame
    void Update()
    {
        dialogueText.SetText(currentTree.npcName + ": " + currentLine.dialogueText);
    }

    public void EndDialogue()
    {
        for(int i = 0; i < currentLine.availableOptions.Length;i++)
        {
            dialogueResponseButtons[i].SetActive(false);
        }
        currentLine = null;
        currentTree = null;

        this.gameObject.SetActive(false);
    }

    public void DialogueOptionSelected(DialogueOption optionSelected)
    {
        ChangeLine(optionSelected.responseToOption);

        if(optionSelected.endsDialogue)
        {
            EndDialogue();
        }
    }

    public void ChangeLine(DialogueLine nextLine)
    {
        currentLine = nextLine;

        for(int i = 0; i < currentLine.availableOptions.Length;i++)
        {
            dialogueResponseButtons[i].SetActive(true);
            dialogueResponseButtons[i].GetComponent<dialogueButtonScript>().optionRepresented = currentLine.availableOptions[i];
        }
    }
}
