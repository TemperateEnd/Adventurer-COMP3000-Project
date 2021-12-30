using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class inventoryItemScript : MonoBehaviour
{
    public TextMeshProUGUI itemText;
    public Item inventoryItem;
    public GameObject equippedIcon;

    // Start is called before the first frame update
    void Start()
    {
        itemText = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update() 
    {
        itemText.SetText(inventoryItem.itemName);
    }

    void OnPointerClick(){
        SelectItem();
    }

    public void SelectItem(){
        Debug.Log("This has been clicked on");
        this.gameObject.GetComponentInParent<inventoryUIScript>().inventory.currentlySelectedItem = inventoryItem;
        this.gameObject.GetComponentInParent<inventoryUIScript>().currentlySelectedInventoryItem = this.gameObject;
    }
}
