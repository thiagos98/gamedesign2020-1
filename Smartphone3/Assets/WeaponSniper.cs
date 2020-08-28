using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSniper : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        Invoke("Shoot", 0.5f);
    }
    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
