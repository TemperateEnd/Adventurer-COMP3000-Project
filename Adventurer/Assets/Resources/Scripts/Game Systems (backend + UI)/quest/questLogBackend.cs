using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questLogBackend : MonoBehaviour
{
    private questLogBackend questLog;
    public static questLogBackend questLogInstance;
    public List<Quest> acceptedQuests;

    public static void addQuestToList(Quest questToAdd)
    {
        questLogInstance.acceptedQuests.Add(questToAdd);
    }

    public void updateQuestProgress(Quest questToUpdate)
    {
        questToUpdate.currentObjective.progressTowardsObj++; //for example, kill 1 wolf, progressTowardsObj should equal 1
        questToUpdate.currentObjective.evaluateObjectiveComplete(); //checks if you met the requirements, before returning whether you have (i.e. progressTowardsObj = 1 where ObjGoalNumber = 2
                                                                    //would return false, whereas both progress and goal numbers would return true if matching)
        if(questToUpdate.currentObjective.evaluateObjectiveComplete()) { //if true, consider quest complete, reward player, and remove quest from list
            questToUpdate.progressQuest();
            if(questToUpdate.currentObjective.nextObjective = null)
            {
                acceptedQuests.Remove(questToUpdate);
            }
        }
    }

    public static void questProgressTracking(object questData)
    {
        foreach(Quest acceptedQuest in questLogInstance.acceptedQuests)
        {
            if(acceptedQuest.currentObjective.GetType() == typeof(KillQuestObjective))
            {
                string nameOfRecentNPC = (string)questData;
                KillQuestObjective objectiveToCheck = (KillQuestObjective)acceptedQuest.currentObjective;
                if(objectiveToCheck.npcToKill == nameOfRecentNPC)
                {
                    questLogInstance.updateQuestProgress(acceptedQuest);
                }
            }

            if(acceptedQuest.currentObjective.GetType() == typeof(DeliverQuestObjective))
            {
                Item itemObtained = (Item)questData;
                DeliverQuestObjective objectiveToCheck = (DeliverQuestObjective)acceptedQuest.currentObjective;
                if(objectiveToCheck.itemToDeliver == itemObtained)
                {
                    questLogInstance.updateQuestProgress(acceptedQuest);
                }
            }

            if(acceptedQuest.currentObjective.GetType() == typeof(ContactQuestObjective))
            {
                DialogueOption selectedOption = (DialogueOption)questData;
                ContactQuestObjective objectiveToCheck = (ContactQuestObjective)acceptedQuest.currentObjective;
                if(objectiveToCheck.optionToSelect == selectedOption)
                {
                    questLogInstance.updateQuestProgress(acceptedQuest);
                }
            }
        }
    }
}
