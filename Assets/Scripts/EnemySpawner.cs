using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    public float radius = 1.0f;
    public float minSpawnTime = 1.0f;
    public float maxSpawnTime = 10.0f;
    public bool constantSpawn = false;
    public Transform spawnPosition;
    Vector3 randomLocation;

    void Start()
    {
        Invoke("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
    }

    void SpawnEnemy()
    {
        randomLocation = Random.insideUnitSphere * 5; //5 is radius
        randomLocation.y = 0.0f;

        float spawnRadius = radius;
        int spawnObjectIndex = Random.Range(0, enemy.Length);

        Instantiate(enemy[spawnObjectIndex], spawnPosition.position + randomLocation, enemy[spawnObjectIndex].transform.rotation);

        if (constantSpawn == true)
        {
            Invoke("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
        }
    }
}