using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    
    // Interface elements
    public GameObject pauseMenu;
    public static bool isPaused; //Responsible for pausing/unpausing the game.
    public GameObject upgradeMenu;
    public static bool isUpgrading;
    public TextMeshProUGUI dayText;

    // When true enables console debugging.
    [SerializeField] private bool enableDebugging;


    // Gets all scripts needed
    public GameObject TimeController;
    private TimeManager timeManager;
    public GameObject DayProgressBar;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        SetDayText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDayProgressBar();

        if (Input.GetKeyDown("escape") && isUpgrading == false)
        {
            //print("Escape key was pressed");
            PauseMenu();
        }
    }


    public void UpdateDayProgressBar()
    {
        timeManager = TimeController.GetComponent<TimeManager>();

        float length = timeManager.dayLength;    // Takes daylength variable from TimeManager script and attaches it to a local variable.
        float time = timeManager.timer;     // Takes timer variable from TimeManager script and attaches it to a local variable.

        DayProgressBar.GetComponent<ProgressBar>().maxBarValue = length; // Sets the max value of the day progress bar to match the dayLength variable.

        DayProgressBar.GetComponent<ProgressBar>().BarValue = length - time; // Subtracts the length and time variables and attaches it to the BarValue from the ProgressBar script.
    }

    public void PauseMenu()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            ResumeGame();
        }
        else if (!isPaused)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            PauseGame();
        }
    }


    public void UpgradeMenu()
    {
        timeManager = TimeController.GetComponent<TimeManager>();

        if (isUpgrading)
        {
            isUpgrading = false;
            upgradeMenu.SetActive(false);
            timeManager.isCounting = true;
            ResumeGame();
            SetDayText();
        }
        else if (!isUpgrading)
        {
            isUpgrading = true;
            upgradeMenu.SetActive(true);
            timeManager.isCounting = false;
            PauseGame();
        }
    }

    //Pauses the game when called
    public void PauseGame()
    {
        Time.timeScale = 0f; //Stops the game
        isPaused = true;
        Debugger("PauseGame"); //Calls the Debug method to prints to console
    }
    
    //Unpauses the game when called
    public void ResumeGame()
    {
        Time.timeScale = 1f; //Resumes the game
        isPaused = false;
        Debugger("ResumeGame"); //Calls the Debug method to prints to console
    }

    public void SetDayText()
    {
        timeManager = TimeController.GetComponent<TimeManager>();

        dayText.text = "Day " + timeManager.days;
    }

    void Debugger(string type)
    {
        if (enableDebugging == true)
        {
            if (type == "ResumeGame")
            {
                Debug.Log("Resumed Game.");
            }
            if (type == "PauseGame")
            {
                Debug.Log("Paused Game.");
            }
        }
    }
}