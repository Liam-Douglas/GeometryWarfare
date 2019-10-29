using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Liam Nolan
// This script is used to set the bullet spawn and set the bullet object

public class Blaster : MonoBehaviour
{
    public float bulletForce = 20f;

    public Transform bulletSpawn;
    public GameObject bulletObject;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletObject, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletSpawn.up * bulletForce, ForceMode2D.Impulse);
    }
}
