using UnityEngine;
public class MoveStates : MonoBehaviour

{
    public float rotationAngle = 90f; 
    public float rotationSpeed = 5f; 
    private Quaternion targetRotation; 

    void Start()

    {
        targetRotation = transform.rotation;
    }

    void Update()

    {

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            targetRotation *= Quaternion.Euler(0, rotationAngle, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            targetRotation *= Quaternion.Euler(0, -rotationAngle, 0);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

    }

}