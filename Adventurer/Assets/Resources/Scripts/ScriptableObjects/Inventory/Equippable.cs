using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum equippableType {Weapon, Armor}
public abstract class Equippable : Item
{
    public equippableType typeOfEquippable;

    public Equippable()
    {
        this.typeOfItem = itemType.Equippable;
    }
}
