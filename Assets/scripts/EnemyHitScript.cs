using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with an object tagged as "Bullet"
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Enemy collided with Bullet.");
            // Destroy the enemy GameObject
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
