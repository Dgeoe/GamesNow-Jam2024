using UnityEngine;

public class CustomerState : MonoBehaviour
{
    public enum State
    {
        InQueue,
        Ordering,
        IdleRoaming,
        PickingUpOrder,
        Leaving
    }

    public State currentState;

    private CustomerMovement customerMovement; // Reference to movement script

    private void Start()
    {
        customerMovement = GetComponent<CustomerMovement>();
        currentState = State.InQueue;
    }

    public void SetIdleState()
    {
        currentState = State.IdleRoaming;

        // Assign a random roaming point (to be implemented)
        Debug.Log("Customer is now roaming.");
    }
}
