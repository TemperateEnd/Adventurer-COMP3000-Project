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
        EventManager.StartListening("ItemDeliver", ItemPickedUp);
        EventManager.StartListening("NPCKilled", NPCKilled);
    }

    private void OnDisable() 
    {
        EventManager.StopListening("Use", OnUse);
        EventManager.StopListening("StartQuest", StartQuest);
        EventManager.StopListening("ItemDeliver", ItemPickedUp);
        EventManager.StopListening("NPCKilled", NPCKilled);
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
        questLogBackend.addQuestToList(questToStart);
    }

    private void ItemPickedUp(object data)
    {
        Item collectedItem = (Item)data;
        questLogBackend.questProgressTracking(collectedItem);
    }

    private void NPCKilled(object data)
    {
        string npcName = (string) data;
        questLogBackend.questProgressTracking(npcName);
    }

    private void NPCContact(object data)
    {
        DialogueOption selectedOption = (DialogueOption)data;
        questLogBackend.questProgressTracking(selectedOption);
    }
}
