using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    {
        currentObjective = objectivesList[0];
    }

    // Update is called once per frame
    public void progressQuest(int newQuestObjIndex)
    {
        if(currentObjective = objectivesList.Last())
            endQuest();

        else
            currentObjective = objectivesList[newQuestObjIndex];
    }
}
