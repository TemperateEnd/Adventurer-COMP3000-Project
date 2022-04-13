using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Quest", menuName = "Adventurer/Quest/Quest", order = 0)]
public class Quest : ScriptableObject 
{
    public string questName;
    public List<QuestObjective> objectivesList;
    public QuestObjective currentObjective;
    public QuestReward reward;

    // Start is called before the first frame update
    public void startQuest()
    {}

    // Update is called once per frame
    public void progressQuest()
    {}

    public void endQuest()
    {}

    public void rewardPlayer()
    {}
}
