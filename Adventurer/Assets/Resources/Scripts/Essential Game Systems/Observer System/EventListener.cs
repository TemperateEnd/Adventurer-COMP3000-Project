using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.StartListening("Use", OnUse);
        EventManager.StartListening("StartQuest", StartQuest);
        EventManager.StartListening("ItemPickedUp", ItemPickedUp);
        EventManager.StartListening("NPCKilled", NPCKilled);
        EventManager.StartListening("NPCSpokenTo", NPCSpokenTo);
        EventManager.StartListening("ContactObjectiveStart", ContactObjectiveStarted);
        EventManager.StartListening("DeliverObjectiveStart", DeliverObjectiveStarted);
        EventManager.StartListening("KillObjectiveStart", KillObjectiveStarted);
    }

    private void OnDisable() 
    {
        EventManager.StopListening("Use", OnUse);
        EventManager.StopListening("StartQuest", StartQuest);
        EventManager.StopListening("ItemPickedUp", ItemPickedUp);
        EventManager.StopListening("NPCKilled", NPCKilled);
        EventManager.StopListening("NPCSpokenTo", NPCSpokenTo);
        EventManager.StopListening("ContactObjectiveStart", ContactObjectiveStarted);
        EventManager.StopListening("DeliverObjectiveStart", DeliverObjectiveStarted);
        EventManager.StopListening("KillObjectiveStart", KillObjectiveStarted);
    }

    //Skill usage
    private void OnUse(object data)
    {
        Skill usedSkill = (Skill)data;
        Debug.Log(usedSkill.skillName + " should be increasing");
        this.gameObject.GetComponentInParent<levelUpScript>().SkillAddXP(usedSkill, 25.0f);
    }

    //space to use for quest-related events
    private void StartQuest(object data)
    {
        Quest questToStart = (Quest)data;
        questLogBackend questLog = GameObject.Find("StateManager").GetComponent<questLogBackend>();
        questLog.addQuestToList(questToStart);
    }

    private void DeliverObjectiveStarted(object data)
    {
        DeliverQuestObjective deliverObjStarted = (DeliverQuestObjective)data;
        inventoryScript inventory = GameObject.Find("StateManager").GetComponent<inventoryScript>();
        foreach(Item inventoryItem in inventory.inventoryItemsList)
        {
            if(inventoryItem == deliverObjStarted.itemToDeliver) //checks if player already has at least one of the item. If so, then increment progress int and compare with goal
            {
                EventManager.TriggerEvent("ItemPickedUp", inventoryItem);
            }
        } 
    }

    private void KillObjectiveStarted(object data)
    {
        KillQuestObjective killObjStarted = (KillQuestObjective)data;
    }

    private void ContactObjectiveStarted(object data) //unlock dialogue option that player is supposed to select
    {
        ContactQuestObjective contactObjStarted = (ContactQuestObjective)data;
        contactObjStarted.optionToSelect.optionEnabled = true;
    }

    private void ItemPickedUp(object data)
    {
        Item collectedItem = (Item)data;
        questLogBackend questLog = GameObject.Find("StateManager").GetComponent<questLogBackend>();
        questLog.questProgressTracking(collectedItem);
    }

    private void NPCKilled(object data)
    {
        string npcName = (string) data;
        questLogBackend questLog = GameObject.Find("StateManager").GetComponent<questLogBackend>();
        questLog.questProgressTracking(npcName);
    }

    private void NPCSpokenTo(object data)
    {
        DialogueOption selectedOption = (DialogueOption)data;
        questLogBackend questLog = GameObject.Find("StateManager").GetComponent<questLogBackend>();
        questLog.questProgressTracking(selectedOption);
    }
}
