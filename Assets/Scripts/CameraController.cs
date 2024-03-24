using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private Transform target;

    void Start()
    {
    }

    void FixedUpdate()
    {
        FindPlayer();
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            desiredPosition.z = transform.position.z;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
    private void FindPlayer()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag("Player");
        if(targetObject!=null)
            target = targetObject.transform;
    }
}

