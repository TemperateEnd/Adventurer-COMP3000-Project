using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Adventurer/Quest/Quest Objectives/Contact NPC", order = 0)]
public class ContactQuestObjective : QuestObjective
{
    public DialogueOption optionToSelect;
}
