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

    private CustomerMovement customerMovement;
    private Transform[] idlePositions; // Array of idle positions
    private Animator customerAnimator; // Reference to the customer's Animator

    private void Start()
    {
        customerMovement = GetComponent<CustomerMovement>();
        customerAnimator = GetComponent<Animator>(); // Get the Animator component
        currentState = State.InQueue;

        // Find the "Idle Positions" object and populate the idlePositions array
        PopulateIdlePositions();
    }

    private void PopulateIdlePositions()
    {
        GameObject idlePositionsObject = GameObject.Find("Idle Positions");
        if (idlePositionsObject != null)
        {
            // Get all child transforms of "Idle Positions"
            int childCount = idlePositionsObject.transform.childCount;
            idlePositions = new Transform[childCount];
            for (int i = 0; i < childCount; i++)
            {
                idlePositions[i] = idlePositionsObject.transform.GetChild(i);
            }
            Debug.Log($"{childCount} idle positions loaded.");
        }
        else
        {
            Debug.LogError("Idle Positions object not found in the scene!");
        }
    }

    public void SetIdleState()
    {
        currentState = State.IdleRoaming;

        if (idlePositions == null || idlePositions.Length == 0)
        {
            Debug.LogError("Idle positions not set or empty.");
            return;
        }

        // Select a random idle position
        Transform targetPosition = idlePositions[Random.Range(0, idlePositions.Length)];

        // Move the customer to the idle position
        if (customerMovement != null)
        {
            customerMovement.MoveToPosition(targetPosition.position, OnReachedIdlePosition);
        }

        Debug.Log("Customer is moving to an idle position.");
    }

    private void OnReachedIdlePosition()
    {
        Debug.Log("Customer is now idle and waiting.");

        // Set the "Speaking" parameter to true on the Animator
        if (customerAnimator != null)
        {
            customerAnimator.SetBool("Speaking", true);
        }
        else
        {
            Debug.LogError("Animator component not found on the customer.");
        }
    }

    // Reset the "Speaking" parameter when the customer stops idling
    public void StopSpeaking()
    {
        if (customerAnimator != null)
        {
            customerAnimator.SetBool("Speaking", false);
        }
    }
}

