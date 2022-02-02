using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{
    [Header("Dialogue")]
    public DialogueTree npcDialogueTree;
    public bool readyForDialogue;
    [Header("Bartering")]
    public List<Item> barteringItems;
    public int barteringGold;
}
