using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CustomerSoundPlayer : MonoBehaviour
{
    public AudioClip[] soundEffects;     
    public float[] delays;               
    public float[] durations;            
    public AudioSource audioSource;      
    public Vector2 pitchRange = new Vector2(0.9f, 1.1f); // Random pitch range (min, max)

    private CustomerSpawner customerSpawner; // Reference to the customer spawner script so it can assign the correct voices

    private void Start()
    {
        
        if (soundEffects.Length != delays.Length || soundEffects.Length != durations.Length)
        {
            Debug.LogError("SoundEffects, Delays, and Durations arrays must have the same length!");
            return;
        }

        customerSpawner = GetComponent<CustomerSpawner>();
        if (customerSpawner == null)
        {
            Debug.LogError("CustomerSpawner script not found on this GameObject!");
        }
    }

    public void PlaySoundForCustomer(int prefabIndex)
    {
        if (prefabIndex < 0 || prefabIndex >= soundEffects.Length)
        {
            Debug.LogError("Invalid prefab index for sound effect!");
            return;
        }

        StartCoroutine(PlayLoopingSoundWithDelay(prefabIndex));
    }

    private IEnumerator PlayLoopingSoundWithDelay(int index)
    {
        yield return new WaitForSeconds(delays[index]);

        if (audioSource != null)
        {
            audioSource.pitch = Random.Range(pitchRange.x, pitchRange.y);

            audioSource.clip = soundEffects[index];
            audioSource.loop = true; 
            audioSource.Play();

            yield return new WaitForSeconds(durations[index]);

            audioSource.loop = false;
            audioSource.Stop();
        }
        else
        {
            Debug.LogError("AudioSource is not assigned!");
        }
    }
}
