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

    private void OnUse(object data)
    {
        Skill weaponSkill = (Skill)data;
        Debug.Log(weaponSkill.skillName + " should be increasing");
        this.gameObject.GetComponentInParent<levelUpScript>().SkillAddXP(weaponSkill, 25.0f);
    }

    //space to use for quest-related events
}
