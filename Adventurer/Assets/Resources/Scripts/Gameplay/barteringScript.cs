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

    public Item selectedItem;

    // Update is called once per frame
    void Update()
    {
        playerGoldValue = this.gameObject.GetComponent<inventoryScript>().playerCurrency;
        playerItemsList = this.gameObject.GetComponent<inventoryScript>().inventoryItemsList;
    }
}
