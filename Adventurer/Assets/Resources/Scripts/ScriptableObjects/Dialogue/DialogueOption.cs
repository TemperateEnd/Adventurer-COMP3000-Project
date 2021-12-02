using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueOption", menuName = "Adventurer/Dialogue/DialogueOption", order = 0)]
public class DialogueOption : ScriptableObject 
{
    public string optionText;
    public DialogueLine responseToOption;
    public bool endsDialogue;
}
