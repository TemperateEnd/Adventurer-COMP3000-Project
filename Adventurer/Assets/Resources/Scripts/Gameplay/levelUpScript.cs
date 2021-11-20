using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelUpScript : MonoBehaviour
{
    public int levelUpCount;
    public int levelUpNumber;

    void Update() 
    {
        if(levelUpCount == levelUpNumber)
        {
            CharacterLevelUp();
        }
    }

    // Update is called once per frame
    public void SkillAddXP(Skill skillXPToIncrease, float xpToGain)
    {
        skillXPToIncrease.skillXP += xpToGain;

        if(skillXPToIncrease.skillXP >= 100.0f)
        {
            SkillLevelUp(skillXPToIncrease);
        }
    }

    public void SkillLevelUp(Skill skillToLevelUp)
    {
        skillToLevelUp.skillLevel++;
        skillToLevelUp.skillXP = 0;

        foreach(Skill specializedSkill in StateManager.InstanceRef.characterClass.specialistSkills)
        {
            if(skillToLevelUp == specializedSkill)
            {
                levelUpCount++;
            }
        }
    }

    public void CharacterLevelUp()
    {
        StateManager.InstanceRef.characterLevel++;
        levelUpCount = 0;
    }
}
