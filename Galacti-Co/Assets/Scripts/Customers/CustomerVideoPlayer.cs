using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CustomerVideoPlayer : MonoBehaviour
{
    public VideoClip[] videoClips; 
    public VideoPlayer videoPlayer; 

    private CustomerSpawner customerSpawner; // Reference to the customer spawner

    private void Start()
    {
        // Ensure the arrays match
        if (videoClips.Length == 0)
        {
            Debug.LogError("No video clips assigned to the array!");
            return;
        }

        customerSpawner = GetComponent<CustomerSpawner>();
        if (customerSpawner == null)
        {
            Debug.LogError("CustomerSpawner script not found on this GameObject!");
        }
    }

    public void PlayVideoForCustomer(int prefabIndex)
    {
        if (prefabIndex < 0 || prefabIndex >= videoClips.Length)
        {
            Debug.LogError("Invalid prefab index for video clip!");
            return;
        }

        if (videoPlayer != null)
        {
            videoPlayer.clip = videoClips[prefabIndex]; 
            videoPlayer.isLooping = true;              // loop de loop
            videoPlayer.Play();                        
        }
        else
        {
            Debug.LogError("VideoPlayer is not assigned!");
        }
    }
}

