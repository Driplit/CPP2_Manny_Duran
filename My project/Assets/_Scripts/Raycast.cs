using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float lookDistance = 10f; // How far the player can "see"
    public LayerMask layerMask; // Assign layers to filter objects

    void Update()
    {
        CheckLookingAtObject();
    }

    void CheckLookingAtObject()
    {
        Vector3 direction = transform.forward; // Adjust if your forward direction is different
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * lookDistance, Color.red); // Debugging line

        if (Physics.Raycast(ray, out hit, lookDistance, layerMask))
        {
            Debug.Log("Looking at: " + hit.collider.gameObject.name);
        }
    }
}