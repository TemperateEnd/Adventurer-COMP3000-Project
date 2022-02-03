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

        if((barteringBackEnd.selectedItemFromNPC) && (barteringBackEnd.playerGoldValue >= barteringBackEnd.selectedItemFromNPC.itemValue))
        {
            if(Input.GetButtonDown("Interact"))
            {
                barteringBackEnd.BuyItem(barteringBackEnd.selectedItemFromNPC);
            }
        }

        else if ((barteringBackEnd.selectedItemFromPlayer) && (barteringBackEnd.npcGoldValue >= barteringBackEnd.selectedItemFromPlayer.itemValue))
        {
            if(Input.GetButtonDown("Interact"))
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
        StateManager.InstanceRef.toggleBartering = false;
    }
}
