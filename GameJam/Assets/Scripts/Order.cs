using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    int price; //The price of the order
    string customerName; //The name of the customer

    //Constructor for the order
    public Order(int price, string customerName)
    {
        this.price = price; //Sets the price of the order to the parameter.
        this.customerName = customerName; //Sets the customer name of the order to the parameter.
    }

    //Returns the price
    public int GetPrice()
    {
        return price;
    }

    //Returns the customer name
    public string GetCustomerName()
    {
        return customerName;
    }
}