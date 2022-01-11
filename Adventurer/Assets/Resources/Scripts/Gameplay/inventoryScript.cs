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
    [Header("Links to other elements within system")]
    public characterEquipmentScript equipmentScript;
    public inventoryUIScript uiScript;

    void Awake()
    {
        equipmentScript = this.gameObject.GetComponent<characterEquipmentScript>();
        equipmentScript.playerInventory = this;

        foreach (Item itemInInventory in inventoryItemsList)
        {
            currentWeight += itemInInventory.itemWeight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        weightLimit = (this.gameObject.GetComponent<StateManager>().characterStrength) * 25;
    }

    public void AddItemToInventory(Item itemToAdd)
    {
        inventoryItemsList.Add(itemToAdd);
        uiScript.DisplayItemInList(itemToAdd);
    }

    public void RemoveItemFromInventory(Item itemToRemove)
    {
        inventoryItemsList.Remove(itemToRemove);
        currentlySelectedItem = null;
    }

    // void DropItem(Item itemToDrop) Temporarily commented out as this is non-essential feature at the moment
    // {
    //     //Additional code to drop item will be here
    //     RemoveItemFromInventory(itemToDrop);
    // }

    public void ConsumeItem(Consumable itemToConsume) //For consumables
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

            if(potionToDrink.statToRestore == attributeToRestore.Health)
            {
                playerAttribs.currHealth += restoreAmount;
            }

            else if (potionToDrink.statToRestore == attributeToRestore.Stamina)
            {
                playerAttribs.currStamina += restoreAmount;
            }
        }
        currentWeight -= itemToConsume.itemWeight;
        RemoveItemFromInventory(itemToConsume); //Item gets removed from inventory
        uiScript.prefabArray.Remove(uiScript.currentlySelectedInventoryItem);
        Destroy(uiScript.currentlySelectedInventoryItem);
    }

    public void EquipItem(Equippable itemToEquip) //For equippables
    {
        Debug.Log(itemToEquip.itemName + " should have been equipped");
        if(itemToEquip.GetType() == typeof(Armor))
        {
            Armor armorToWear = (Armor)itemToEquip;
            equipmentScript.EquipArmor(armorToWear);
        }

        else if (itemToEquip.GetType() == typeof(Weapon))
        {
            Weapon weaponToCarry = (Weapon)itemToEquip;
            equipmentScript.EquipWeapon(weaponToCarry);
        }

        RemoveItemFromInventory(itemToEquip); //Item gets removed from inventory
        uiScript.prefabArray.Remove(uiScript.currentlySelectedInventoryItem);
        Destroy(uiScript.currentlySelectedInventoryItem);
    }
}
