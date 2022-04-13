using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboxScript : MonoBehaviour
{
    public bool alreadyHit;

    // Start is called before the first frame update
    void Start()
    {
        alreadyHit = false;    
    }


    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "weaponAttackCollisionPoint")
        {
            if (this.gameObject.tag == "NPC"){
                Debug.Log("Skill used: " + other.gameObject.GetComponentInParent<attackScript>().currentlyEquippedWeapon.associatedSkill.skillName);
                this.gameObject.GetComponent<npcScript>().RemoveHealth((int)other.gameObject.GetComponentInParent<playerAttributes>().damageOutput);
                EventManager.TriggerEvent("Use", other.gameObject.GetComponentInParent<attackScript>().currentlyEquippedWeapon.associatedSkill);
            }

            else if(this.gameObject.tag == "Player"){
                this.gameObject.GetComponent<playerAttributes>().ReduceAttribute("Health", other.gameObject.GetComponentInParent<npcCombat>().damageOutput);
            }
        }
    }
}
