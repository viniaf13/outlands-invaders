using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyFX = default;
    [SerializeField] int pointsOnDeath = 100;
    [SerializeField] int health = 5;

    private void OnParticleCollision(GameObject other)
    {
        health--;
        if (health <= 0)
        {
            Die();
        }
        
    }

    private void Die()
    {
        GameObject enemyExplosion = Instantiate(enemyFX, transform.position, Quaternion.identity) as GameObject;
        FindObjectOfType<ScoreBoard>().AddToScore(pointsOnDeath);
        Destroy(enemyExplosion, 2f);
        Destroy(gameObject);
    }
}
