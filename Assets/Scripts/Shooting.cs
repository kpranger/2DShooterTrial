using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Brings the firepoint object into C# so we can get the position of it
    public Transform firepoint;
    public GameObject bulletPreFab;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    // Creates the method for firing the bullet
    void Shoot()
    {
        // Creating the bullet based on the preFab and firepoint
        GameObject bullet = Instantiate(bulletPreFab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // Adds force to the bullet to make it move
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
