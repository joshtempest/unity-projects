using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using TMPro;
using System.Runtime.InteropServices;
using System.Linq;

public class CustomerManager : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public GameObject UpgradeController;
    UpgradeManager upgradeManager;
    private int upgrade;
    OrderManager om;
    public GameObject orderController;
    public float patienceTimer;
    
    // Start is called before the first frame update

    void Start()
    {
        // Starts the timer automatically
        upgradeManager = UpgradeController.GetComponent<UpgradeManager>();
        upgrade = upgradeManager.pUpgrade;
        timeRemaining += upgrade;
        upgradeManager = UpgradeController.GetComponent<UpgradeManager>();
        upgrade = upgradeManager.pUpgrade;
        timeRemaining += upgrade;
        om = orderController.GetComponent<OrderManager>();
        InvokeRepeating("GenerateCustomer", 2.0f, 5.0f); //Runs "GenerateCustomer" in 2 seconds and then repeats every 5 seconds 
    }


    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning == true) 
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                SetTimeText(timeRemaining);
            }

            else
            {
                //Debug.Log("Time has run out!");
                print("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;

            if (timeRemaining <= 0)
                {
                print("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                SetTimeText(timeRemaining);
                om.RemoveOrder(0, timeRemaining);
                }
            }
        }
        else if (!timerIsRunning)
        {
            SetTimeText(timeRemaining);
        }
    }

    public void SetTimeText(float time)
    {
        timeText.text = "Customer Patience: " + time.ToString("f0");
    }

    //Generates a customer named "Bob" and sets the price and time to 10.
    public void GenerateCustomer()
    {
        NewCustomer(10,"Bob", 10);
    }

    //Adds an order to the "OrderManager" game object and sets the patience timer
    public void NewCustomer(int price, string name, float time)
    {
        om.AddOrder(new Order(price, name));
        timeRemaining = time;
        timerIsRunning = true;
    }
}