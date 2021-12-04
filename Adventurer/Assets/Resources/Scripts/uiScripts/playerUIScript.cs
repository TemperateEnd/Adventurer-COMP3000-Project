using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerUIScript : MonoBehaviour
{
    public GameObject player;
    public Slider healthBar;
    public Slider staminaBar;

    // Update is called once per frame
    void Update()
    {
        staminaBar.maxValue = player.GetComponent<playerAttributes>().staminaMax;
        healthBar.maxValue = player.GetComponent<playerAttributes>().healthMax;

        staminaBar.value = player.GetComponent<playerAttributes>().currStamina;
        healthBar.value = player.GetComponent<playerAttributes>().currHealth;
    }
}
