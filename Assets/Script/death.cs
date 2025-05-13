using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class death : MonoBehaviour
{
    public float fallThreshold = -5f;
    public float leftThreshold = -10f;
    public GameObject losePanel;

    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        if (scoreManager != null && scoreManager.GetTimeLeft() <= 0f)
        {
            Die("Time ran out");
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeathZone"))
        {
            Die("Entered death zone");
        }
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
