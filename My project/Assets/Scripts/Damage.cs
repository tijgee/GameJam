using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Damage : MonoBehaviour {

    private Stats stat;
    public string[] ignore;
    void Start(){
        stat = GetComponent<Stats>();
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(!Array.Exists(ignore, el => el == collision.gameObject.tag)){
            Stats colStats = collision.gameObject.GetComponent<Stats>();
            colStats.health -= stat.damage;
        }
    }
    // Update is called once per frame

}
