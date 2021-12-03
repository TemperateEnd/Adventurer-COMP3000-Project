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

        staminaBar.value = Mathf.Clamp(player.GetComponent<playerAttributes>().currStamina, 0, staminaBar.maxValue);
        healthBar.value = Mathf.Clamp(player.GetComponent<playerAttributes>().currHealth, 0, healthBar.maxValue);
    }
}
