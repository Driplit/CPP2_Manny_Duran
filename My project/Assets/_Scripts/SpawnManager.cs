using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemsToSpawn; // Array of items to spawn
    public Transform[] spawnPoints;  // Array of spawn point locations
    public int maxSpawns = 1;       // Number of items to spawn

    void Start()
    {
        // Check for configuration errors
        if (itemsToSpawn == null || itemsToSpawn.Length == 0)
        {
            Debug.LogError("No items assigned in itemsToSpawn array!");
            return;
        }

        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned!");
            return;
        }

        // Spawn items at random spawn points
        SpawnItems();
    }

    void SpawnItems()
    {
        int itemsSpawned = 0;

        while (itemsSpawned < maxSpawns)
        {
            // Randomly select an item to spawn
            GameObject randomItem = itemsToSpawn[Random.Range(0, itemsToSpawn.Length)];

            // Randomly select a spawn point
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Spawn the item at the selected spawn point
            Instantiate(randomItem, randomSpawnPoint.position, randomSpawnPoint.rotation);

            itemsSpawned++; // Increment the counter
        }
    }
}