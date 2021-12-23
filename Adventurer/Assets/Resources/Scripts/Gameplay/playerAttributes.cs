using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttributes : MonoBehaviour
{
    [Header("Health")]
    public float healthMax;
    public float currHealth;
    [Header("Stamina")]
    public float staminaRateOfLoss = 2.0f;
    public float staminaRateOfRegen = 5.0f;
    public float staminaRegenTime = 3.0f;
    public float staminaMax;
    public float currStamina;

    void Start() 
    {
        staminaMax = (100 + ((StateManager.InstanceRef.characterStrength) + (StateManager.InstanceRef.characterDexterity)));
        healthMax = (100 + ((StateManager.InstanceRef.characterStrength) + (StateManager.InstanceRef.characterEndurance)));

        currStamina = staminaMax;
        currHealth = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        if(currHealth >= healthMax)
        {
            currHealth = healthMax;
        }

        if(currStamina >= staminaMax)
        {
            currStamina = staminaMax;
        }

        //Code to test Health decrease and increase

        if(Input.GetKeyDown(KeyCode.Q))
        {
            ReduceAttribute("Health", 25);
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            RestoreAttribute("Health", 25);
        }

        //Code to test Health decrease and increase

        if(Input.GetKeyDown(KeyCode.T))
        {
            ReduceAttribute("Stamina", 25);
        }

        else if (Input.GetKeyDown(KeyCode.U))
        {
            RestoreAttribute("Stamina", 25);
        }
    }

    public void ReduceAttribute(string attributeToReduce, float numberToReduce)
    {
        switch(attributeToReduce)
        {
            case "Stamina":
                currStamina -= numberToReduce;
                break;
            
            case "Health":
                currHealth -= numberToReduce;
                break;
            
            default:
                break;
        }
    }

    public void ReduceAttributeOverTime(string attributeToReduce, float reductionRate)
    {
        switch(attributeToReduce)
        {
            case "Stamina":
                currStamina -= reductionRate * Time.deltaTime;
                break;
            
            case "Health":
                currHealth -= reductionRate * Time.deltaTime;
                break;
            
            default:
                break;
        }
    }

    public void RestoreAttribute(string attributeToRestore, float numberToRestore)
    {
        switch(attributeToRestore)
        {
            case "Stamina":
                currStamina -= numberToRestore;
                break;
            
            case "Health":
                currHealth -= numberToRestore;
                break;
            
            default:
                break;
        }
    }

    public void RestoreAttributeOverTime(string attributeToRestore, float restorationRate)
    {
        switch(attributeToRestore)
        {
            case "Stamina":
                currStamina += (restorationRate * Time.deltaTime);
                break;
            
            case "Health":
                currHealth += (restorationRate * Time.deltaTime);
                break;
            
            default:
                break;
        }
    }
}
