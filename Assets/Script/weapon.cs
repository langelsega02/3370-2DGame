using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{

    public Transform firepoint1;
    public Transform firepoint2;
    public GameObject bulletPrefab;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        //shooting
        Instantiate(bulletPrefab, firepoint1.position, firepoint1.rotation);
        Instantiate(bulletPrefab, firepoint2.position, firepoint2.rotation);
    }
}
