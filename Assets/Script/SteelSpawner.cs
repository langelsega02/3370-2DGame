using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelSpawner : MonoBehaviour
{
    public float spawnRate = 5f; // faster spawn for city look
    private float timer = 0f;
    public GameObject steelPrefab;
    public GameObject coinPrefab;
    public float minY = 0f;
    public float maxY = 2f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnBuilding();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnBuilding();
            timer = 0;
        }
    }

    void SpawnBuilding()
    {
        int randomLength = Random.Range(3, 6);
        int randomSpawn = Random.Range(0, 4);

        float y = Random.Range(minY, maxY);
        for (int i = 0; i < randomLength; i++ )
        {
            Instantiate(steelPrefab, new Vector3(transform.position.x+i, y, 0), Quaternion.identity);
        }
        if (randomSpawn <= 2)
        {
            Instantiate(coinPrefab, new Vector3(transform.position.x + (randomLength / 2), y+0.7f, 0), Quaternion.identity);
        }

    }
}
