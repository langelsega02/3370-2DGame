using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject[] buildingPrefabs; //array
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
        GameObject selectedBuilding = buildingPrefabs[randomIndex];

       float y = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(transform.position.x, y, 0);

        Instantiate(selectedBuilding, spawnPos, Quaternion.identity);
    }
}
