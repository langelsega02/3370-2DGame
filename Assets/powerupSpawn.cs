using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public float spawnRate = 5f;
    public float minY = 0f;
    public float maxY = 1.5f;
    private float timer = 0f;
    public GameObject powerPrefab;
    //bool spawnFlag;
    void Start()
    {
        //spawnFlag = false;
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
            float y = Random.Range(minY, maxY);
            Instantiate(powerPrefab, new Vector3(transform.position.x, y, 0), Quaternion.identity);
            timer = 0;
        }
    }
}
