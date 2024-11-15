using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;

public class CustomerMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the customer moves
    private Transform queuePosition; // The position this customer is moving to
    private Vector3 target;

    private bool isMoving = false;

    private void Update()
    {
        if (isMoving && queuePosition != null)
        {
            // Smoothly move towards the next available queue position
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
    public void MoveToPosition(Vector3 targetPosition, System.Action onComplete)
    {
    target = targetPosition;
    isMoving = true;

    // Assign the callback to be called after reaching the position
    StartCoroutine(MoveToTarget(onComplete));
    }

    private IEnumerator MoveToTarget(System.Action onComplete)
    {
        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Stop moving
        isMoving = false;

        // Trigger the callback
        onComplete?.Invoke();
    }

}

