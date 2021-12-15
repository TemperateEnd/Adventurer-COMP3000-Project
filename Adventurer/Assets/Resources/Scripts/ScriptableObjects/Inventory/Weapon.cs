using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon", menuName = "Adventurer/Item/Equippable/Weapon")]
public class Weapon : Equippable
{
    public int damageCount;
    public Weapon()
    {
        this.typeOfEquippable = equippableType.Weapon;
    }
}
