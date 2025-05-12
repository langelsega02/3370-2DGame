using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTest1 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = GetRandomScreenPosition();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    Vector2 GetRandomScreenPosition()
    {
        float x = Random.Range(0f, 1f);
        float y = Random.Range(0f, 1f);
        Vector3 screenPoint = new Vector3(x * Screen.width, y * Screen.height, mainCamera.nearClipPlane);
        Vector3 worldPoint = mainCamera.ScreenToWorldPoint(screenPoint);
        return new Vector2(worldPoint.x, worldPoint.y);
    }
}
