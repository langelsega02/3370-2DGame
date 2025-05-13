using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    public float speed = 3f;

    public GameObject coinPrefab;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        // Optional: Add death effect here
        // Instantiate(deathEffect, transform.position, Quaternion.identity);

        Instantiate(coinPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        Destroy(gameObject);
    }

    void Update()
    {
        // Horizontal motion to the left
        float moveX = -speed * Time.deltaTime;

        // Vertical floating motion using sine wave
        float floatY = Mathf.Sin(Time.time * 2f) * 0.5f; // Adjust frequency & amplitude

        // Apply combined motion
        transform.position += new Vector3(moveX, floatY * Time.deltaTime, 0);

        // Destroy if off-screen
        if (transform.position.x < -4.1f)
        {
            Destroy(gameObject);
        }
    }
}
