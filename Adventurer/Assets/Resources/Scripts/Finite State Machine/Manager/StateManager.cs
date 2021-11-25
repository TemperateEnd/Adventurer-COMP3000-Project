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
    public levelUpScript levelUpManager;

    [Header("UI - To Be Added")]
    public GameObject mainMenuUI;
    public GameObject pauseMenuUI; 
    public GameObject gameplayHUD;
    public GameObject characterCreationUI;
    public GameObject characterDetailsUI;
    public GameObject dialogueUI;
    [Space(10)]  
    [Header("PlayState UI")]
    public bool toggleCharDetails;
    [Space(10)]  
    public Canvas uiCanvas;
    public GameObject mainCam;
    public GameState gameState;
    [Space(10)] 
    [Header("Player Variables")]
    [Space(5)]
    [Header("Character Details")]
    public string characterName;
    public byte characterLevel;
    public CharacterClass characterClass;
    public byte characterStrength;
    public byte characterIntelligence;
    public byte characterCharisma;
    public byte characterEndurance;
    public byte characterWisdom;
    public byte characterDexterity;
    [Header("Skill Levels")]
    public Skill[] skills;
   

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

        for(int i = 0; i < skills.Length; i++)
        {
            skills[i].skillLevel = 0; //Have it be 0 by default
        }
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
                characterCreationUI.SetActive(false);
                pauseMenuUI.SetActive(false);
                gameplayHUD.SetActive(false);
                break;

            case GameState.CharacterCreation:
                mainMenuUI.SetActive(false);
                characterCreationUI.SetActive(true);
                pauseMenuUI.SetActive(false);
                gameplayHUD.SetActive(false);
                break;

            case GameState.Pause:
                pauseMenuUI.SetActive(true);
                break;

            case GameState.Play:
                mainMenuUI.SetActive(false);
                characterCreationUI.SetActive(false);
                pauseMenuUI.SetActive(false);
                gameplayHUD.SetActive(true);

                if(Input.GetKeyDown(KeyCode.C))
                {
                    toggleCharDetails = !toggleCharDetails;

                    if (toggleCharDetails)
                    {
                        Time.timeScale = 0;
                    }

                    else
                    {
                        Time.timeScale = 1;
                    }
                    characterDetailsUI.SetActive(toggleCharDetails);
                }
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
