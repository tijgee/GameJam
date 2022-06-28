using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    private Stats stat;

    void Start(){
        stat = GetComponent<Stats>();
    }
    void OnCollisionEnter2D(Collision2D collision){
        Stats colStats = collision.gameObject.GetComponent<Stats>();
        colStats.health -= stat.damage;
    }
    // Update is called once per frame

}
