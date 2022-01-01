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
        if(currentlySelectedEquipment)
        {
            playerInventory.currentlySelectedItem = currentlySelectedEquipment;
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
        
        damageReduction += armorToEquip.armorCount + this.gameObject.GetComponent<StateManager>().characterEndurance;
    }

    public void EquipWeapon(Weapon weaponToEquip)
    {
        playerWeapon = weaponToEquip;
        damageOutput += weaponToEquip.damageCount + this.gameObject.GetComponent<StateManager>().characterStrength;
    }

    public void UnequipPiece(Equippable equipmentToUnequip)
    {
        if(equipmentToUnequip == headArmor)
        {
            headArmor = null;

        }
    }
}
