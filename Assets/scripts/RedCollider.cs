using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with an object tagged as "Bullet"
        if (other.CompareTag("RedBullet"))
        {
            Debug.Log("Enemy collided with Bullet.");
            // Destroy the enemy GameObject
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
