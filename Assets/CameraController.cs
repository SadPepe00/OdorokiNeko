using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private Transform target;

    void Start()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag("Player");
        target = targetObject.transform;

    }

    void FixedUpdate()
    {
            // Calculate the desired position for the camera
            Vector3 desiredPosition = target.position + offset;
            // Set the camera's Z-coordinate to a fixed value
            desiredPosition.z = transform.position.z;
            // Smoothly interpolate between the current camera position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Set the camera position to the smoothed position
            transform.position = smoothedPosition;
    }
}

