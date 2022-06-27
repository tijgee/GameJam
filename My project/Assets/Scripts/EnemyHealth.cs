using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health, maxHealth;

    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "bullet")
        {
            Destroy(col.gameObject);
            TakeDamage(1);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
