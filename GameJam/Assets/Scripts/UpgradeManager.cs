using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class UpgradeManager : MonoBehaviour
{

    public int pUpgrade;
    public int tUpgrade;

    public GameObject MoneyController;
    
    private MoneyCounter moneycounter;

    void Start()
    {
        moneycounter = MoneyController.GetComponent<MoneyCounter>();
        
    }

//This function is inwoked by pressing the button
    public void CustomerPatience()

    {
        if (moneycounter.currentMoney - 20 < 0) return;
        pUpgrade += 2;
        moneycounter.currentMoney -= 20;

    }

    public void Tips()

    {
        if (moneycounter.currentMoney - 25 < 0) return;
        tUpgrade += 2;
        moneycounter.currentMoney -= 25;
    }

}


      

