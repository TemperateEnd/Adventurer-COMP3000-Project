using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Adventurer/Quest/Quest Reward", order = 0)]
public class QuestReward : ScriptableObject
{
    public int goldEarned;
    public List<Item> itemsEarned;
}
