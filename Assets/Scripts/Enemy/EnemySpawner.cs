using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject ballConext;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform rightSpawnPoint;
    [SerializeField]
    private Transform leftSpawnPoint;
    [SerializeField]
    private int maxEnemiesInScene;
    [SerializeField]
    private float minimumTimeToSpawn;

    private int totalEnemies;
    private float spawnTimer = 0;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer > minimumTimeToSpawn && totalEnemies < maxEnemiesInScene)
        {
            Spawn();
            spawnTimer = 0;
            totalEnemies++;
        }
    }

    public void Spawn()
    {
        var point = Random.Range(0, 2) == 0 ? rightSpawnPoint : leftSpawnPoint;
        var enemy = Instantiate(enemyPrefab, point.position, Quaternion.identity);

        enemy.GetComponent<HittedByBallDetectionBehaviour>().SetBallContext(ballConext);
    }

    public void OnEnemyDistroied()
    {
        totalEnemies--;
    }
}
