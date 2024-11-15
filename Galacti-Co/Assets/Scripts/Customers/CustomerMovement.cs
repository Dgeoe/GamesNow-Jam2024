using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the customer moves
    private Transform queuePosition; // The position this customer is moving to

    private bool isMoving = false;

    private void Update()
    {
        if (isMoving && queuePosition != null)
        {
            // Smoothly move towards the assigned queue position
            transform.position = Vector3.MoveTowards(transform.position, queuePosition.position, moveSpeed * Time.deltaTime);

            // Stop moving when reaching the position
            if (Vector3.Distance(transform.position, queuePosition.position) < 0.1f)
            {
                isMoving = false;
                OnReachedQueuePosition();
            }
        }
    }

    public void SetQueuePosition(Transform position)
    {
        queuePosition = position;
        isMoving = true;
    }

    private void OnReachedQueuePosition()
{
    if (queuePosition.CompareTag("Counter")) 
    {
        CustomerOrder customerOrder = GetComponent<CustomerOrder>();
        if (customerOrder != null)
        {
            customerOrder.PlaceOrder();
        }
    }
    else
    {
        Debug.Log("Customer reached queue position.");
    }
}

}

