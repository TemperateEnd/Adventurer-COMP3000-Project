using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "New Quest", menuName = "Adventurer/Quest/Quest", order = 0)]
public class Quest : ScriptableObject 
{
    public string questName;
    public QuestObjective currentObjective;
    public QuestReward reward;


    // Update is called once per frame
    public void progressQuest()
    {
        if(currentObjective.nextObjective)
        {
            currentObjective = currentObjective.nextObjective; //takes next objective after current objective and makes it current objective
        }

        else
        {
            GameObject.Find("StateManager").GetComponent<inventoryScript>().AddGold(reward.goldEarned);

            if(reward.itemsEarned.Count >= 1){
                foreach(Item rewardEarned in reward.itemsEarned)
                GameObject.Find("StateManager").GetComponent<inventoryScript>().AddItemToInventory(rewardEarned);
            }
        }
    }

}
