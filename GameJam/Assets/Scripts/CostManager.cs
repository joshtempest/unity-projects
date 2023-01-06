using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostManager : MonoBehaviour
{
    //Declares all the variables needed
    private float elecPrice = 1f;
    private float onionPrice = 1f;
    private float tomatoPrice = 1.5f;
    private float saltPrice = 0.5f;
    private float carrotPrice = 1.2f;
    public float finalPrice;
    public float allIngrePrice;
    public int day;
    public float finalElec;

    //Gets all scripts needed
    public GameObject TimeController;
    public TimeManager timeManager;

    //Magic numbers, stand-ins from other scripts
    public float Time = 3;
    public int tomatoUsed = 2;
    public int carrotUsed = 1;
    public int onionUsed = 1;
    public int saltUsed = 0;


   
    void Start()
    {

    }

    public void PriceCalculation()
    {
        //Gets variable days from timeManager script
        timeManager = TimeController.GetComponent<TimeManager>();
        day = timeManager.days;

        //Calculates the total electricity price for the day
        finalElec = elecPrice + ((float)day / 2);
        Debug.LogFormat("Elecprice is: {0}", elecPrice);

        //Calculates the price of all ingredients used
        allIngrePrice = ((float)tomatoUsed * tomatoPrice) + ((float)carrotUsed * carrotPrice) + ((float)onionUsed * onionPrice) + ((float)saltUsed * saltPrice);
        Debug.Log(allIngrePrice);

        //Calculates the final price for the day
        finalPrice = (finalElec * Time) + allIngrePrice;
        Debug.LogFormat("final price for today is {0}", finalPrice);
    }
}
