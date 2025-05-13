using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public AudioClip shootClip;          // Assign in Inspector
    private AudioSource audioSource;     // Internal reference

    public Transform firepoint1;
    public Transform firepoint2;
    public GameObject bulletPrefab;
    public bool tripleShotActive = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
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
                audioSource.PlayOneShot(shootClip);
                Shoot();
            }
        }
    }
    void Shoot()
    {
        //shooting
        Instantiate(bulletPrefab, firepoint1.position, firepoint1.rotation);
        Instantiate(bulletPrefab, firepoint2.position, firepoint2.rotation);
    }

    void TripleShot()
    {
        Instantiate(bulletPrefab, firepoint1.position + new Vector3(0f, -0.2f), Quaternion.Euler(new Vector3(0, 0, -45)));
        Instantiate(bulletPrefab, firepoint1.position, firepoint1.rotation);
        Instantiate(bulletPrefab, firepoint1.position + new Vector3(0.2f, 0.2f), Quaternion.Euler(new Vector3(0, 0, 45)));

        Instantiate(bulletPrefab, firepoint2.position + new Vector3(0f, 0.2f), Quaternion.Euler(new Vector3(0, 0, 45)));
        Instantiate(bulletPrefab, firepoint2.position, firepoint2.rotation);
        Instantiate(bulletPrefab, firepoint2.position + new Vector3(0f, -0.2f), Quaternion.Euler(new Vector3(0, 0, -45)));
    }

    public void TripleShotActive()
    {
        tripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(10f);
        tripleShotActive = false;
    }
}
