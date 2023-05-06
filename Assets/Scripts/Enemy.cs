using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Sprites
    public SpriteRenderer spriteRenderer;
    public Sprite highHealthSprite;
    public Sprite mediumHealthSprite;
    public Sprite lowHealthSprite;

    public int enemyHealth = 3; // how many projectile hits it takes to kill the enemy


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            switch(enemyHealth)
            {
                case 3:
                    FindObjectOfType<AudioManager>().Play("PlayerHitEnemy");
                    spriteRenderer.sprite = mediumHealthSprite;
                    enemyHealth--;
                    break;
                case 2:
                    FindObjectOfType<AudioManager>().Play("PlayerHitEnemy");
                    spriteRenderer.sprite = lowHealthSprite;
                    enemyHealth--;
                    break;
                case 1:
                    // 1% chance for slain enemies to do a Wilhelm scream instead of a regular death sound
                    int random = Random.Range(1, 101);
                    switch(random)
                    {
                        case 1:
                            FindObjectOfType<AudioManager>().Play("WilhelmScream");
                            break;
                        default:
                            FindObjectOfType<AudioManager>().Play("PlayerHitEnemy");
                            break;
                    }            
    
                    Destroy(gameObject);
                    break;
            }
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
