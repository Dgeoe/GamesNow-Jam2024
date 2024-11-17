using UnityEngine;

public class Conveyer : MonoBehaviour
{
    [Tooltip("Time in seconds before triggering the animation")]
    public float delayTime = 5f;

    private Animator animator;
    private bool isDelayTriggered = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator is not here bucko.");
            return;
        }

        StartCoroutine(TriggerAnimationAfterDelay());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Flip the current value of the "In" parameter
            bool currentState = animator.GetBool("In");
            animator.SetBool("In", !currentState);

            if (!isDelayTriggered)
            {
                StopAllCoroutines();
                isDelayTriggered = true; // Prevents triggering again from delay if handled prior manually 
            }
        }
    }

    private System.Collections.IEnumerator TriggerAnimationAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);

        animator.SetBool("In", true);
        isDelayTriggered = true; 
    }
}
