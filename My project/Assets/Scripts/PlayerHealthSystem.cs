using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthSystem
{
    // Start is called before the first frame update
    private int health;
    private int healthMax;

    public PlayerHealthSystem(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public int GetHealth()
    {
        return health;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > healthMax)
            health = healthMax;
    }
}
