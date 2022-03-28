using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    [SerializeField] private Animator weaponAnimator;
    public Weapon currentlyEquippedWeapon;
    public GameObject weaponModel;
    public GameObject weaponModelCollisionPoint;


    // Start is called before the first frame update
    void OnEnable() {
        currentlyEquippedWeapon = StateManager.InstanceRef.GetComponent<characterEquipmentScript>().playerWeapon;
        weaponModel = Instantiate(currentlyEquippedWeapon.itemModel);
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

    void OnDisable() {
        weaponModel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Attack")){
            Debug.Log("Attacking");
            StartCoroutine(Attack(1.00f));
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Should be disabling script");
            this.enabled = false;
        }
    }

    IEnumerator Attack(float attackTime)
    {
        weaponAnimator.SetTrigger("isAttacking");
        yield return new WaitForSeconds(attackTime);
        weaponModelCollisionPoint.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(0.20f);
        weaponModelCollisionPoint.GetComponent<Collider>().enabled = false;
    }
}
