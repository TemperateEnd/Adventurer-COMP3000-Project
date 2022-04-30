using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class characterCreationMenu : MonoBehaviour
{
    public byte availablePoints; //You get 8 points to allocate across all 6 primary attributes
    [Header("Character Details")]
    public string tempCharacterName;
    public CharacterClass chosenClass;
    public byte tempStrength; //By default, this will be at 5, as will other stats
    public byte tempIntelligence;
    public byte tempCharisma;
    public byte tempEndurance;
    public byte tempWisdom;
    public byte tempDexterity;

    [Header("UI")]
    public GameObject characterNameField;
    [Header("TextMeshPro")]
    public TextMeshProUGUI characterClassChoiceText;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI intelligenceText;
    public TextMeshProUGUI charismaText;
    public TextMeshProUGUI enduranceText;
    public TextMeshProUGUI wisdomText;
    public TextMeshProUGUI dexterityText;
    [Header("Buttons - Increment Stats")]
    public Button addStatStrength;
    public Button addStatIntelligence;
    public Button addStatCharisma;
    public Button addStatEndurance;
    public Button addStatWisdom;
    public Button addStatDexterity;
    [Header("Buttons - Decrement Stats")]
    public Button subtractStatStrength;
    public Button subtractStatIntelligence;
    public Button subtractStatCharisma;
    public Button subtractStatEndurance;
    public Button subtractStatWisdom;
    public Button subtractStatDexterity;

    // Update is called once per frame
    void Update()
    {
        tempCharacterName = characterNameField.GetComponent<TMP_InputField>().text;

        if(chosenClass)
            characterClassChoiceText.SetText("Chosen class: " + chosenClass.className);

        strengthText.SetText("Strength: " + tempStrength);
        intelligenceText.SetText("Intelligence: " + tempIntelligence);
        charismaText.SetText("Charisma: " + tempCharisma);
        enduranceText.SetText("Endurance: " + tempEndurance);
        wisdomText.SetText("Wisdom: " + tempWisdom);
        dexterityText.SetText("Dexterity: " + tempDexterity);

        pointsText.SetText("Available Points: " + availablePoints);

        if(availablePoints == 0)
        {
            addStatStrength.GetComponent<Button>().interactable = false;
            addStatIntelligence.GetComponent<Button>().interactable = false;
            addStatCharisma.GetComponent<Button>().interactable = false;
            addStatEndurance.GetComponent<Button>().interactable = false;
            addStatWisdom.GetComponent<Button>().interactable = false;
            addStatDexterity.GetComponent<Button>().interactable = false;
        }

        else if (availablePoints > 0)
        {
            addStatStrength.GetComponent<Button>().interactable = true;
            addStatIntelligence.GetComponent<Button>().interactable = true;
            addStatCharisma.GetComponent<Button>().interactable = true;
            addStatEndurance.GetComponent<Button>().interactable = true;
            addStatWisdom.GetComponent<Button>().interactable = true;
            addStatDexterity.GetComponent<Button>().interactable = true;
        }

        if (tempStrength == 5)
        {
            subtractStatStrength.GetComponent<Button>().interactable = false;
        }

        if (tempIntelligence == 5)
        {
            subtractStatIntelligence.GetComponent<Button>().interactable = false;
        }

        if (tempCharisma == 5)
        {
            subtractStatCharisma.GetComponent<Button>().interactable = false;
        }

        if (tempEndurance == 5)
        {
            subtractStatEndurance.GetComponent<Button>().interactable = false;
        }

        if (tempWisdom == 5)
        {
            subtractStatWisdom.GetComponent<Button>().interactable = false;
        }

        if (tempDexterity == 5)
        {
            subtractStatDexterity.GetComponent<Button>().interactable = false;
        }
    }

    //Decrement stat on button press
    public void DecreaseStat(string statToDecrement)
    {
        switch(statToDecrement)
        {
            case "Strength":
                if(tempStrength > 5)
                {
                    tempStrength--;
                    availablePoints++;
                }
                break;
            case "Intelligence":
                if(tempIntelligence > 5)
                {
                    tempIntelligence--;
                    availablePoints++;
                }
                break;
            case "Charisma":
                if(tempCharisma > 5)
                {
                    tempCharisma--;
                    availablePoints++;
                }
                break;
            case "Endurance":
                if(tempEndurance > 5)
                {
                    tempEndurance--;
                    availablePoints++;
                }
                break;
            case "Wisdom":
                if(tempWisdom > 5)
                {
                    tempWisdom--;
                    availablePoints++;
                }
                break;
            case "Dexterity":
                if(tempDexterity > 5)
                {
                    tempDexterity--;
                    availablePoints++;
                }
                break;
        }
        
    }

    public void IncreaseStat(string statToIncrement)
    {
        if(availablePoints > 0)
        {
            switch(statToIncrement)
            {
                case "Strength":
                    tempStrength++;
                    if(tempStrength > 5)
                    {
                        subtractStatStrength.GetComponent<Button>().interactable = true;
                    }
                    break;
                case "Intelligence":
                    tempIntelligence++;

                    if(tempIntelligence > 5)
                    {
                        subtractStatIntelligence.GetComponent<Button>().interactable = true;
                    }
                    break;
                case "Charisma":
                    tempCharisma++;

                    if(tempCharisma > 5)
                    {
                        subtractStatCharisma.GetComponent<Button>().interactable = true;
                    }
                    break;
                case "Endurance":
                    tempEndurance++;

                    if(tempEndurance > 5)
                    {
                        subtractStatEndurance.GetComponent<Button>().interactable = true;
                    }
                    break;
                case "Wisdom":
                    tempWisdom++;

                    if(tempWisdom > 5)
                    {
                        subtractStatWisdom.GetComponent<Button>().interactable = true;
                    }
                    break;
                case "Dexterity":
                    tempDexterity++;

                    if(tempDexterity > 5)
                    {
                        subtractStatDexterity.GetComponent<Button>().interactable = true;
                    }
                    break;
            }
            availablePoints--;
        }
    }

    public void ChooseClass(string classChoice) //Resets chosenClass before setting the new class;
    {
        chosenClass = Resources.Load<CharacterClass>("ScriptableObjects/Classes/" + classChoice);
    }

    public void CreateCharacter()
    {
        if(chosenClass.className == "Warrior")
        {
            tempStrength+=2;
            tempEndurance+=1;
        }

        else if(chosenClass.className == "Mage")
        {
            tempIntelligence+=2;
            tempWisdom+=1;
        }

        else if(chosenClass.className == "Rogue")
        {
            tempDexterity+=2;
            tempCharisma+=1;
        }

        StateManager.InstanceRef.characterName = tempCharacterName;
        StateManager.InstanceRef.characterLevel = 1;
        StateManager.InstanceRef.characterClass = chosenClass;

        StateManager.InstanceRef.characterStrength = tempStrength;
        StateManager.InstanceRef.characterIntelligence = tempIntelligence;
        StateManager.InstanceRef.characterCharisma = tempCharisma;
        StateManager.InstanceRef.characterEndurance = tempEndurance;
        StateManager.InstanceRef.characterWisdom = tempWisdom;
        StateManager.InstanceRef.characterDexterity = tempDexterity;

        StateManager.InstanceRef.SwitchState(new PlayState(StateManager.InstanceRef));
    }
}
