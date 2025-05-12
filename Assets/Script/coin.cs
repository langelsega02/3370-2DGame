using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3f; //speed of the scrolling game
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime); //scrolling around the screen

        if (transform.position.x < -4.1f)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            /*weapon player = collision.transform.GetComponent<weapon>();
            if (player != null)
            {
                player.TripleShotActive(); this activates the tripleshot function for the weapon
                so probably we can do the score change here.
            }
            */

            Destroy(gameObject);

        }
    }
}
