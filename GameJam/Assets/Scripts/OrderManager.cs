using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    List<Order> orders = new List<Order>(); //The list of orders
    int earnings = 0; //The earnings of an order
    public GameObject moneyCounter; //The game object, which has the script "MoneyCounter"
    MoneyCounter mc; //In order to access elements of "MoneyCounter"
    public GameObject upgradeController; //The game object, which has the script "UpgradeManager"
    UpgradeManager um; //In order to access elements of "UpgradeManager"
    public float dailyEarnings = 0; //The earnings made for a whole day
    public GameObject soupOrder; //The sprite for the soup order
    public GameObject soup; //The sprite for the soup

    private void Start()
    {
        mc = moneyCounter.GetComponent<MoneyCounter>(); //The "MoneyCounter" script is accessed from the game object.
        um = upgradeController.GetComponent<UpgradeManager>(); //The "UpgradeManager" script is accessed from the game object.
        soupOrder.SetActive(false); //The sprite for the soup order is set to be false
        soup.SetActive(false); //The sprite for the soup is set to be false
    }

    //The method adds an order to the list of orders. It takes an order as a parameter.
    public void AddOrder(Order order)
    {
        soupOrder.SetActive(true); //The sprite for the soup order is set to be true
        soup.SetActive(false); //The sprite for the soup is set to be false
        orders.Add(order); //The order is added to the list of orders
    }

    //This method is used to remove an order and manage the elements surrounding it
    //This takes the order number (an integer) and the time remaining (a float) to get the specific order.
    //It was supposed to include the time remaining in the calculations of the earnings, but it was not implemented in time.
    public void RemoveOrder(int orderNumber, float timeRemaining)
    {
        //The specific block of code is tried (because it could throw an ArgumentOutOfRangeException)
        try
        {
            //The earnings are the sum of the price of the order and the amount of tips (from UpgradeManager)
            earnings = orders.ElementAt(orderNumber).GetPrice() + um.tUpgrade;
        }
        //It tries to catch any ArgumentOutOfRangeExceptions that might occur
        catch (ArgumentOutOfRangeException)
        {
            Debug.Log("No Orders!");
        }
        //The code below should have been executed in a finally block in order to execute it whether an exception is thrown or not.
        dailyEarnings += earnings; //The earnings are added to the daily earnings.
        orders.Remove(orders.ElementAt(orderNumber)); //The specific order is removed from the order list (based on orderNumber).
        soupOrder.SetActive(false); //The sprite for the soup order is set to be false
        soup.SetActive(true); //The sprite for the soup is set to be true
    }
}