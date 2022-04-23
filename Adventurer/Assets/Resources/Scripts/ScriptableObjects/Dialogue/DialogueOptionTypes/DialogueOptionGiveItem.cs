using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueOption", menuName = "Adventurer/Dialogue/DialogueOption: Give Item", order = 0)]
public class DialogueOptionGiveItem : DialogueOption
{
    public Item itemToGive;
}
