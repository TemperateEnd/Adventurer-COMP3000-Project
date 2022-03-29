using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{
    [Header("NPC - Primary stats")]
    public int npcStrength;
    public int npcIntelligence;
    public int npcDexterity;
    public int npcEndurance;
    public int npcWisdom;
    public int npcCharisma;
    [Header("NPC - Derived stats")]
    public float maxHP;
    public float currHP;
    public float maxStamina;
    public float currStamina;
    [Header("NPC - Dialogue")]
    public DialogueTree npcDialogueTree;
    public bool readyForDialogue;
    public bool readyForCombat;
    
    [Header("NPC - Items")]
    public Armor npcArmor;
    public Weapon npcWeapon;
    public List<Item> barteringItems;
    public int barteringGold;
    [Header("NPC - Misc")]
    public GameObject interationBoundary;

    void Start() {
        maxHP = (100 + (npcStrength + npcEndurance));
        currHP = maxHP;
        maxStamina = (100 + (npcStrength + npcDexterity));
        currStamina = maxStamina;
    }

    void Update()
    {
        if(readyForCombat)
        {
            this.gameObject.GetComponentInChildren<npcCombat>().enabled = true;
            interationBoundary.SetActive(false);
        }

        else
        {
            this.gameObject.GetComponentInChildren<npcCombat>().enabled = false;
            interationBoundary.SetActive(true);
        }

        if(currHP <= 0)
        {
            Destroy(this.gameObject);
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

    public void RemoveHealth(int hpToSubtract)
    {
        currHP -= hpToSubtract;
    }
}
