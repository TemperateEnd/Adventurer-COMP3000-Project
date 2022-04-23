using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Adventurer/Quest/Quest Objectives/Kill NPC", order = 0)]
public class KillQuestObjective : QuestObjective
{
    public string npcToKill;
}
