using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisioncheckScript : MonoBehaviour
{
    void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Player" && this.gameObject.GetComponentInParent<npcDialogueScript>())
        {
            this.gameObject.GetComponentInParent<npcDialogueScript>().readyForDialogue = true;
            GameObject.Find("StateManager").GetComponent<StateManager>().withinDialogueRange = true;
            GameObject.Find("StateManager").GetComponent<StateManager>().currentNPC = this.gameObject.GetComponentInParent<npcDialogueScript>().npcDialogueTree;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Player" && this.gameObject.GetComponentInParent<npcDialogueScript>())
        {
            this.gameObject.GetComponentInParent<npcDialogueScript>().readyForDialogue = false;
            GameObject.Find("StateManager").GetComponent<StateManager>().withinDialogueRange = false;
             GameObject.Find("StateManager").GetComponent<StateManager>().currentNPC = null;
        }
    }
}
