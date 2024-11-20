using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject objectToSpawn; // Assign the object to spawn
    public float minSpawnInterval = 1f; // Minimum spawn interval in seconds
    public float maxSpawnInterval = 3f; // Maximum spawn interval in seconds
    public Transform spawnPoint;    // Optional: Set spawn location (default to spawner position)
    public int maxObjects = 10;     // Maximum number of spawned objects allowed in the scene

    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Start()
    {
        // Start the first spawn with a randomized interval
        Invoke(nameof(RandomizeSpawnInterval), Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    private void RandomizeSpawnInterval()
    {
        // Spawn the object and randomize the next interval
        SpawnObject();

        // Call this method again with a new randomized interval
        Invoke(nameof(RandomizeSpawnInterval), Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    private void SpawnObject()
    {
        // Check if the maximum limit is reached
        if (spawnedObjects.Count >= maxObjects)
            return;

        // Spawn the object
        Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : transform.position;
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // Add the spawned object to the list
        spawnedObjects.Add(spawnedObject);

        // Remove the object from the list when it's destroyed
        spawnedObject.GetComponent<DestroyOnTouch>().OnDestroyed += () => spawnedObjects.Remove(spawnedObject);
    }
}
