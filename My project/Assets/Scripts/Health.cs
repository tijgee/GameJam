using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health: MonoBehaviour
{
    private Stats stat;
    void Start(){
        stat = GetComponent<Stats>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Basic version
        //will need to detect object
        //Get their stats
        //decrement by the damage they deal
        stat.health--;
    }

    // public void Damage(int damageAmount)
    // {
    //     health -= damageAmount;
    // }

    // public void Heal(int healAmount)
    // {
    //     health += healAmount;
    //     if (health > healthMax)
    //         health = healthMax;
    // }
}
