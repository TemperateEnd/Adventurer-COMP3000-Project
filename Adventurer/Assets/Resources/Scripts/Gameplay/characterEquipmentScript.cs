using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterEquipmentScript : MonoBehaviour
{
    public Armor playerArmor;
    public Weapon playerWeapon;

    public int damageOutput;
    public int damageReduction;

    public void EquipArmor(Armor armorToEquip)
    {
        playerArmor = armorToEquip;
        damageReduction += armorToEquip.armorCount + this.gameObject.GetComponent<StateManager>().characterEndurance;
    }

    public void EquipWeapon(Weapon weaponToEquip)
    {
        playerWeapon = weaponToEquip;
        damageOutput += weaponToEquip.damageCount + this.gameObject.GetComponent<StateManager>().characterStrength;
    }
}
