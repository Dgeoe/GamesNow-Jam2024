using UnityEngine;

public class RotationBasedEnabler : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("The object whose Y rotation is being monitored.")]
    public Transform targetObject;

    [Tooltip("The Y rotation value to trigger the enable condition.")]
    public float targetYRotation;

    [Tooltip("The allowable difference between the target Y rotation and the actual rotation.")]
    public float rotationThreshold = 1.0f;

    [Header("Object to Enable/Disable")]
    [Tooltip("The object that will be enabled or disabled.")]
    public GameObject objectToControl;

    void Update()
    {
        if (targetObject == null || objectToControl == null)
        {
            Debug.LogWarning("Target Object or Object to Control is not set.");
            return;
        }

        // Get the Y rotation of the target object
        float currentYRotation = targetObject.eulerAngles.y;

        // Check if the current rotation is within the threshold of the target rotation
        if (Mathf.Abs(Mathf.DeltaAngle(currentYRotation, targetYRotation)) <= rotationThreshold)
        {
            if (!objectToControl.activeSelf)
                objectToControl.SetActive(true);
        }
        else
        {
            if (objectToControl.activeSelf)
                objectToControl.SetActive(false);
        }
    }
}

