using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Will make an explosion when the bullet hits something
    public GameObject hitEffect;

    // When the box collider hits another box collider this will run
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Insitntiate the hit effect at the position and rotation of the bullet
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // Destroy the effect with a .5 second delay
        Destroy(effect, .5f);
        // Destroy the bullet on collision
        Destroy(gameObject);
    }
}
