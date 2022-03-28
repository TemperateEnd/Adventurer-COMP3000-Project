using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterEquipmentScript : MonoBehaviour
{
    [Header("Character Equipment Data")]
    public Equippable currentlySelectedEquipment;
    public Armor headArmor;
    public Armor chestArmor;
    public Armor armArmor;
    public Armor legArmor;
    public Weapon playerWeapon;
    public int damageOutput;
    public int damageReduction;
    [Header("Links to other elements within system")]
    public inventoryScript playerInventory;
    public characterEquipmentUI uiScript;
    public GameObject playerWeaponSpace;

    void LateUpdate() 
    {
        if(StateManager.InstanceRef.playerObj)
        {
            damageReduction = Mathf.RoundToInt(StateManager.InstanceRef.playerObj.GetComponent<playerAttributes>().damageReduction);
            damageOutput = Mathf.RoundToInt(StateManager.InstanceRef.playerObj.GetComponent<playerAttributes>().damageOutput);
            
            foreach(Transform child in StateManager.InstanceRef.playerObj.GetComponentInChildren<Transform>())
            {
                if(child.name == "weapon")
                {
                    playerWeaponSpace = child.gameObject;
                }
            }
        }
    }

    public void EquipArmor(Armor armorToEquip)
    {
        switch(armorToEquip.armorPiece)
        {
            case armorPieceType.Head:
                headArmor = armorToEquip;
                break;

            case armorPieceType.Chest:
                chestArmor = armorToEquip;
                break;

            case armorPieceType.Arms:
                armArmor = armorToEquip;
                break;

            case armorPieceType.Legs:
                legArmor = armorToEquip;
                break;

            default:
                break;
        }
        
        StateManager.InstanceRef.playerObj.GetComponent<playerAttributes>().damageReduction += armorToEquip.armorCount;
    }

    public void EquipWeapon(Weapon weaponToEquip)
    {
        playerWeapon = weaponToEquip;
        StateManager.InstanceRef.playerObj.GetComponent<playerAttributes>().damageOutput += weaponToEquip.damageCount;
    }

    public void UnequipPiece(Equippable equipmentToUnequip)
    {
        if(equipmentToUnequip.GetType() == typeof(Armor))
        {
            Armor armorUnequip = (Armor) equipmentToUnequip;

            switch(armorUnequip.armorPiece)
            {
                case armorPieceType.Head:
                    headArmor = null;
                    uiScript.headArmorEquipmentObj.GetComponent<characterEquipmentObjScript>().characterEquipmentPiece = null;
                    break;
                
                case armorPieceType.Chest:
                    chestArmor = null;
                    uiScript.chestArmorEquipmentObj.GetComponent<characterEquipmentObjScript>().characterEquipmentPiece = null;
                    break;

                case armorPieceType.Arms:
                    armArmor = null;
                    uiScript.armArmorEquipmentObj.GetComponent<characterEquipmentObjScript>().characterEquipmentPiece = null;
                    break;

                case armorPieceType.Legs:
                    legArmor = null;
                    uiScript.legArmorEquipmentObj.GetComponent<characterEquipmentObjScript>().characterEquipmentPiece = null;
                    break;

                default:
                    break;
            }

            StateManager.InstanceRef.playerObj.GetComponent<playerAttributes>().damageReduction -= armorUnequip.armorCount;
        }

        else if (equipmentToUnequip.GetType() == typeof(Weapon))
        {
            Weapon weaponUnequip = (Weapon) equipmentToUnequip;
            StateManager.InstanceRef.playerObj.GetComponent<playerAttributes>().damageOutput -= weaponUnequip.damageCount;
            playerWeapon = null;
            uiScript.weaponEquipmentObj.GetComponent<characterEquipmentObjScript>().characterEquipmentPiece = null;
        }

        playerInventory.AddItemToInventory(equipmentToUnequip);
    }
}
