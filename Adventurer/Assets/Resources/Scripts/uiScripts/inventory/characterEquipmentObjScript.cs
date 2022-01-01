using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class characterEquipmentObjScript : MonoBehaviour
{
    public TextMeshProUGUI equipmentText;
    public Equippable characterEquipmentPiece;

    // Start is called before the first frame update
    void Start()
    {
        equipmentText = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        equipmentText.SetText(characterEquipmentPiece.itemName);
    }

    void OnPointerClick() //Enables Mouse-based interaction with object
    {
        SelectEquipment();
    }

    public void SelectEquipment() //For player to select piece of equipment in case they wish to check the stats of a particular piece
    {
        this.gameObject.GetComponentInParent<characterEquipmentScript>().currentlySelectedEquipment = characterEquipmentPiece;
    }
}
