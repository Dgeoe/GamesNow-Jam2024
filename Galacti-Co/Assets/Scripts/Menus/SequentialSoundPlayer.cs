using UnityEngine;

public class SequentialSoundPlayer : MonoBehaviour
{
    [Header("Sound Effects")]
    public AudioClip firstSoundEffect; 
    public AudioClip secondSoundEffect; 

    [Header("Delays")]
    public float delayBetweenFirstSounds = 1f; 
    public float delayBeforeSecondSound = 1f; 

    [Header("Audio Source")]
    public AudioSource audioSource; 

    private void Start()
    {
        StartCoroutine(PlaySoundSequence());
    }

    private System.Collections.IEnumerator PlaySoundSequence()
    {
        // Play the first sound effect 4 times with a delay
        for (int i = 0; i < 4; i++)
        {
            if (firstSoundEffect != null && audioSource != null)
            {
                audioSource.PlayOneShot(firstSoundEffect);
            }
            yield return new WaitForSeconds(delayBetweenFirstSounds);
        }

        // Wait for an additional delay before playing the second sound effect
        yield return new WaitForSeconds(delayBeforeSecondSound);

        // Play the second sound effect
        if (secondSoundEffect != null && audioSource != null)
        {
            audioSource.PlayOneShot(secondSoundEffect);
        }
    }
}
