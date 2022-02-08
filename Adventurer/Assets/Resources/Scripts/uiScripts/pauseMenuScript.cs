using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenuScript : MonoBehaviour
{
    public void ResumeGame()
    {
        StateManager.InstanceRef.ResumeGame();
        StateManager.InstanceRef.gameState = GameState.Play;
    }

    public void ReturnToMainMenu()
    {
        StateManager.InstanceRef.gameState = GameState.MainMenu;
        StateManager.InstanceRef.SwitchState(new StartState(StateManager.InstanceRef));
    }
}
