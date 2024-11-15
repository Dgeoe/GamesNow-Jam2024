using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public string[] menuItems; // List of menu items to choose from
    public Order currentOrder; // The customer's order

    private CustomerState customerState; // Reference to the customer's state

    private void Start()
    {
        customerState = GetComponent<CustomerState>();
    }

    public void PlaceOrder()
    {
        // Select a random menu item and quantity
        string menuItem = menuItems[Random.Range(0, menuItems.Length)];
        int quantity = Random.Range(1, 4); // Random quantity between 1 and 3

        // Create a new order
        currentOrder = new Order(menuItem, quantity);

        Debug.Log($"Customer ordered: {quantity}x {menuItem}");

        // Transition to idle roaming state
        if (customerState != null)
        {
            customerState.SetIdleState();
        }
    }
}

