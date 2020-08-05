using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyFX = default;
    private void OnParticleCollision(GameObject other)
    {
        GameObject enemyExplosion = Instantiate(enemyFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(enemyExplosion, 2f);
        Destroy(gameObject);
    }
}
