using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questLogBackend : MonoBehaviour
{
    public List<Quest> acceptedQuests;
    public Quest currentlySelectedQuest;
    public questLogUI uiScript;

    void Start() 
    {
        uiScript.questLog = this;
    }

    public void addQuestToList(Quest questToAdd)
    {
        acceptedQuests.Add(questToAdd);

        if(questToAdd.currentObjective.GetType() == typeof(ContactQuestObjective))
            EventManager.TriggerEvent("ContactObjectiveStart", questToAdd.currentObjective);
        else if(questToAdd.currentObjective.GetType() == typeof(DeliverQuestObjective))
            EventManager.TriggerEvent("DeliverObjectiveStart", questToAdd.currentObjective);
        else if(questToAdd.currentObjective.GetType() == typeof(KillQuestObjective))
            EventManager.TriggerEvent("KillObjectiveStart", questToAdd.currentObjective);

    }

    public void updateQuestProgress(Quest questToUpdate)
    {
        questToUpdate.currentObjective.progressTowardsObj++; //for example, kill 1 wolf, progressTowardsObj should equal 1
        if(questToUpdate.currentObjective.progressTowardsObj == questToUpdate.currentObjective.objGoalNumber) //if progress int = goal number, then move onto next objective IF next objective isn't null
        {
            questToUpdate.progressQuest();
            if(questToUpdate.currentObjective.nextObjective = null)
            {
                acceptedQuests.Remove(questToUpdate);
            }

            else
            {
                
                if(questToUpdate.currentObjective.GetType() == typeof(ContactQuestObjective))
                    EventManager.TriggerEvent("ContactObjectiveStart", questToUpdate.currentObjective.nextObjective);

                else if (questToUpdate.currentObjective.GetType() == typeof(DeliverQuestObjective))
                    EventManager.TriggerEvent("DeliverObjectiveStart", questToUpdate.currentObjective.nextObjective);

                else if (questToUpdate.currentObjective.GetType() == typeof(KillQuestObjective))
                        EventManager.TriggerEvent("KillObjectiveStart", questToUpdate.currentObjective.nextObjective);
            }
        }
    }

    public void questProgressTracking(object questData)
    {
        foreach(Quest acceptedQuest in acceptedQuests)
        {
            if(acceptedQuest.currentObjective.GetType() == typeof(KillQuestObjective))
            {
                string nameOfRecentNPC = (string)questData;
                KillQuestObjective objectiveToCheck = (KillQuestObjective)acceptedQuest.currentObjective;
                if(objectiveToCheck.npcToKill == nameOfRecentNPC)
                {
                    updateQuestProgress(acceptedQuest);
                }
            }

            if(acceptedQuest.currentObjective.GetType() == typeof(DeliverQuestObjective))
            {
                Item itemObtained = (Item)questData;
                DeliverQuestObjective objectiveToCheck = (DeliverQuestObjective)acceptedQuest.currentObjective;
                if(objectiveToCheck.itemToDeliver == itemObtained)
                {
                    updateQuestProgress(acceptedQuest);
                }
            }

            if(acceptedQuest.currentObjective.GetType() == typeof(ContactQuestObjective))
            {
                DialogueOption selectedOption = (DialogueOption)questData;
                ContactQuestObjective objectiveToCheck = (ContactQuestObjective)acceptedQuest.currentObjective;
                if(objectiveToCheck.optionToSelect == selectedOption)
                {
                    updateQuestProgress(acceptedQuest);
                }
            }
        }
    }
}
