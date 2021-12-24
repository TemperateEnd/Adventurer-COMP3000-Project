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

    //Displays root dialogue whenever script is enabled
    void OnEnable()
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

        StateManager.InstanceRef.toggleDialogueActive = false;
        this.gameObject.SetActive(false);
    }

    public void DialogueOptionSelected(DialogueOption optionSelected)
    {
        //if endDialogue bool is true and there is no line attached to dialogue option, end dialogue
        if(optionSelected.endsDialogue && (optionSelected.responseToOption == null))
        {
            Debug.Log("Ending dialogue");
            EndDialogue();
        }

        //if option has a response, continue dialogue
        else
        {
            ChangeLine(optionSelected.responseToOption);
        }
    }

    public void ChangeLine(DialogueLine nextLine)
    {
        currentLine = nextLine;

        for(int i = 0; i < dialogueResponseButtons.Length; i++)
        {
            for(int j = 0; j < currentLine.availableOptions.Length; j++)
            {
                if(i > j)
                {
                    dialogueResponseButtons[i].SetActive(false);
                }

                else
                {
                    dialogueResponseButtons[i].SetActive(true);
                    dialogueResponseButtons[i].GetComponent<dialogueButtonScript>().optionRepresented = currentLine.availableOptions[i];
                }
            } 
        }
    }
}
