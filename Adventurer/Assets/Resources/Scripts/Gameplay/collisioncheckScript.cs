using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisioncheckScript : MonoBehaviour
{
    void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Player" && this.gameObject.GetComponentInParent<npcScript>())
        {
            this.gameObject.GetComponentInParent<npcScript>().readyForDialogue = true;
            GameObject.Find("StateManager").GetComponent<StateManager>().withinDialogueRange = true;
            GameObject.Find("StateManager").GetComponent<StateManager>().currentNPC = this.gameObject.GetComponentInParent<npcScript>().npcDialogueTree;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Player" && this.gameObject.GetComponentInParent<npcScript>())
        {
            this.gameObject.GetComponentInParent<npcScript>().readyForDialogue = false;
            GameObject.Find("StateManager").GetComponent<StateManager>().withinDialogueRange = false;
            GameObject.Find("StateManager").GetComponent<StateManager>().currentNPC = null;
        }
    }
}
