using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barteringScript : MonoBehaviour
{
    public int playerGoldValue;
    public int npcGoldValue;
    public List <Item> playerItemsList;
    public List <Item> npcItemsList;
    public barteringUIScript uiScript;
    public Item selectedItemFromNPC;
    public Item selectedItemFromPlayer;

    // Update is called once per frame
    void Update()
    {
        playerGoldValue = this.gameObject.GetComponent<inventoryScript>().playerCurrency;
        playerItemsList = this.gameObject.GetComponent<inventoryScript>().inventoryItemsList;

        if(this.gameObject.GetComponent<StateManager>().currentNPC)
        {
            npcItemsList = this.gameObject.GetComponent<StateManager>().currentNPC.GetComponent<npcScript>().barteringItems;
            npcGoldValue = this.gameObject.GetComponent<StateManager>().currentNPC.GetComponent<npcScript>().barteringGold;
        }
    }

    public void BuyItem(Item itemToBuy)
    {
        this.gameObject.GetComponent<inventoryScript>().AddItemToInventory(itemToBuy);
        this.gameObject.GetComponent<inventoryScript>().SubtractGold((itemToBuy.itemValue));
        this.gameObject.GetComponent<StateManager>().currentNPC.GetComponent<npcScript>().barteringGold += itemToBuy.itemValue;
        this.gameObject.GetComponent<StateManager>().currentNPC.GetComponent<npcScript>().barteringItems.Remove(itemToBuy);
        uiScript.DisplayItem(itemToBuy, uiScript.playerItemsSection, uiScript.playerPrefabArray);
        uiScript.RemoveItemObj(uiScript.currentlySelectedObj, uiScript.npcPrefabArray);
        uiScript.currentlySelectedObj = null;
        selectedItemFromNPC = null;
    }

    public void SellItem(Item itemToSell)
    {
        this.gameObject.GetComponent<inventoryScript>().RemoveItemFromInventory(itemToSell);
        this.gameObject.GetComponent<inventoryScript>().AddGold((itemToSell.itemValue));
        this.gameObject.GetComponent<StateManager>().currentNPC.GetComponent<npcScript>().barteringGold -= itemToSell.itemValue;
        this.gameObject.GetComponent<StateManager>().currentNPC.GetComponent<npcScript>().AddItemToList(itemToSell);
        uiScript.DisplayItem(itemToSell, uiScript.npcItemsSection, uiScript.npcPrefabArray);
        uiScript.RemoveItemObj(uiScript.currentlySelectedObj, uiScript.playerPrefabArray);
        uiScript.currentlySelectedObj = null;
        selectedItemFromPlayer = null;
    }
}
