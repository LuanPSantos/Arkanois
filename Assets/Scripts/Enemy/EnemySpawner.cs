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


    void Start()
    {
        Spawn();
    }

    void Update()
    {
        
    }

    public void Spawn()
    {
        var point = Random.Range(0, 2) == 0 ? rightSpawnPoint : leftSpawnPoint;
        var enemy = Instantiate(enemyPrefab, point.position, Quaternion.identity);

        enemy.GetComponent<HittedByBallDetectionBehaviour>().SetBallContext(ballConext);
    }
}
