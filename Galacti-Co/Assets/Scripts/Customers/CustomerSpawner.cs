using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject[] customerPrefabs; // Array of customer prefabs
    public Transform spawnPoint;         // Where customers spawn
    public float spawnInterval = 5f;     // Time between customer spawns

    private Queue<Transform> queuePositions = new Queue<Transform>(); // Queue positions in the restaurant

    public List<Transform> queuePoints; // Set queue points in the inspector

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
            if (queuePositions.Count > 0 && customerPrefabs.Length > 0) // Only spawn if there's space and prefabs are available
            {
                // Pick a random prefab
                int randomIndex = Random.Range(0, customerPrefabs.Length);
                GameObject randomPrefab = customerPrefabs[randomIndex];

                // Spawn the customer
                GameObject newCustomer = Instantiate(randomPrefab, spawnPoint.position, Quaternion.identity);

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
        queuePositions.Enqueue(position); // Add position back to the queue
    }
}
