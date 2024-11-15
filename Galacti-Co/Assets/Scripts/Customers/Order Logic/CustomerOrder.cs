using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public string[] menuItems; // List of main menu items to choose from
    public string[] Toppings; //Toppings!!!!!!!!!!!
    public string[] sideItems; // List of side menu items to choose from
    public string[] FuelTypes; // List of fuel types to choose from
    public string[] FuelQuantity; // How much fuel will be ordered 
    public Order currentOrder; // The customer's order

    private CustomerState customerState; 

    private void Start()
    {
        customerState = GetComponent<CustomerState>();
    }

    public void PlaceOrder()
{
    // Select a random menu item and quantity
    string menuItem = menuItems[Random.Range(0, menuItems.Length)];
    string topping = Toppings[Random.Range(0, menuItems.Length)];
    string sideItem = sideItems[Random.Range(0, sideItems.Length)];
    string FuelType = FuelTypes[Random.Range(0, FuelTypes.Length)];
    string FuelQuant = FuelQuantity[Random.Range(0, FuelQuantity.Length)];

    currentOrder = new Order(menuItem, sideItem, FuelType, FuelQuant, topping);

    Debug.Log($"Customer ordered:{menuItem} with {topping} and {sideItem} and need ${FuelQuant} of {FuelType}");

    // Transition to idle roaming state
    CustomerState customerState = GetComponent<CustomerState>();
    if (customerState != null)
    {
        customerState.SetIdleState();
    }
}

}

