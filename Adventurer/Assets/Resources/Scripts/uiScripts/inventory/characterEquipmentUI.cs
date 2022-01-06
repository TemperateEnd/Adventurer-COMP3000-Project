using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class characterEquipmentUI : MonoBehaviour
{
    [Header("UI elements")]
    public GameObject headArmorEquipmentObj;
    public GameObject chestArmorEquipmentObj;
    public GameObject armArmorEquipmentObj;
    public GameObject legArmorEquipmentObj;
    public GameObject weaponEquipmentObj;
    public TextMeshProUGUI armorCountText;
    public TextMeshProUGUI damageCountText;
    [Header("Links to other elements within system")]
    public characterEquipmentScript equipmentScript;

    // Start is called before the first frame update
    void Start()
    {
        equipmentScript = this.gameObject.GetComponentInParent<characterEquipmentScript>();
        equipmentScript.uiScript = this;
    }

    // Update is called once per frame
    void Update()
    {
        headArmorEquipmentObj.GetComponent<characterEquipmentObjScript>().characterEquipmentPiece = equipmentScript.headArmor;
        chestArmorEquipmentObj.GetComponent<characterEquipmentObjScript>().characterEquipmentPiece = equipmentScript.chestArmor;
        armArmorEquipmentObj.GetComponent<characterEquipmentObjScript>().characterEquipmentPiece = equipmentScript.armArmor;
        legArmorEquipmentObj.GetComponent<characterEquipmentObjScript>().characterEquipmentPiece = equipmentScript.legArmor;
        weaponEquipmentObj.GetComponent<characterEquipmentObjScript>().characterEquipmentPiece = equipmentScript.playerWeapon;

        armorCountText.SetText("Total Armor Count: " + equipmentScript.damageReduction);
        damageCountText.SetText("Total Damage Output: " + equipmentScript.damageOutput);

        if(equipmentScript.currentlySelectedEquipment)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                equipmentScript.UnequipPiece(equipmentScript.currentlySelectedEquipment);
            }
        }
    }
}
