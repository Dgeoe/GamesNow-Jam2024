using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Order
{
    public string menuItem; // The item the customer orders
    public int quantity;    // How many they order

    public Order(string item, int qty)
    {
        menuItem = item;
        quantity = qty;
    }
}
