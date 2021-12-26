using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryScript : MonoBehaviour
{
    public int playerCurrency;
    public float currentWeight;
    public float weightLimit;
    public List <Item> inventoryItemsList;
    public Item currentlySelectedItem;
    public playerAttributes playerAttribs;

    // Start is called before the first frame update
    void Start()
    {
        playerAttribs = this.gameObject.GetComponent<StateManager>().playerObj.GetComponent<playerAttributes>();
    }

    void Awake()
    {
        foreach (Item itemInInventory in inventoryItemsList)
        {
            currentWeight += itemInInventory.itemWeight;
        }
    }

    void Update()
    {
        weightLimit = (this.gameObject.GetComponent<StateManager>().characterStrength) * 25;
    }

    // Update is called once per frame
    void AddItemToInventory(Item itemToAdd)
    {
        inventoryItemsList.Add(itemToAdd);
        currentWeight += itemToAdd.itemWeight;
    }

    void RemoveItemFromInventory(Item itemToRemove)
    {
        currentWeight -= itemToRemove.itemWeight;
        inventoryItemsList.Remove(itemToRemove);
    }

    // void DropItem(Item itemToDrop) Temporarily commented out as this is non-essential feature at the moment
    // {
    //     //Additional code to drop item will be here
    //     RemoveItemFromInventory(itemToDrop);
    // }

    void ConsumeItem(Consumable itemToConsume) //For consumables
    {
        if(itemToConsume.GetType() == typeof(Food)) //If item is food, cast as Food type item and replenish stamina and health
        {
            Food foodToEat = (Food)itemToConsume;
            playerAttribs.currHealth += foodToEat.healthRestoreCount;
            playerAttribs.currStamina += foodToEat.staminaRestoreCount;
        }

        else if (itemToConsume.GetType() == typeof(Potion)) //If item is potion, cast as potion and I want that to do something. 
        {
            Potion potionToDrink = (Potion)itemToConsume;
            Debug.Log("Should be drinking " + itemToConsume.itemName);
            //insert code for potion
        }
        RemoveItemFromInventory(itemToConsume); //Item gets removed from inventory
    }

    void EquipItem(Equippable itemToEquip) //For equippables
    {
        if(itemToEquip.GetType() == typeof(Armor))
        {
            Armor armorToWear = (Armor)itemToEquip;
        }

        else if (itemToEquip.GetType() == typeof(Weapon))
        {
            Weapon weaponToCarry = (Weapon)itemToEquip;
        }
    }
}
