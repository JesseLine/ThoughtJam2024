using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletDamage = 5.0f;


    void OnTriggerEnter2D(Collider2D col){
        enemy enemy_script = col.gameObject.GetComponent("enemy") as enemy;
        if(enemy_script != null){
            col.gameObject.SendMessage("ApplyDamage", bulletDamage);
            Destroy(gameObject);
        }
    }
    
}
