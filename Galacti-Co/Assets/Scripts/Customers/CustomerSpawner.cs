using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab; // Reference to the customer prefab (will make array later)
    public Transform spawnPoint;      // Where customers spawn
    public float spawnInterval = 5f;  // Time between customers spawning outside of resteraunt (add cap later)

    private Queue<Transform> queuePositions = new Queue<Transform>(); // Queue positions in the restaurant

    public List<Transform> queuePoints; // Set three queue points 

    private void Start()
    {
        // Add queue points to the queue system
        foreach (Transform point in queuePoints)
        {
            queuePositions.Enqueue(point);
        }

        StartCoroutine(SpawnCustomer());
    }

    private IEnumerator SpawnCustomer()
    {
        while (true)
        {
            if (queuePositions.Count > 0) // Only spawn if there's space in the queue
            {
                GameObject newCustomer = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);

                // Assign the next available queue position to the customer
                CustomerMovement customerMovement = newCustomer.GetComponent<CustomerMovement>();
                if (customerMovement != null)
                {
                    customerMovement.SetQueuePosition(queuePositions.Dequeue());
                }
            }

            yield return new WaitForSeconds(spawnInterval); 
        }
    }

    public void FreeQueuePosition(Transform position)
    {
        queuePositions.Enqueue(position); // Add position to the queue again
    }
}
