using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class barteringObjScript : MonoBehaviour
{
    public TextMeshProUGUI objText;
    public Item itemContained;

    // Start is called before the first frame update
    void Start()
    {
        objText = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        objText.SetText(itemContained.itemName + ": " + itemContained.itemValue + " gold");
    }
}
