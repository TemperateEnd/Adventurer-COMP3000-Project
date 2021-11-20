using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class characterDetailsMenu : MonoBehaviour
{
    public TextMeshProUGUI charName;
    public TextMeshProUGUI charClass;
    public TextMeshProUGUI charLevelUpCount;

    public GameObject[] skillLevels;

    void Update() 
    {
        charName.SetText("Name: " + StateManager.InstanceRef.characterName);
        charClass.SetText("Level " + StateManager.InstanceRef.characterLevel + " " + StateManager.InstanceRef.characterClass.className);
        charLevelUpCount.SetText(StateManager.InstanceRef.levelUpManager.levelUpCount + "/" + StateManager.InstanceRef.levelUpManager.levelUpNumber + " skill increases before level increase");

        for (int i = 0; i < skillLevels.Length; i++)
        {
            SetSkills(skillLevels[i], StateManager.InstanceRef.skills[i]);
        }
    }

    void SetSkills(GameObject skillObj, Skill skillToObj)
    {
        skillObj.GetComponent<TextMeshProUGUI>().SetText(skillToObj.skillName + ": Level " + skillToObj.skillLevel);
        skillObj.GetComponentInChildren<Slider>().value = (skillToObj.skillXP/100);
    }
}
