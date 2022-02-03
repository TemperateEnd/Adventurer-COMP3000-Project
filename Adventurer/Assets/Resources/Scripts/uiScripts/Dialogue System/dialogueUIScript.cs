using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogueUIScript : MonoBehaviour
{
    private DialogueLine currentLine;
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

    public void EndDialogue(DialogueOption option)
    {
        for(int i = 0; i < currentLine.availableOptions.Length;i++)
        {
            dialogueResponseButtons[i].SetActive(false);
        }

        currentLine = null;
        currentTree = null;

        StateManager.InstanceRef.toggleDialogueActive = false;
    }

    public void DialogueOptionSelected(DialogueOption optionSelected)
    {
        //if endDialogue bool is true and there is no line attached to dialogue option, end dialogue
        if((optionSelected.optionOutcome == optionType.END) && (optionSelected.responseToOption == null))
        {
            Debug.Log("Ending dialogue");
            EndDialogue(optionSelected);
        }

        //if option has a response, continue dialogue
        else if (optionSelected.optionOutcome == optionType.CONTINUE)
        {
            ChangeLine(optionSelected.responseToOption);
        }

        else if (optionSelected.optionOutcome == optionType.BARTER)
        {
            StateManager.InstanceRef.toggleBartering = true;
            StateManager.InstanceRef.gameState = GameState.Barter;
        }

        else if(optionSelected.optionOutcome == optionType.ATTACK) //This will be expanded upon when making combat system and enemy AI
        {
            Debug.Log("Enemy should be hostile");
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
