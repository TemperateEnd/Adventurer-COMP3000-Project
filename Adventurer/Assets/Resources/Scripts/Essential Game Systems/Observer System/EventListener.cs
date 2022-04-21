using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.StartListening("Use", OnUse);
    }

    private void OnDisable() 
    {
        EventManager.StopListening("Use", OnUse);
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

    }

    private void ItemObtained(object data)
    {
        Item collectedItem = (Item)data;

        questLogBackend.evaluateQuests();
    }

    private void NPCSpokenTo(object data)
    {
        string npcName = (string) data;

        questLogBackend.evaluateQuests();
    }

    private void NPCKilled(object data)
    {
        string npcName = (string) data;

        questLogBackend.evaluateQuests();
    }
}
