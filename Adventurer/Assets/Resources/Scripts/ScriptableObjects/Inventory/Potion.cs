using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Adventurer/Item/Consumable/Potion")]
public class Potion : Consumable
{
    public int restoreAmount;
    public Potion()
    {
        this.typeOfConsumable = consumableType.Potion;
    }
}
