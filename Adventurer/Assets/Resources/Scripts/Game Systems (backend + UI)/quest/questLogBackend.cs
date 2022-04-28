using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questLogBackend : MonoBehaviour
{
    public List<Quest> acceptedQuests;
    public Quest currentlySelectedQuest;
    public questLogUI uiScript;

    public void addQuestToList(Quest questToAdd)
    {
        acceptedQuests.Add(questToAdd);
        questToAdd.initDialogue.optionEnabled = false;

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
            questToUpdate.currentObjective.objectiveComplete = true;
            if(questToUpdate.currentObjective.nextObjective)
            {
                Debug.Log(questToUpdate.currentObjective.nextObjective.objectiveText);
                questToUpdate.progressQuest();
                if(questToUpdate.currentObjective.GetType() == typeof(ContactQuestObjective))
                    EventManager.TriggerEvent("ContactObjectiveStart", questToUpdate.currentObjective);

                else if (questToUpdate.currentObjective.GetType() == typeof(DeliverQuestObjective))
                    EventManager.TriggerEvent("DeliverObjectiveStart", questToUpdate.currentObjective);

                else if (questToUpdate.currentObjective.GetType() == typeof(KillQuestObjective))
                        EventManager.TriggerEvent("KillObjectiveStart", questToUpdate.currentObjective);
            }

            else
            { 
                questToUpdate.giveReward();
                acceptedQuests.Remove(questToUpdate);
            }
        }
    }

    public void KillQuestObjectiveProgressCheck(string npcKilled)
    {
        foreach(Quest acceptedQuest in acceptedQuests)
        {
            if(acceptedQuest.currentObjective.GetType() == typeof(KillQuestObjective))
            {
                KillQuestObjective objectiveToCheck = (KillQuestObjective)acceptedQuest.currentObjective;
                if(objectiveToCheck.npcToKill == npcKilled)
                {
                    updateQuestProgress(acceptedQuest);
                }
            }
        }
    }

    public void DeliverQuestObjectiveProgressCheck(Item itemObtained)
    {
        foreach(Quest acceptedQuest in acceptedQuests)
        {
            if(acceptedQuest.currentObjective.GetType() == typeof(DeliverQuestObjective))
            {
                DeliverQuestObjective objectiveToCheck = (DeliverQuestObjective)acceptedQuest.currentObjective;
                if(objectiveToCheck.itemToDeliver == itemObtained)
                {
                    updateQuestProgress(acceptedQuest);
                }
            }
        }
    }

    public void ContactQuestObjectiveProgressCheck(DialogueOption optionSelected)
    {
        foreach(Quest acceptedQuest in acceptedQuests)
        {
            if(acceptedQuest.currentObjective.GetType() == typeof(ContactQuestObjective))
            {
                ContactQuestObjective objectiveToCheck = (ContactQuestObjective)acceptedQuest.currentObjective;
                if(objectiveToCheck.optionToSelect == optionSelected)
                {
                    optionSelected.optionEnabled = false; //stops them from selecting it again
                    updateQuestProgress(acceptedQuest);
                }
            }
        }
    }
}
