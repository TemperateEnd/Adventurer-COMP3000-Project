using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Adventurer/Quest/Quest Objectives/Deliver Item", order = 0)]
public class DeliverQuestObjective : QuestObjective
{
    public Item itemToDeliver;
    public GameObject npcToDeliverTo;
}
