using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class barteringUIScript : MonoBehaviour
{
    public barteringScript barteringBackEnd;
    public TextMeshProUGUI playerGoldText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerGoldText.SetText(barteringBackEnd.playerGoldValue + " Gold");
    }
}
