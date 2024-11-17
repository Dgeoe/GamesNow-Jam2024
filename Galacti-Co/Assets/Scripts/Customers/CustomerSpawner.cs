using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject[] customerPrefabs; 
    public Transform spawnPoint;         
    public float spawnInterval = 5f;     

    private Queue<Transform> queuePositions = new Queue<Transform>(); 
    public List<Transform> queuePoints;     
    public CustomerSoundPlayer soundPlayer; 

    private void Start()
    {
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

                // Play the corresponding sound
                if (soundPlayer != null)
                {
                    soundPlayer.PlaySoundForCustomer(randomIndex);
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
