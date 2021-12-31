using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class inventoryUIScript : MonoBehaviour
{
    public GameObject currentlySelectedInventoryItem;
    public List<GameObject> prefabArray;
    public GameObject inventoryItemUIPrefab;
    public GameObject inventoryListSection;
    public inventoryScript inventory;
    public TextMeshProUGUI weightText;
    public TextMeshProUGUI goldText;
    [Header("Currently selected item")]
    public Image itemSpriteDisplay;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescText;
    public TextMeshProUGUI itemStatsText;
    public TextMeshProUGUI itemValueText;
    public TextMeshProUGUI itemWeightText;

    // Start is called before the first frame update
    void Start()
    {
        inventory = this.gameObject.GetComponentInParent<inventoryScript>();
        inventory.uiScript = this;

        OnEnable();
    }

    void OnEnable() 
    {
        foreach (Item inventoryListItem in inventory.inventoryItemsList)
        {
            DisplayItem(inventoryListItem);
        }
    }

    // Update is called once per frame
    void Update()
    {
        goldText.SetText(inventory.playerCurrency + " Gold");
        weightText.SetText(inventory.currentWeight + "/" + inventory.weightLimit);

        if(inventory.currentlySelectedItem)
        {
            itemSpriteDisplay.gameObject.SetActive(true);
            itemNameText.gameObject.SetActive(true);
            itemDescText.gameObject.SetActive(true);
            itemStatsText.gameObject.SetActive(true);
            itemValueText.gameObject.SetActive(true);
            itemWeightText.gameObject.SetActive(true);

            itemNameText.SetText(inventory.currentlySelectedItem.itemName);
            itemDescText.SetText(inventory.currentlySelectedItem.itemDesc);

            if (inventory.currentlySelectedItem.GetType() == typeof(Weapon)){
                Weapon tempWeapon = (Weapon) inventory.currentlySelectedItem;
                itemStatsText.SetText("Deals " + tempWeapon.damageCount + " damage");
            }

            else if (inventory.currentlySelectedItem.GetType() == typeof(Armor)){
                Armor tempArmor = (Armor) inventory.currentlySelectedItem;
                itemStatsText.SetText("Defends against " + tempArmor.armorCount + " damage");   
            }   

            else if (inventory.currentlySelectedItem.GetType() ==typeof(Food)){
                Food tempFood = (Food) inventory.currentlySelectedItem;
                itemStatsText.SetText("Restores " + tempFood.healthRestoreCount + " health and " + tempFood.staminaRestoreCount + " stamina.");
            }

            else if(inventory.currentlySelectedItem.GetType() ==typeof(Potion))
            {
                Potion tempPotion = (Potion)inventory.currentlySelectedItem;

                if(tempPotion.statToRestore == "Health")
                {
                    itemStatsText.SetText("Restores " + tempPotion.restoreAmount + " health");
                }

                else if (tempPotion.statToRestore == "Stamina")
                {
                    itemStatsText.SetText("Restores " + tempPotion.restoreAmount + " stamina");
                }
            }
            itemValueText.SetText("Worth " + inventory.currentlySelectedItem.itemValue + " Gold");
            itemWeightText.SetText("Weighs about " + inventory.currentlySelectedItem.itemWeight + " KG");

            if(Input.GetKeyDown(KeyCode.E))
            {
                if(inventory.currentlySelectedItem.typeOfItem == itemType.Consumable)
                {
                    inventory.ConsumeItem((Consumable)inventory.currentlySelectedItem);
                }

                else if(inventory.currentlySelectedItem.typeOfItem == itemType.Equippable)
                {
                    inventory.EquipItem((Equippable)inventory.currentlySelectedItem);
                }
            }

            if(Input.GetKeyDown(KeyCode.I))
            {
                DisableUI();
            }
        }

        else if (inventory.currentlySelectedItem = null)
        {
            itemSpriteDisplay.gameObject.SetActive(false);
            itemNameText.gameObject.SetActive(false);
            itemDescText.gameObject.SetActive(false);
            itemStatsText.gameObject.SetActive(false);
            itemValueText.gameObject.SetActive(false);
            itemWeightText.gameObject.SetActive(false);
        }
    }

    void DisplayItem(Item itemToDisplay)
    {
        GameObject inventoryListItemObj = Instantiate(inventoryItemUIPrefab, transform.position, transform.rotation, inventoryListSection.transform);
        inventoryListItemObj.GetComponent<inventoryItemScript>().inventoryItem = itemToDisplay;
        prefabArray.Add(inventoryListItemObj);
    }

    void OnDisable() 
    {
        foreach(GameObject listItemIndex in prefabArray)
        {
            Destroy(listItemIndex);
        }
    }

    void DisableUI()
    {
        StateManager.InstanceRef.toggleInventory = false;
        this.gameObject.SetActive(false);
    }
}
