using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootProjectile : MonoBehaviour
{
    public Transform firePoint; // Where bullets are instantiated
    public GameObject projectilePrefab;

    public float projectileForce = 20f; // Change to make bullet go faster or slower
    public float projectileCooldown = 0f; // No bullet spam


    void Update()
    {
        if (Input.GetButton("Fire1") && projectileCooldown <= 0) // Bound to mouse 1 (left click) by default; GetButton so you can hold to keep shooting
        {
            projectileCooldown = 0.5f; // Shooting cooldown
            Shoot();
        }

        if (projectileCooldown >= 0)
        {
            projectileCooldown -= Time.deltaTime; // Tick down shooting cooldown
        }
    }

    void Shoot()
    {
        FindObjectOfType<AudioManager>().Play("PlayerFire");
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation); // Spawn projectile and store in a game object
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>(); // Get the rigidbody on the projectile
        rb.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse); // Apply force to the rigidbody of the projectile to make it move
    }


}