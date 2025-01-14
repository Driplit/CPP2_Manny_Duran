using UnityEngine;

public class RandomPositionOnStart : MonoBehaviour
{
    // Define the range for the random position
    public Vector3 minRange = new Vector3(-100, 0, -100);
    public Vector3 maxRange = new Vector3(100, 0, 100);

    void Start()
    {
        MoveToRandomPosition();
    }

    private void MoveToRandomPosition()
    {
        // Generate random values for x, y, and z within the specified range
        float randomX = Random.Range(minRange.x, maxRange.x);
        float randomY = Random.Range(minRange.y, maxRange.y);
        float randomZ = Random.Range(minRange.z, maxRange.z);

        // Set the object's position to the random location
        transform.position = new Vector3(randomX, randomY, randomZ);

        // Log the new position for debugging
        Debug.Log("Moved to random position: " + transform.position);
    }
}