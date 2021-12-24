using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class inventoryItemScript : MonoBehaviour
{
    public TextMeshProUGUI itemText;
    public Item inventoryItem;

    // Start is called before the first frame update
    void Start()
    {
        itemText = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update() 
    {
        itemText.SetText(inventoryItem.itemName);
    }

    void OnPointerClick(){
        this.gameObject.GetComponentInParent<inventoryUIScript>().inventory.currentlySelectedItem = inventoryItem;
    }
}
