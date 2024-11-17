using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CustomerClickRegister : MonoBehaviour
{
    public TextMeshProUGUI cashText; 
    public AudioClip clickSound; 
    private AudioSource audioSource; 
    private float soundDuration; 
    private const string CashKey = "PlayerCash"; 

    private void Start()
    {
        // Initialize the audio source
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        // Load the cash value from PlayerPrefs
        int cash = PlayerPrefs.GetInt(CashKey, 0);
        UpdateCashUI(cash);
    }

    private void Update()
    {
        // Check for mouse input
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray to detect the clicked object
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Customer"))
                {
                    HandleCustomerClick();
                }
            }
        }
    }

    public void HandleCustomerClick()
    {
        // Increment cash
        int cash = PlayerPrefs.GetInt(CashKey, 0);
        cash += 20;
        PlayerPrefs.SetInt(CashKey, cash);
        PlayerPrefs.Save(); // Save the updated cash value

        UpdateCashUI(cash);

        if (clickSound)
        {
            audioSource.clip = clickSound;
            soundDuration = clickSound.length;
            audioSource.Play();
        }

        Invoke(nameof(ResetScene), soundDuration);
    }

    private void UpdateCashUI(int cash)
    {
        if (cashText)
        {
            cashText.text = $"${cash}";
        }
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
