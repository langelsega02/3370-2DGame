using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class weapon : MonoBehaviour
{
    public AudioClip shootClip;
    private AudioSource audioSource;

    public Transform firepoint1;
    public Transform firepoint2;
    public GameObject bulletPrefab;
    public bool tripleShotActive = false;

    public float tripleShotRemainingTime = 0f;
    public float tripleShotDuration = 10f;

    public TextMeshProUGUI tripleShotTimerText;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (tripleShotActive)
            {
                TripleShot();
            }
            else
            {
                if (shootClip != null && audioSource != null)
                {
                    audioSource.PlayOneShot(shootClip);
                }
                Shoot();
            }
        }

        // Countdown triple shot time
        if (tripleShotActive)
        {
            tripleShotRemainingTime -= Time.deltaTime;
            
            if (tripleShotRemainingTime <= 0f)
            {
                tripleShotActive = false;
                tripleShotRemainingTime = 0f;
            }
            if (tripleShotTimerText != null)
            {
                tripleShotTimerText.text = $"Triple Shot: {tripleShotRemainingTime:F1}s";
            }
        }
        else
        {
            if (tripleShotTimerText != null)
            {
                tripleShotTimerText.text = "";
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint1.position, firepoint1.rotation);
        Instantiate(bulletPrefab, firepoint2.position, firepoint2.rotation);
    }

    void TripleShot()
    {
        if (shootClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootClip);
        }

        Instantiate(bulletPrefab, firepoint1.position + new Vector3(0f, -0.2f), Quaternion.Euler(0, 0, -45));
        Instantiate(bulletPrefab, firepoint1.position, firepoint1.rotation);
        Instantiate(bulletPrefab, firepoint1.position + new Vector3(0.2f, 0.2f), Quaternion.Euler(0, 0, 45));

        Instantiate(bulletPrefab, firepoint2.position + new Vector3(0f, 0.2f), Quaternion.Euler(0, 0, 45));
        Instantiate(bulletPrefab, firepoint2.position, firepoint2.rotation);
        Instantiate(bulletPrefab, firepoint2.position + new Vector3(0f, -0.2f), Quaternion.Euler(0, 0, -45));
    }

    public void TripleShotActive()
    {
        tripleShotActive = true;
        tripleShotRemainingTime += tripleShotDuration;  // extend time instead of restarting it
    }
}
