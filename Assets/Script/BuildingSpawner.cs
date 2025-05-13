using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject[] buildingPrefabs; //array
    public GameObject coinPrefab;
    public float spawnRate = 1.4f; // faster spawn for city look
    private float timer = 0f;

    public float minY = 0f;
    public float maxY = 3f;
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
        int randomIndex = Random.Range(0, buildingPrefabs.Length);
        int randomSpawn1 = Random.Range(0, 10);
        int randomSpawn2 = Random.Range(0, 5);

        GameObject selectedBuilding = buildingPrefabs[randomIndex];

       float y = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(transform.position.x, y , 0);
        if (randomSpawn2 != 0)
        {
            Instantiate(selectedBuilding, spawnPos, Quaternion.identity);
            if (randomSpawn1 == 9)
            {
                Instantiate(coinPrefab, new Vector3(transform.position.x, y + 2f, 0), Quaternion.identity);
            }
        }
        else
        {
            //do nothing, this creates a gap
        }
    }
}
