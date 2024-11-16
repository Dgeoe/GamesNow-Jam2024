using UnityEngine;

public class Conveyer : MonoBehaviour
{
    [Tooltip("Time in seconds before triggering the animation")]
    public float delayTime = 5f;

    private Animator animator;
    private bool isDelayTriggered = false;

    void Start()
    {
        // Get the Animator component attached to the same object
        animator = GetComponent<Animator>();

        // Ensure the Animator is found
        if (animator == null)
        {
            Debug.LogError("Animator component not found on this GameObject.");
            return;
        }

        // Start the delayed animation trigger
        StartCoroutine(TriggerAnimationAfterDelay());
    }

    void Update()
    {
        // Toggle the "In" parameter when the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Flip the current value of the "In" parameter
            bool currentState = animator.GetBool("In");
            animator.SetBool("In", !currentState);

            // If toggled manually, cancel the delay trigger if not already set
            if (!isDelayTriggered)
            {
                StopAllCoroutines();
                isDelayTriggered = true; // Prevent re-triggering from delay
            }
        }
    }

    private System.Collections.IEnumerator TriggerAnimationAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayTime);

        // Set the "In" parameter to true
        animator.SetBool("In", true);
        isDelayTriggered = true; // Mark the delay as triggered
    }
}
