using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueLine", menuName = "Adventurer/Dialogue/DialogueLine", order = 0)]
public class DialogueLine : ScriptableObject
{
    public string dialogueText;
    public DialogueOption[] availableOptions;
}
