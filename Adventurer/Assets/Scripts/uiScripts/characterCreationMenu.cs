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
    public Button subtractStatStrength;
    public Button subtractStatIntelligence;
    public Button subtractStatCharisma;
    public Button subtractStatEndurance;
    public Button subtractStatWisdom;
    public Button subtractStatDexterity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempCharacterName = characterNameField.GetComponent<TMP_InputField>().text;

        strengthText.SetText("Strength: " + tempStrength);
        intelligenceText.SetText("Intelligence: " + tempIntelligence);
        charismaText.SetText("Charisma: " + tempCharisma);
        enduranceText.SetText("Endurance: " + tempEndurance);
        wisdomText.SetText("Wisdom: " + tempWisdom);
        dexterityText.SetText("Dexterity: " + tempDexterity);

        if(availablePoints <= 0)
        {
            addStatStrength.GetComponent<Button>().interactable = false;
            addStatIntelligence.GetComponent<Button>().interactable = false;
            addStatCharisma.GetComponent<Button>().interactable = false;
            addStatEndurance.GetComponent<Button>().interactable = false;
            addStatWisdom.GetComponent<Button>().interactable = false;
            addStatDexterity.GetComponent<Button>().interactable = false;
        }
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

                else if (tempStrength <= 0)
                {
                    subtractStatStrength.GetComponent<Button>().interactable = false;
                }
                break;
            case "Intelligence":
                if(tempIntelligence > 0)
                {
                    tempIntelligence--;
                }

                else if (tempIntelligence <= 0)
                {
                    subtractStatIntelligence.GetComponent<Button>().interactable = false;
                }
                break;
            case "Charisma":
                if(tempCharisma > 0)
                {
                    tempCharisma--;
                }

                else if (tempCharisma <= 0)
                {
                    subtractStatCharisma.GetComponent<Button>().interactable = false;
                }
                break;
            case "Endurance":
                if(tempEndurance > 0)
                {
                    tempEndurance--;
                }

                else if (tempEndurance <= 0)
                {
                    subtractStatEndurance.GetComponent<Button>().interactable = false;
                }
                break;
            case "Wisdom":
                if(tempWisdom > 0)
                {
                    tempWisdom--;
                }

                else if (tempWisdom <= 0)
                {
                    subtractStatWisdom.GetComponent<Button>().interactable = false;
                }
                break;
            case "Dexterity":
                if(tempDexterity > 0)
                {
                    tempDexterity--;
                }

                else if (tempDexterity <= 0)
                {
                    subtractStatDexterity.GetComponent<Button>().interactable = false;
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

    public void ChooseClass(string classChoice) //Resets chosenClass before setting the new class;
    {
        chosenClass = null;
        chosenClass = Resources.Load<CharacterClass>("ScriptableObjects/" + classChoice);
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


        BaseCharacter newCharacter = new BaseCharacter(tempCharacterName, chosenClass, tempStrength, tempIntelligence, 
                                                        tempCharisma, tempEndurance, tempWisdom, tempDexterity);

        StateManager.InstanceRef.currentCharacter = newCharacter;

        StateManager.InstanceRef.SwitchState(new PlayState(StateManager.InstanceRef));
    }
}
