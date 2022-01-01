using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum attributeToRestore { Health, Stamina }
[CreateAssetMenu(fileName = "New Potion", menuName = "Adventurer/Item/Consumable/Potion")]
public class Potion : Consumable
{
    public int restoreAmount;
    public attributeToRestore statToRestore;
    public Potion()
    {
        this.typeOfConsumable = consumableType.Potion;
    }
}
