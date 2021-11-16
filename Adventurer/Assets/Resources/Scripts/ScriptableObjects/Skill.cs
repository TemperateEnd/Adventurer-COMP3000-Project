using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Adventurer/Skill", order = 0)]
public class Skill : ScriptableObject
{
    public string skillName;
    [Range(0, 100)]public byte skillLevel;
    [Range(0, 100)]public float skillXP;
}
