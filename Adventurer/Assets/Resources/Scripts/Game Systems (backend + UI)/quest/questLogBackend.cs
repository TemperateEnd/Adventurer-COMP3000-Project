using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questLogBackend : MonoBehaviour
{
    private questLogBackend questLog;
    public questLogBackend publicQuestLog;
    public static List<Quest> acceptedQuests;

    public void addQuestToList(Quest questToAdd)
    {}

    public void updateQuestProgress(Quest questToUpdate)
    {
    }

    public static void evaluateQuests()
    {
        foreach(Quest acceptedQuest in acceptedQuests)
        {
            if(acceptedQuest.currentObjective.GetType() == typeof(KillQuestObjective))
            {

            }
        }
    }
}
