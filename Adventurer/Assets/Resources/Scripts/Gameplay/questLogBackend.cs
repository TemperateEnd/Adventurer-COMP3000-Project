using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questLogBackend : MonoBehaviour
{
    public List<Quest> acceptedQuests;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateQuestProgress(Quest questToUpdate)
    {
        questToUpdate.currentObjective.progressQuest();
    }
}
