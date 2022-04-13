using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartState : IBaseState
{
    private StateManager stateManager;
    private Scene scene;

    public StartState(StateManager smRef)
    {
        stateManager =smRef;
        scene = SceneManager.GetActiveScene();

        if(scene.name != "StartState")
        {
            SceneManager.LoadScene("StartState");
        }

        stateManager.gameState = GameState.MainMenu;
    }

    public void StateUpdate()
    {}

    public void SwitchOver(){ //Changes to PlayState. Will be testing this after FSM is implemented to an acceptable state.
        StateManager.InstanceRef.SwitchState(new PlayState(StateManager.InstanceRef));
    }
}
