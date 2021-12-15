using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemType {Equippable, Consumable}
public abstract class Item : ScriptableObject 
{
    public string itemName;
    public string itemDesc;
    public float itemWeight;
    public int itemValue;
    public itemType typeOfItem;
}
