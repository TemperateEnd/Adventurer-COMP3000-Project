using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new DialogueTree", menuName = "Adventurer/Dialogue/DialogueTree", order = 0)]
public class DialogueTree : ScriptableObject
{
    public string npcName;
    public DialogueLine rootDialogue;
}
