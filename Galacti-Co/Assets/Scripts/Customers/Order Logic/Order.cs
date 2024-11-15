using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Order
{
    public string menuItem; 
    public string topping;
    public string sideItem;
    public string FuelType;
    public string FuelQuant;

    public Order(string mitem, string titem, string fqty, string sitem, string fitem)   
    {
        menuItem = mitem;
        topping = titem;
        sideItem = sitem;
        FuelType = fitem;
        FuelQuant = fqty;
    }
}
