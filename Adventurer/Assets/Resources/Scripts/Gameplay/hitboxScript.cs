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
                this.gameObject.GetComponent<npcScript>().RemoveHealth((int)other.gameObject.GetComponentInParent<playerAttributes>().damageOutput);
            
                switch(other.gameObject.GetComponentInParent<attackScript>().currentlyEquippedWeapon.weaponType)
                {
                    case "Sword":
                        GameObject.Find("StateManager").GetComponent<levelUpScript>().SkillAddXP(StateManager.InstanceRef.skills[7], 10.0f);
                        break;

                    default:
                        break;
                }
            }

            else if(this.gameObject.tag == "Player"){
                this.gameObject.GetComponent<playerAttributes>().ReduceAttribute("Health", other.gameObject.GetComponentInParent<npcCombat>().damageOutput);
            }
        }
    }
}
