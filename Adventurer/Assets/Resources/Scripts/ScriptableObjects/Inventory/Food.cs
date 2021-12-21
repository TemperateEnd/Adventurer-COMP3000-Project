using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Adventurer/Item/Consumable/Food")]
public class Food : Consumable
{
    public int staminaRestoreCount;
    public int healthRestoreCount;
    public Food()
    {
        this.typeOfConsumable = consumableType.Food;
    }
}
