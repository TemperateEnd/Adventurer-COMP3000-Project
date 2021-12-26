using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class inventoryUIScript : MonoBehaviour
{
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
            itemValueText.SetText("Worth " + inventory.currentlySelectedItem.itemValue + " Gold");
            itemWeightText.SetText("Weighs about " + inventory.currentlySelectedItem.itemWeight + " KG");
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
}
