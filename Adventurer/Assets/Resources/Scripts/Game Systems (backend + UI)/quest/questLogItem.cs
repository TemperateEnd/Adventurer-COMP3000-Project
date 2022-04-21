using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class questLogItem : MonoBehaviour
{
    public TextMeshProUGUI questText;
    public Quest questListed;

    // Start is called before the first frame update
    void Start()
    {
        questText = this.gameObject.GetComponent<TextMeshProUGUI>();    
    }

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
        this.gameObject.GetComponentInParent<questLogUI>().selectedQuest = questListed;
    }
}
