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

    void Update() 
    {
        damageReduction = this.gameObject.GetComponent<StateManager>().characterEndurance;
        damageOutput =  this.gameObject.GetComponent<StateManager>().characterStrength;

        if(currentlySelectedEquipment)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                UnequipPiece(currentlySelectedEquipment);
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
        
        damageReduction += armorToEquip.armorCount;
    }

    public void EquipWeapon(Weapon weaponToEquip)
    {
        playerWeapon = weaponToEquip;
        damageOutput += weaponToEquip.damageCount;
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

            damageReduction -= armorUnequip.armorCount;
        }

        else if (equipmentToUnequip.GetType() == typeof(Weapon))
        {
            Weapon weaponUnequip = (Weapon) equipmentToUnequip;
            damageOutput -= weaponUnequip.damageCount;
            playerWeapon = null;
            uiScript.weaponEquipmentObj.GetComponent<characterEquipmentObjScript>().characterEquipmentPiece = null;
        }

        playerInventory.AddItemToInventory(equipmentToUnequip);
    }
}
