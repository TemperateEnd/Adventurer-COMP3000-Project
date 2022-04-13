using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QuestObjective : ScriptableObject 
{
    public string objectiveText;
    public bool objectiveComplete;
    public int progressTowardsObj;
    public int objGoalNumber;

    bool evaluateObjectiveComplete()
    {
        if(progressTowardsObj == objGoalNumber)
            return true;
        
        else
            return false;
    }
}
