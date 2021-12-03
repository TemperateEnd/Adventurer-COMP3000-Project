using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayState : IBaseState
{
    private StateManager stateManager;
    private Scene scene;

    public PlayState(StateManager smRef)
    {
        stateManager =smRef;
        scene = SceneManager.GetActiveScene();

        if(scene.name != "PlayState")
        {
            SceneManager.LoadScene("PlayState");
        }

        stateManager.gameState = GameState.Play;
        stateManager.playerUI.GetComponent<playerUIScript>().player = GameObject.FindWithTag("Player");
    }

    public void StateUpdate()
    {}

    public void SwitchOver(){ //Is meant to return to StartState. Will be testing this after FSM is implemented to an acceptable state.
        StateManager.InstanceRef.SwitchState(new StartState (StateManager.InstanceRef)); 
    }
}
