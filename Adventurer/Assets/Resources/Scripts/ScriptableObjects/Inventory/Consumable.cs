using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum consumableType { Potion, Food }
public class Consumable : Item
{
    public consumableType typeOfConsumable;

    public Consumable()
    {
        this.typeOfItem = itemType.Consumable;
    }
}
