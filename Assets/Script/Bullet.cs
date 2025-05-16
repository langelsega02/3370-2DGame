using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public int damage = 50;
    public Rigidbody2D rb;
    
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Ignore Coin, PowerUp, and Obstacle (like steel beam)
        if (hitInfo.CompareTag("Coin") || hitInfo.CompareTag("PowerUp") || hitInfo.CompareTag("Obstacle"))
        {
            return;
        }

        Debug.Log(hitInfo.name);

        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
