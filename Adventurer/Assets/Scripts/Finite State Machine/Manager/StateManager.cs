using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //This will be useful as the FSM will be working with the in-game UI elements (i.e. menus, HUD, etc)

public enum GameState { Default, MainMenu, CharacterCreation, Play, Pause, Quit }
public class StateManager : MonoBehaviour
{
    private IBaseState IActiveState;
    public static StateManager InstanceRef = null;
    private static StateManager instanceRef;

    [Header("UI - To Be Added")]
    public GameObject mainMenuUI;
    public GameObject pauseMenuUI; 
    public GameObject gameplayHUD;
    public GameObject characterCreationUI;
    [Space(10)]  
    public Canvas uiCanvas;
    public GameObject mainCam;
    public GameState gameState;
    [Space(10)] 
    [Header("Player Variables")]
    public BaseCharacter currentCharacter;

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
        uiCanvas.worldCamera = mainCam.GetComponent<Camera>();

        if(IActiveState != null)
        {
            IActiveState.StateUpdate();
        }

        if(Input.GetButtonDown("Pause"))
        {
            if(gameState == GameState.Play)
            {
                Time.timeScale = 0;
                gameState = GameState.Pause;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            else if(gameState == GameState.Pause)
            {
                Time.timeScale = 1;
                gameState = GameState.Play;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        switch(gameState)
        {
            case GameState.MainMenu:
                mainMenuUI.SetActive(true);
                pauseMenuUI.SetActive(false);
                gameplayHUD.SetActive(false);
                break;

            case GameState.Pause:
                pauseMenuUI.SetActive(true);
                break;

            case GameState.Play:
                mainMenuUI.SetActive(false);
                pauseMenuUI.SetActive(false);
                gameplayHUD.SetActive(true);
                break;

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
