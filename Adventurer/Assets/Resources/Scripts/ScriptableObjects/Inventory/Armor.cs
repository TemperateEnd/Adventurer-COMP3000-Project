using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum armorPieceType { Head, Chest, Arms, Legs }
[CreateAssetMenu(fileName = "New Armor", menuName = "Adventurer/Item/Equippable/Armor")]
public class Armor : Equippable
{
    public string armorType;
    public int armorCount;
    public armorPieceType armorPiece;
    public Armor()
    {
        this.typeOfEquippable = equippableType.Armor;
    }
}
