using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcCombat : MonoBehaviour
{
    [SerializeField] private Animator weaponAnimator;
    public GameObject target;
    public GameObject weaponModel;
    public GameObject weaponModelCollisionPoint;
    public int damageOutput;


    // Start is called before the first frame update
    void OnEnable() {
        target = StateManager.InstanceRef.playerObj;
        damageOutput = this.gameObject.GetComponentInParent<npcScript>().npcWeapon.damageCount + this.gameObject.GetComponentInParent<npcScript>().npcStrength;
        weaponModel = Instantiate(this.gameObject.GetComponentInParent<npcScript>().npcWeapon.itemModel);
        weaponModel.transform.parent = this.gameObject.transform;
        weaponModel.transform.localPosition = new Vector3(0.62f, 0f, 0.87f);
        weaponModel.transform.localRotation = Quaternion.Euler(new Vector3(545.1f, 75.0f, 113.54f));
        weaponAnimator = weaponModel.GetComponent<Animator>();
        
        foreach(Transform child in weaponModel.GetComponentInChildren<Transform>())
        {
            if(child.CompareTag("weaponAttackCollisionPoint"))
            {
                weaponModelCollisionPoint = child.gameObject;
            }
        }

        weaponModelCollisionPoint.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(InRange())
        {
            StartCoroutine(Attack(1.00f));
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

    IEnumerator Attack(float attackTime)
    {
        weaponAnimator.SetTrigger("isAttacking");
        yield return new WaitForSeconds(attackTime);
        weaponModelCollisionPoint.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(0.33f);
        weaponModelCollisionPoint.GetComponent<Collider>().enabled = false;
    }
}
