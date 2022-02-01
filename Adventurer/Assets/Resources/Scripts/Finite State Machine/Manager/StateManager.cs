using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //This will be useful as the FSM will be working with the in-game UI elements (i.e. menus, HUD, etc)

public enum GameState { Default, MainMenu, CharacterCreation, Play, Pause, Inventory, CharacterDetails, Dialogue, Barter, Quit }
public class StateManager : MonoBehaviour
{
    public GameObject playerObj;
    float timeScale;
    private IBaseState IActiveState;
    public static StateManager InstanceRef = null;
    private static StateManager instanceRef;
    public levelUpScript levelUpManager;

    [Header("UI")]
    public GameObject mainMenuUI;
    public GameObject pauseMenuUI; 
    public GameObject gameplayHUD;
    public GameObject characterCreationUI;
    public GameObject characterDetailsUI;
    public GameObject dialogueUI;
    public GameObject playerUI;
    public GameObject inventoryUI;
    public GameObject barteringUI;
    [Space(10)]
    [Header("PlayState elements - Bartering")]
    //script instance for bartering partner
    public bool toggleBarteringActive;
    [Space(10)]  
    [Header("PlayState elements - Dialogue")]
    public DialogueTree currentNPC;
    public bool toggleDialogueActive;
    public bool withinDialogueRange;
    [Space(5)]
    [Header("PlayState elements - Other Menus")]
    public bool toggleInventory;
    public bool toggleCharDetails;
    [Space(10)]  
    public Canvas uiCanvas;
    public GameObject mainCam;
    public GameState gameState;
    [Space(10)] 
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
        this.gameObject.GetComponent<inventoryScript>().enabled = false;
        IActiveState = new StartState(this);

        for(int i = 0; i < skills.Length; i++)
        {
            skills[i].skillLevel = 0; //Have it be 0 by default
        }
    }

    void Update() 
    {
        timeScale = Time.timeScale;
        mainCam = GameObject.FindWithTag("MainCamera");
        uiCanvas.worldCamera = mainCam.GetComponent<Camera>();
        uiCanvas.planeDistance = 0.5f;

        if(IActiveState != null)
        {
            IActiveState.StateUpdate();
        }

        if(Input.GetButtonDown("Pause"))
        {
            if(gameState == GameState.Play)
            {
                PauseGame();
            }

            else if(gameState == GameState.Pause)
            {
                ResumeGame();
            }
        }

        switch(gameState)
        {
            case GameState.MainMenu:
                mainMenuUI.SetActive(true);
                characterCreationUI.SetActive(false);
                pauseMenuUI.SetActive(false);
                gameplayHUD.SetActive(false);
                playerUI.SetActive(false);
                break;

            case GameState.CharacterCreation:
                mainMenuUI.SetActive(false);
                characterCreationUI.SetActive(true);
                pauseMenuUI.SetActive(false);
                gameplayHUD.SetActive(false);
                playerUI.SetActive(false);
                break;

            case GameState.Pause:
                pauseMenuUI.SetActive(true);
                break;

            case GameState.Play:
                mainMenuUI.SetActive(false);
                characterCreationUI.SetActive(false);
                pauseMenuUI.SetActive(false);
                gameplayHUD.SetActive(true);
                playerUI.SetActive(true);
                playerObj = GameObject.FindWithTag("Player");
                ResumeGame();
                if(playerObj)
                {
                    this.gameObject.GetComponent<inventoryScript>().enabled = true;
                    this.gameObject.GetComponent<inventoryScript>().playerAttribs = playerObj.GetComponent<playerAttributes>();
                }

                if(Input.GetButtonDown("Interact") && withinDialogueRange)
                {
                    toggleDialogueActive = true;
                    dialogueUI.GetComponent<dialogueUIScript>().currentTree = currentNPC;
                    gameState = GameState.Dialogue;
                }

                if(Input.GetKeyDown(KeyCode.C))
                {
                    toggleCharDetails = true;
                    gameState = GameState.CharacterDetails;
                }


                if(Input.GetKeyDown(KeyCode.I))
                {
                    toggleInventory = true;
                    gameState = GameState.Inventory;
                }

                break;

            case GameState.CharacterDetails:
                characterDetailsUI.SetActive(true);
                PauseGame();

                if(!toggleCharDetails)
                {
                    characterDetailsUI.SetActive(false);
                    gameState = GameState.Play;
                }
                break;
            case GameState.Dialogue:
                dialogueUI.SetActive(true);
                PauseGame();

                if(!toggleDialogueActive)
                {
                    dialogueUI.SetActive(false);
                    dialogueUI.GetComponent<dialogueUIScript>().currentTree = null;
                    gameState = GameState.Play;
                }
                break;
            case GameState.Inventory:
                inventoryUI.SetActive(true);
                PauseGame();

                if(!toggleInventory)
                {
                    inventoryUI.SetActive(false);
                    gameState = GameState.Play;
                }
                break;

            case GameState.Barter:
                barteringUI.SetActive(true);
            default:
                break;
        }
    }

    // Called when state machine needs to switch state
    public void SwitchState(IBaseState nextState)
    {
        IActiveState = nextState;
    }

    public void PauseGame()
    {
        Debug.Log("Should be paused");
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void ResumeGame()
    {
        Debug.Log("Should be resumed");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
}
