using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueButtonScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueButtonText;
    public DialogueOption optionRepresented;

    // Start is called before the first frame update
    void Start()
    {
        dialogueButtonText.SetText(optionRepresented.optionText);
    }

    // Update is called once per frame
    void OptionSelected()
    {
        this.gameObject.GetComponentInParent<dialogueUIScript>().DialogueOptionSelected(optionRepresented);
    }
}
