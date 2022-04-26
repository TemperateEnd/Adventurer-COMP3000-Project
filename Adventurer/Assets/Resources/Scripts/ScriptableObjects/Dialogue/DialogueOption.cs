using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum optionType { CONTINUE, END, BARTER, ATTACK }
[CreateAssetMenu(fileName = "DialogueOption", menuName = "Adventurer/Dialogue/DialogueOption", order = 0)]
public class DialogueOption : ScriptableObject 
{
    public bool optionEnabled;
    public string optionText;
    public DialogueLine responseToOption;
    public optionType optionOutcome;
    public Quest questToStart;
    public Item itemToGive;
}
