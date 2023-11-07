using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Health of the enemy

    public float health = 50f;

    // This will be called from our gun script

    public void TakeDamage(float amount)
    {
        // Remove the damage of the weapon from health
        health -= amount;
        Debug.Log(health);

        // If enemy health is too low, it dies
        if (health <= 0f)
        {
            Die();
        }

        // Destroy the game object
        void Die()
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
