using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCol : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with an object tagged as "Bullet"
        if (other.CompareTag("GreenBullet"))
        {
            Debug.Log("Enemy collided with Bullet.");
            // Destroy the enemy GameObject
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
