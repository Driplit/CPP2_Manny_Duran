using UnityEngine;

public class _ConeRayCast : MonoBehaviour
{
    public float coneAngle = 45f;        // Angle of the cone in degrees
    public float rayDistance = 10f;     // Maximum distance of the rays
    public int raysPerCircle = 8;       // Number of rays in each circular layer
    public int layers = 3;              // Number of circular layers in the cone
    public LayerMask layerMask;         // Layers the rays will interact with

    void Update()
    {
        // Center direction of the cone
        Vector3 forward = transform.forward;

        // Loop through each layer of the cone
        for (int layer = 0; layer < layers; layer++)
        {
            float layerAngle = (coneAngle / layers) * (layer + 1); // Angle for the current layer
            float layerRadius = Mathf.Tan(layerAngle * Mathf.Deg2Rad); // Radius of the circular layer

            // Loop through each ray in the layer
            for (int i = 0; i < raysPerCircle; i++)
            {
                float angle = (360f / raysPerCircle) * i; // Angle for this ray in the circle

                // Calculate ray direction
                Vector3 offset = Quaternion.Euler(0, angle, 0) * Vector3.right * layerRadius;
                Vector3 rayDirection = (forward + offset).normalized;

                // Perform raycast
                if (Physics.Raycast(transform.position, rayDirection, out RaycastHit hit, rayDistance, layerMask))
                {
                    // Log the object hit
                    Debug.Log("Hit: " + hit.collider.gameObject.name);
                }

                // Draw the debug ray
                Debug.DrawRay(transform.position, rayDirection * rayDistance, Color.red);
            }
        }
    }
}
