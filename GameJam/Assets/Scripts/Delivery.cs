using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    public GameObject orderManager; //The game object that has the script "OrderManager"
    OrderManager om; //In order to access elements from "OrderManager"
    public GameObject player; //The player, which has the script "FoodManager"
    FoodManager fm; //In order to access elements from "FoodManager"
    public GameObject customerController; //The game object that has the script "CustomerManager"
    CustomerManager cm; //In order to access elements from "CustomerManager"
    
    private void Start()
    {
        om = orderManager.GetComponent<OrderManager>(); //The script "OrderManager" is accessed from the game object.
        fm = player.GetComponent<FoodManager>(); //The script "FoodManager" is accessed from the game object.
        cm = customerController.GetComponent<CustomerManager>(); //The script "CustomerManager" is accessed from the game object.

    }

    //While something is staying within the collider...
    public void OnTriggerStay2D(Collider2D other)
    {
        //If the spacebar is pressed down and the boolean hasSoup (from FoodManager) is true...
        if (Input.GetKeyDown(KeyCode.Space) && fm.hasSoup)
        {
            Debug.Log("Delivery");
            cm.timerIsRunning = false; //The timerIsRunning boolean (from CustomerManager) is set to false to turn off the timer
            fm.hasSoup = false; //The boolean hasSoup (from FoodManager) is set to false
            om.RemoveOrder(0, cm.timeRemaining); //Calls RemoveOrder (from OrderManagement) to remove the order
            //It gives the integer 0 and the float timeRemaining (from CustomerManager) as parameters.
        }
    }
}
