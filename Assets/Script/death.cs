using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class death : MonoBehaviour
{
    public float fallThreshold = -5f;
    public GameObject losePanel;

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            Die("Fell off screen");
        }
    }

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
            Die("Hit enemy");
        }
        //if we have time maybe we could add particles or something
    }

    void Die(string reason)
    {
        Debug.Log("Player died: " + reason);
        if (losePanel != null)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        Destroy(this.gameObject);
    }
}
