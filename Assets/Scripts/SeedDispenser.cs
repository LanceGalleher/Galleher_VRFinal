using UnityEngine;

// handles spawning logic of seed objects
// tries to ensure that only one seed object exists at a time, otherwise prevents spawning spam with implementation of a cooldown

public class SeedSpawner : MonoBehaviour
{
    public GameObject seedPrefab;
    public Transform spawnPoint;

    public float spawnRadius = 0.3f;
    public float spawnCooldown = 0.2f;

    public float seedLifetime = 100f;

    private GameObject currentSeed;
    private float lastSpawnTime;

    void Start()
    {
        SpawnSeed();
    }

    void Update()
    {
        if (currentSeed == null) return;

        if (Time.time - lastSpawnTime < spawnCooldown) return;

        float distance = Vector3.Distance(
            currentSeed.transform.position,
            spawnPoint.position
        );

        if (distance > spawnRadius)
        {
            SpawnSeed();
        }
    }

    void SpawnSeed()
    {
        currentSeed = Instantiate(
            seedPrefab,
            spawnPoint.position,
            spawnPoint.rotation
        );

        Destroy(currentSeed, seedLifetime);

        lastSpawnTime = Time.time;
    }
}
