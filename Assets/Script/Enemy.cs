using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    public float speed = 3f;

    //public GameObject deathEffect;
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
        //we can also add a death effect here with Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime); //scrolling around the screen

        if (transform.position.x < -4.1f)
        {
            Destroy(gameObject);
        }
    }
}
