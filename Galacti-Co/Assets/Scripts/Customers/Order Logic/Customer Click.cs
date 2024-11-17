using UnityEngine;

public class CustomerClick : MonoBehaviour
{
    private CustomerClickRegister gameManager; // Reference to the main game script

    private void Start()
    {
        // Find the CustomerClickHandler script in the scene
        gameManager = Object.FindFirstObjectByType<CustomerClickRegister>();

        if (gameManager == null)
        {
            Debug.LogError("CustomerClickHandler not found in the scene!");
        }
    }

    private void OnMouseDown()
    {
        gameManager.HandleCustomerClick();
    }
}

