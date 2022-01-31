using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class barteringUIScript : MonoBehaviour
{
    public GameObject currentlySelectedObj;
    public GameObject barteringObjPrefab;
    public GameObject playerItemsSection;
    public GameObject npcItemsSection;
    public barteringScript barteringBackEnd;
    public TextMeshProUGUI playerGoldText;

    public List<GameObject> playerPrefabArray;
    public List<GameObject> npcPrefabArray;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    void DisplayItem(Item itemToDisplay, GameObject parentObj, List<GameObject> prefabArrayToUse)
    {
        GameObject barteringItemObj = Instantiate(barteringObjPrefab, transform.position, transform.rotation, parentObj.transform);
        barteringItemObj.GetComponent<barteringObjScript>().itemContained = itemToDisplay;
        prefabArrayToUse.Add(barteringItemObj);
    }
}
