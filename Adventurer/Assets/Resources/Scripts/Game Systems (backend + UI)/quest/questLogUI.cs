using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class questLogUI : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject currentlySelectedQuest;
    public List<GameObject> prefabArray;
    public GameObject questObjUIPrefab;
    public GameObject questListSection;
    [Header("UI - Quest Info")]
    public TextMeshProUGUI questNameText;
    public TextMeshProUGUI questObjText;
    public questLogBackend questLog;

    void Start() 
    {
        questLog.uiScript = this;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        if(prefabArray.Count > 0)
        {
            ResetUI();
        }

        EnableUI();
    }

    void ResetUI()
    {
        for (int i = 0; i < questLog.acceptedQuests.Count; i++)
        {
            Destroy(prefabArray[i]);
        }
        prefabArray.Clear();
    }

    void EnableUI()
    {
        if(questLog.acceptedQuests.Count > 0)
        {
            foreach(Quest questListItem in questLog.acceptedQuests)
            {
                DisplayQuest(questListItem);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(questLog.currentlySelectedQuest)
        {
            DisplayQuestInfo(questLog.currentlySelectedQuest);
        }

        else if (questLog.currentlySelectedQuest = null)
        {
            questNameText.gameObject.SetActive(false);
            questObjText.gameObject.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            DisableUI();
        }
    }

    void DisplayQuestInfo(Quest questToDisplay)
    {
        questNameText.SetText(questToDisplay.questName);
        questObjText.SetText(questToDisplay.currentObjective.objectiveText);
    }

    void DisplayQuest(Quest questToList)
    {
        GameObject questListItemObj = Instantiate(questObjUIPrefab, transform.position, transform.rotation, questListSection.transform);
        questListItemObj.GetComponent<questLogItem>().questListed = questToList;
        prefabArray.Add(questListItemObj);
    }

    void DisableUI()
    {
        StateManager.InstanceRef.toggleQuestLog = false;
        this.gameObject.SetActive(false);
    }
}
