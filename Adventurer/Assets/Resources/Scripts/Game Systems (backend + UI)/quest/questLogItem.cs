using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class questLogItem : MonoBehaviour
{
    public TextMeshProUGUI questText;
    public Quest questListed;

    // Update is called once per frame
    void Update()
    {
        if(questListed)
        {
            questText.SetText(questListed.questName);
        }

        else
        {
            questText.SetText("Null");
        }
    }

    void OnPointerClick()
    {
        SelectQuest();
    }

    public void SelectQuest()
    {
        this.gameObject.GetComponentInParent<questLogUI>().questLog.currentlySelectedQuest = questListed;
    }
}
