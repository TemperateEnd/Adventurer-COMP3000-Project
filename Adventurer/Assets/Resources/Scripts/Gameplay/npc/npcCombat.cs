using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcCombat : MonoBehaviour
{
    public GameObject target;
    public int damageOutput;


    // Start is called before the first frame update
    void OnEnable() {
        target = StateManager.InstanceRef.playerObj;
        damageOutput = this.gameObject.GetComponent<npcScript>().npcWeapon.damageCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(InRange())
        {
            //Attack code goes here
        }
    }

    bool InRange()
    {
        if(Vector3.Distance(target.transform.position, this.gameObject.transform.position) == 10.0f)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
