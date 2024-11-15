using UnityEngine;

public class FaceMe : MonoBehaviour
{
    private Transform cameraTransform;
    private float previousCameraYRotation;

    void Start()
    {
        GameObject cameraselect = GameObject.Find("Main Camera");
        if (cameraselect != null)
        {
            cameraTransform = cameraselect.transform;
            previousCameraYRotation = cameraTransform.eulerAngles.y;
        }
        else
        {
            Debug.LogError("Main Camera not found in the scene.");
        }
    }

    void Update()
    {
        if (cameraTransform == null)
            return;

        float currentCameraYRotation = cameraTransform.eulerAngles.y;
        float rotationDifference = Mathf.DeltaAngle(previousCameraYRotation, currentCameraYRotation);

        // Rotate the sprite when camera goes +or- 90 degrees to mimic them watching you intensly 
        if (Mathf.Abs(rotationDifference) > 85f && Mathf.Abs(rotationDifference) < 95f)
        {
            Debug.Log("Camera moved.");
            transform.Rotate(0, -rotationDifference, 0);
            previousCameraYRotation = currentCameraYRotation;
        }

        // Ensure the sprite always faces the camera
        Vector3 lookDirection = cameraTransform.position - transform.position;
        lookDirection.y = 0; // Keep the sprite upright
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}
