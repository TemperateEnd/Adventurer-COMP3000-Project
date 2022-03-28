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
    [Header("UI - Variables")]
    public TextMeshProUGUI weightText;
    public TextMeshProUGUI goldText;
    [Header("UI - Currently selected item")]
    public Image itemSpriteDisplay;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescText;
    public TextMeshProUGUI itemStatsText;
    public TextMeshProUGUI itemValueText;
    public TextMeshProUGUI itemWeightText;

    // Start is called before the first frame update
    void Start(){
        inventory = this.gameObject.GetComponentInParent<inventoryScript>();
        inventory.uiScript = this;
    }

    void OnEnable() {

        if(prefabArray.Count > 0) //if inventory has been opened previously, reset the UI to prevent duplication
        {
            ResetUI();
        }
        
        EnableUI();
    }

    void ResetUI(){
        for(int i = 0; i < inventory.inventoryItemsList.Count; i++)
        {
            Destroy(prefabArray[i]);
        }

        prefabArray.Clear();
    }

    void EnableUI(){
        foreach (Item inventoryListItem in inventory.inventoryItemsList){
            DisplayItemInList(inventoryListItem);
        }
    }

    // Update is called once per frame
    void Update(){
        goldText.SetText(inventory.playerCurrency + " Gold");
        weightText.SetText(inventory.currentWeight + "/" + inventory.weightLimit);

        if(inventory.currentlySelectedItem)
        {
            DisplayItemInfo(inventory.currentlySelectedItem);
            
            if(Input.GetButtonDown("Interact"))
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

        if(Input.GetKeyDown(KeyCode.I))
        {
            DisableUI();
        }
    }

    //Displays relevant info pertaining to inventory item currently selected by player
    void DisplayItemInfo(Item itemToDisplay){
        itemSpriteDisplay.gameObject.SetActive(true);
        itemNameText.gameObject.SetActive(true);
        itemDescText.gameObject.SetActive(true);
        itemStatsText.gameObject.SetActive(true);
        itemValueText.gameObject.SetActive(true);
        itemWeightText.gameObject.SetActive(true);

        itemNameText.SetText(itemToDisplay.itemName);
        itemDescText.SetText(itemToDisplay.itemDesc);

        //conditional statements to check type of item so that different stats will be shown off to the player when item is selected

        if (itemToDisplay.GetType() == typeof(Weapon)){
            Weapon tempWeapon = (Weapon) itemToDisplay;
            itemStatsText.SetText("Deals " + tempWeapon.damageCount + " damage");
        }

        else if (itemToDisplay.GetType() == typeof(Armor)){
            Armor tempArmor = (Armor) itemToDisplay;
            itemStatsText.SetText("Defends against " + tempArmor.armorCount + " damage");   
        }   

        else if (itemToDisplay.GetType() ==typeof(Food)){
            Food tempFood = (Food) itemToDisplay;
            itemStatsText.SetText("Restores " + tempFood.healthRestoreCount + " health and " + tempFood.staminaRestoreCount + " stamina.");
        }

        else if(itemToDisplay.GetType() ==typeof(Potion))
        {
            Potion tempPotion = (Potion)itemToDisplay;

            if(tempPotion.statToRestore == attributeToRestore.Health)
            {
                itemStatsText.SetText("Restores " + tempPotion.restoreAmount + " health");
            }

            else if (tempPotion.statToRestore == attributeToRestore.Stamina)
            {
                itemStatsText.SetText("Restores " + tempPotion.restoreAmount + " stamina");
            }
        }

        itemValueText.SetText("Worth " + itemToDisplay.itemValue + " Gold");
        itemWeightText.SetText("Weighs about " + itemToDisplay.itemWeight + " KG");
    }

    public void DisplayItemInList(Item itemToList){
        GameObject inventoryListItemObj = Instantiate(inventoryItemUIPrefab, transform.position, transform.rotation, inventoryListSection.transform);
        inventoryListItemObj.GetComponent<inventoryItemScript>().inventoryItem = itemToList;
        prefabArray.Add(inventoryListItemObj);
    }

    void DisableUI(){
        StateManager.InstanceRef.toggleInventory = false;
        this.gameObject.SetActive(false);
    }
}