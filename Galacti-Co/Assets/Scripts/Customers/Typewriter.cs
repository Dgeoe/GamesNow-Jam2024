using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text textMeshPro;        
    public float typeSpeed = 0.05f;     //(typewriter speed)
    public float disableAfter = 5f;    
    public float startDelay = 0f;       
    public AudioClip typeSoundClip;     
    public float soundVolume = 0.5f;    // Volume for the typewriter sound effect

    private string fullText;            // Store the full text to display
    private bool isTyping = false;      // Tracks if the typing effect is running
    private AudioSource audioSource;    

    void Start()
    {
        fullText = textMeshPro.text;
        textMeshPro.text = "";  
        if (typeSoundClip != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = typeSoundClip;
            audioSource.volume = soundVolume;
        }
        StartCoroutine(StartTypewriterEffect());
    }

    IEnumerator StartTypewriterEffect()
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(TypeText());
    }
    IEnumerator TypeText()
    {
        isTyping = true;

        foreach (char letter in fullText.ToCharArray())
        {
            textMeshPro.text += letter;

            if (audioSource != null)
            {
                audioSource.PlayOneShot(typeSoundClip);
            }

            yield return new WaitForSeconds(typeSpeed);
        }

        isTyping = false;

        yield return new WaitForSeconds(disableAfter);
        textMeshPro.gameObject.SetActive(false);
    }
}
