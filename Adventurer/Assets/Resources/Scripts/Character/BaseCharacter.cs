using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I am using the OOP concepts that I have learned from SOFT152 to create the BaseCharacter class
public class BaseCharacter
{
    public string characterName;
    public CharacterClass characterClass;
    public byte strengthStat;
    public byte intelligenceStat;
    public byte charismaStat;
    public byte enduranceStat;
    public byte wisdomStat;
    public byte dexterityStat;

    public BaseCharacter (string newName, CharacterClass newClass,
                            byte newStrength, byte newIntelligence, byte newCharisma,
                            byte newEndurance, byte newWisdom, byte newDexterity)
    {
        characterName =  newName;
        characterClass = newClass;
        strengthStat = newStrength;
        intelligenceStat = newIntelligence;
        charismaStat = newCharisma;
        enduranceStat = newEndurance;
        wisdomStat = newWisdom;
        dexterityStat = newDexterity;
    }

    public string GetName()
    {
        return characterName;
    }

    public byte GetStrength()
    {
        return strengthStat;
    }

    public byte GetIntelligence()
    {
        return intelligenceStat;
    }

    public byte GetCharisma()
    {
        return charismaStat;
    }
    public byte GetEndurance()
    {
        return enduranceStat;
    }

    public byte GetWisdom()
    {
        return wisdomStat;
    }

    public byte GetDexterity()
    {
        return dexterityStat;
    }

    public void SetName(string newCharacterName)
    {
        characterName = newCharacterName;
    }

    public void SetStrength(byte newStrengthStat)
    {
        strengthStat = newStrengthStat;
    }

    public void SetIntelligence(byte newIntelligenceStat)
    {
        intelligenceStat = newIntelligenceStat;
    }

    public void SetCharisma(byte newCharismaStat)
    {
        charismaStat = newCharismaStat;
    }

    public void SetEndurance(byte newEnduranceStat)
    {
        enduranceStat = newEnduranceStat;
    }

    public void SetWisdom(byte newWisdomStat)
    {
        wisdomStat = newWisdomStat;
    }

    public void SetDexterity(byte newDexterityStat)
    {
        dexterityStat = newDexterityStat;
    }
}
