using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //This will be useful as the FSM will be working with the in-game UI elements (i.e. menus, HUD, etc)

public enum GameState { Default, MainMenu, Play, Pause }
public class StateManager : MonoBehaviour
{
    private IBaseState IActiveState;
    public static StateManager InstanceRef = null;
    private static StateManager instanceRef;

    [Header("UI - To Be Added")]
    public GameObject mainMenuUI;
    [Space(10)] 
    public GameObject mainCam;
    public GameState gameState;
    [Space(10)] 
    [Header("Player Variables")]
    public float testVariable;

    /*Spaces and Headers are going to be used to better categorise variables that will be used for this script,
    such as UI, playerVariables (i.e. currency, skill levels, skill points, etc)*/

    // Start is called before the first frame update
    void Awake()
    {
        mainCam = GameObject.FindWithTag("MainCamera"); 

        if(instanceRef = null)
        {
            DestroyImmediate(gameObject);
        }

        else
        {
            instanceRef = this;
            DontDestroyOnLoad(instanceRef);
            InstanceRef = this;
        }
    }

    void Start() 
    {
        IActiveState = new StartState(this);
    }

    private void Update() 
    {
        mainCam = GameObject.FindWithTag("MainCamera");

        if(IActiveState != null)
        {
            IActiveState.StateUpdate();
        }

        switch(gameState)
        {
            default:
                break;
        }
    }

    // Called when state machine needs to switch state
    public void SwitchState(IBaseState nextState)
    {
        IActiveState = nextState;
    }
}
