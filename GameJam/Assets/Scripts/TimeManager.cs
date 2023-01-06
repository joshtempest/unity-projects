using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float dayLength;
    [HideInInspector] public float timer;
    [HideInInspector] public int days;
    [HideInInspector] public bool isNight;
    [HideInInspector] public bool isCounting;

    // Gets all scripts needed.
    public GameObject SceneController;
    public GameObject MoneyController;
    private MenuManager menuManager;
    private MoneyCounter moneyCounter;

    // When true enables console debugging.
    [SerializeField] private bool enableDebugging;

    // Start is called before the first frame update
    void Start()
    {
        isNight = false;

        moneyCounter= MoneyController.GetComponent<MoneyCounter>();
        menuManager = SceneController.GetComponent<MenuManager>();

        days = 1;
}

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeCounter(); // Runs the TimeManager() method every frame.
    }

    public void TimeCounter()
    {
        if (isCounting == true) // If isCounting bool is true, the TimeManager function will run.
        {
            // Disables the night.
            isNight = false;
            Debugger("isNotNight");

            timer += Time.deltaTime;
            //Debug.Log("Timer = " + timer);

            if (timer >= dayLength)
            {
                days += 1; // Adds a day to the days variable.
                GameOverScene.totalDays = days; //Sets the value of total days (from "GameOverScene") to the amount of days
                timer = 0; // Resets the timer for he next day.
                
                Debugger("Days");
                Debugger("isNight");

                menuManager.UpgradeMenu();
                moneyCounter.NightTimeStuff();

                isNight = true;
            }
        }
        else
        {
            timer = 0; // Resets the timer.
        }
    }
    void Debugger(string type)
    {
        if (enableDebugging == true)
        {
            if (type == "Days")
            {
                Debug.Log("Days = " + days);
            }
            if (type == "isNight")
            {
                Debug.Log("It is now night.");
            }
            if (type == "isNotNight")
            {
                Debug.Log("It is now night.");
            }
        }
    }
}