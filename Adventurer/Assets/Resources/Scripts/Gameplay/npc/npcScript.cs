using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{
    [Header("Dialogue")]
    public DialogueTree npcDialogueTree;
    public bool readyForDialogue;
    public bool readyForCombat;
    
    [Header("NPC - Items")]
    public Armor npcArmor;
    public Weapon npcWeapon;
    public List<Item> barteringItems;
    public int barteringGold;

    async void Update()
    {
        if(readyForCombat)
        {
            this.gameObject.GetComponent<npcCombat>().enabled = true;
        }

        else
        {
            this.gameObject.GetComponent<npcCombat>().enabled = false;
        }
    }

    public void RemoveItemFromList(Item itemToRemove)
    {
        barteringItems.Remove(itemToRemove);
    }

    public void AddItemToList(Item itemToAdd)
    {
        barteringItems.Add(itemToAdd);
    }
}
