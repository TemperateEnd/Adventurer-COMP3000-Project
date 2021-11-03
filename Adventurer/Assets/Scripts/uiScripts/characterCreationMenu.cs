using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class characterCreationMenu : MonoBehaviour
{
    public byte availablePoints;
    [Header("Character Details")]
    public string tempCharacterName;
    public byte tempStrength;
    public byte tempIntelligence;
    public byte tempCharisma;
    public byte tempEndurance;
    public byte tempWisdom;
    public byte tempDexterity;

    [Header("UI")]
    public InputField characterNameField;
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI intelligenceText;
    public TextMeshProUGUI charismaText;
    public TextMeshProUGUI enduranceText;
    public TextMeshProUGUI wisdomText;
    public TextMeshProUGUI dexterityText;
    public Button addStatStrength;
    public Button addStatIntelligence;
    public Button addStatCharisma;
    public Button addStatEndurance;
    public Button addStatWisdom;
    public Button addStatDexterity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempCharacterName = characterNameField.text.ToString();

        strengthText.SetText("Strength: " + tempStrength);
        intelligenceText.SetText("Intelligence: " + tempIntelligence);
        charismaText.SetText("Charisma: " + tempCharisma);
        enduranceText.SetText("Endurance: " + tempEndurance);
        wisdomText.SetText("Wisdom: " + tempWisdom);
        dexterityText.SetText("Dexterity: " + tempDexterity);
    }

    //Decrement stat on button press
    public void DecreaseStat(string statToDecrement)
    {
        switch(statToDecrement)
        {
            case "Strength":
                if(tempStrength > 0)
                {
                    tempStrength--;
                }
                break;
            case "Intelligence":
                if(tempIntelligence > 0)
                {
                    tempIntelligence--;
                }
                break;
            case "Charisma":
                if(tempCharisma > 0)
                {
                    tempCharisma--;
                }
                break;
            case "Endurance":
                if(tempEndurance > 0)
                {
                    tempEndurance--;
                }
                break;
            case "Wisdom":
                if(tempWisdom > 0)
                {
                    tempWisdom--;
                }
                break;
            case "Dexterity":
                if(tempDexterity > 0)
                {
                    tempDexterity--;
                }
                break;
        }
        availablePoints++;
    }

    public void IncreaseStat(string statToIncrement)
    {
        if(availablePoints > 0)
        {
            switch(statToIncrement)
            {
                case "Strength":
                    tempStrength++;
                    break;
                case "Intelligence":
                    tempIntelligence++;
                    break;
                case "Charisma":
                    tempCharisma++;
                    break;
                case "Endurance":
                    tempEndurance++;
                    break;
                case "Wisdom":
                    tempWisdom++;
                    break;
                case "Dexterity":
                    tempDexterity++;
                    break;
            }
            availablePoints--;
        }
    }
}
