using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class barteringUIScript : MonoBehaviour
{
    public GameObject currentlySelectedObj;
    public GameObject barteringObjPrefab;
    public GameObject playerItemsSection;
    public GameObject npcItemsSection;
    public barteringScript barteringBackEnd;
    public TextMeshProUGUI playerGoldText;
    public TextMeshProUGUI npcGoldText;
    public List<GameObject> playerPrefabArray;
    public List<GameObject> npcPrefabArray;
    [Header("Item info section")]
    public TextMeshProUGUI itemNameInfo;
    public TextMeshProUGUI itemDescInfo;
    public TextMeshProUGUI itemStatInfo;
    public TextMeshProUGUI itemValueInfo;
    public TextMeshProUGUI itemWeightInfo;

    // Start is called before the first frame update
    void Start()
    {
        barteringBackEnd = this.gameObject.GetComponentInParent<barteringScript>();
        barteringBackEnd.uiScript = this;

        foreach(Item playerListItem in barteringBackEnd.playerItemsList)
        {
            DisplayItem(playerListItem, playerItemsSection, playerPrefabArray);
        }

        foreach(Item npcListItem in barteringBackEnd.npcItemsList)
        {
            DisplayItem(npcListItem, npcItemsSection, npcPrefabArray);
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerGoldText.SetText(barteringBackEnd.playerGoldValue + " Gold");
        npcGoldText.SetText(barteringBackEnd.npcGoldValue + " Gold");

        if((barteringBackEnd.selectedItemFromNPC))
        {
            itemNameInfo.SetText(barteringBackEnd.selectedItemFromNPC.itemName);
            itemDescInfo.SetText(barteringBackEnd.selectedItemFromNPC.itemDesc);
            
            if(barteringBackEnd.selectedItemFromNPC.GetType() == typeof(Weapon))
            {
                Weapon selectedWeapon = (Weapon)barteringBackEnd.selectedItemFromNPC;
                itemStatInfo.SetText(selectedWeapon.damageCount + " damage");
            }

            else if(barteringBackEnd.selectedItemFromNPC.GetType() == typeof(Armor))
            {
                Armor selectedArmor = (Armor)barteringBackEnd.selectedItemFromNPC;
                itemStatInfo.SetText(selectedArmor.armorCount + " armor");
            }

            else if(barteringBackEnd.selectedItemFromNPC.GetType() == typeof(Potion))
            {
                Potion selectedPotion = (Potion)barteringBackEnd.selectedItemFromNPC;
                itemStatInfo.SetText(selectedPotion.restoreAmount + selectedPotion.statToRestore.ToString());
            }

            else if(barteringBackEnd.selectedItemFromNPC.GetType() == typeof(Food))
            {
                Food selectedFood = (Food)barteringBackEnd.selectedItemFromNPC;
                itemStatInfo.SetText("Restores " + selectedFood.healthRestoreCount + " health and " + selectedFood.staminaRestoreCount + " stamina");      
            }

            itemValueInfo.SetText(barteringBackEnd.selectedItemFromNPC.itemValue + " gold");
            itemWeightInfo.SetText(barteringBackEnd.selectedItemFromNPC.itemWeight + " KG");

            if(Input.GetButtonDown("Interact") && (barteringBackEnd.playerGoldValue >= barteringBackEnd.selectedItemFromNPC.itemValue))
            {
                barteringBackEnd.BuyItem(barteringBackEnd.selectedItemFromNPC);
            }
        }

        else if ((barteringBackEnd.selectedItemFromPlayer))
        {
            itemNameInfo.SetText(barteringBackEnd.selectedItemFromPlayer.itemName);
            itemDescInfo.SetText(barteringBackEnd.selectedItemFromPlayer.itemDesc);
            
            if(barteringBackEnd.selectedItemFromPlayer.GetType() == typeof(Weapon))
            {
                Weapon selectedWeapon = (Weapon)barteringBackEnd.selectedItemFromPlayer;
                itemStatInfo.SetText(selectedWeapon.damageCount + " damage");
            }

            else if(barteringBackEnd.selectedItemFromPlayer.GetType() == typeof(Armor))
            {
                Armor selectedArmor = (Armor)barteringBackEnd.selectedItemFromPlayer;
                itemStatInfo.SetText(selectedArmor.armorCount + " armor");
            }

            else if(barteringBackEnd.selectedItemFromPlayer.GetType() == typeof(Potion))
            {
                Potion selectedPotion = (Potion)barteringBackEnd.selectedItemFromPlayer;
                itemStatInfo.SetText(selectedPotion.restoreAmount + selectedPotion.statToRestore.ToString());
            }

            else if(barteringBackEnd.selectedItemFromPlayer.GetType() == typeof(Food))
            {
                Food selectedFood = (Food)barteringBackEnd.selectedItemFromPlayer;
                itemStatInfo.SetText("Restores " + selectedFood.healthRestoreCount + " health and " + selectedFood.staminaRestoreCount + " stamina");      
            }

            itemValueInfo.SetText(barteringBackEnd.selectedItemFromPlayer.itemValue + " gold");
            itemWeightInfo.SetText(barteringBackEnd.selectedItemFromPlayer.itemWeight + " KG");

            if(Input.GetButtonDown("Interact") && (barteringBackEnd.npcGoldValue >= barteringBackEnd.selectedItemFromPlayer.itemValue))
            {
                barteringBackEnd.SellItem(barteringBackEnd.selectedItemFromPlayer);
            }
        }
    }

    public void DisplayItem(Item itemToDisplay, GameObject parentObj, List<GameObject> prefabArrayToUse)
    {
        GameObject barteringItemObj = Instantiate(barteringObjPrefab, transform.position, transform.rotation, parentObj.transform);
        barteringItemObj.GetComponent<barteringObjScript>().itemContained = itemToDisplay;
        prefabArrayToUse.Add(barteringItemObj);
    }

    public void RemoveItemObj(GameObject prefab, List<GameObject> prefabArrayToUse)
    {
        prefabArrayToUse.Remove(prefab);
        Destroy(prefab);
    }

    public void EndBartering()
    {
        this.gameObject.SetActive(false);
        StateManager.InstanceRef.toggleBartering = false;
    }
}
