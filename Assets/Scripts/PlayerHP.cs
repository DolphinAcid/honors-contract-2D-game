using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public bool hasDied = false;

    public HealthBar healthBar;
    public GameOverScreen gameOverScreen;

    private float collectibleCooldown = 0f; // Collectibles can spawn stacked on each other, so a timer ensures you only go up 1 hp per location
    public float timer = 0f; // Counts how long the game has been going and sends final time to Game Over screen for final score
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (currentHealth <= 0 && !hasDied)
        {
            // Trigger Game Over screen and sound effect
            hasDied = !hasDied;
            Destroy(gameObject);
            gameOverScreen.Setup(timer);
            Time.timeScale = 0; // freezes game upon player death

            FindObjectOfType<AudioManager>().Play("GameOver");
        }

        if (collectibleCooldown >= 0)
        {
            collectibleCooldown -= Time.deltaTime;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentHealth -= 1; // colliding with an enemy lowers your hp by 1
            healthBar.SetHealth(currentHealth);
            FindObjectOfType<AudioManager>().Play("EnemyHitPlayer");
        }

        if (collision.gameObject.tag == "Collectible" && currentHealth < maxHealth && collectibleCooldown <= 0)
        {
            currentHealth += 1; // picking up a collectible raises your hp by 1 (cannot exceed max)
            healthBar.SetHealth(currentHealth);
            collectibleCooldown = 0.5f;
            
        }
    }

}
