using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class dialogueButtonScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueButtonText;
    public DialogueOption optionRepresented;

    // Start is called before the first frame update
    void Start()
    {
        dialogueButtonText = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update() 
    {
        dialogueButtonText.SetText(optionRepresented.optionText);
    }

    void OnPointerClick() {
        OptionSelected();
    }

    // Update is called once per frame
    public void OptionSelected()
    {
        Debug.Log(this.gameObject.name + " has been selected");
        if(optionRepresented.GetType() != typeof(DialogueOption))
        {
            this.gameObject.GetComponentInParent<dialogueUIScript>().DialogueOptionSelected((DialogueOption)optionRepresented);
        }

        else
        {
            this.gameObject.GetComponentInParent<dialogueUIScript>().DialogueOptionSelected(optionRepresented);
        }
    }
}
