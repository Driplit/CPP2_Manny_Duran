using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // The target the camera follows
    public float distance = 5.0f; // Distance from the target
    public float height = 2.0f; // Height offset
    public float rotationSpeed = 5.0f; // Speed of rotation

    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private const float Y_ANGLE_MIN = -20.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    void LateUpdate()
    {
        if (target == null)
            return;

        // Get mouse input
        currentX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

        // Calculate direction and position
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = target.position + rotation * direction;
        transform.LookAt(target.position + Vector3.up * height);
    }
}