using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerUIScript : MonoBehaviour
{
    public GameObject player;
    public Slider healthBar;
    public Slider staminaBar;
    public GameObject dialoguePromptUI;

    void OnEnable() {
        player = this.gameObject.GetComponentInParent<StateManager>().playerObj;
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.maxValue = player.GetComponent<playerAttributes>().staminaMax;
        healthBar.maxValue = player.GetComponent<playerAttributes>().healthMax;

        staminaBar.value = player.GetComponent<playerAttributes>().currStamina;
        healthBar.value = player.GetComponent<playerAttributes>().currHealth;

        if(StateManager.InstanceRef.withinDialogueRange)
        {
            dialoguePromptUI.SetActive(true);
        }

        else if (!StateManager.InstanceRef.withinDialogueRange)
        {
            dialoguePromptUI.SetActive(false);
        }
    }
}
