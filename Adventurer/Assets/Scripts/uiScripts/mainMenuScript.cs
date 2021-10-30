using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuScript : MonoBehaviour
{

    //Does something different depending on what is passed into method
    public void ButtonMethod(string btnFunction)
    {
        switch(btnFunction)
        {
            case "StartGame":
                StateManager.InstanceRef.SwitchState(new PlayState(StateManager.InstanceRef));
                break;

            case "ExitGame":
                Application.Quit();
                break;
        }
    }
}
