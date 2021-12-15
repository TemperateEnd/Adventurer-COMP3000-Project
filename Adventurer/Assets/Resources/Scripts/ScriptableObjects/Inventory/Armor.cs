using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Armor", menuName = "Adventurer/Item/Equippable/Armor")]
public class Armor : Equippable
{
    public int armorCount;
    public Armor()
    {
        this.typeOfEquippable = equippableType.Armor;
    }
}
