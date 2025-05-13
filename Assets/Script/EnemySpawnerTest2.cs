using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTest2 : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float spawnInterval = 3f;

    [SerializeField]
    private float minY = -0.5f;
    [SerializeField]
    private float maxY = 2f;

    [SerializeField]
    private float spawnX = 10f; // Just off-screen to the right

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(spawnX, Random.Range(minY, maxY), 0);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
