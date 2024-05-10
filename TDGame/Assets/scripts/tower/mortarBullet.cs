using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mortarBullet : MonoBehaviour
{
    public float damage = 5.0f;
    public float speed = 1.0f;
    public Vector3 target;
    void Start(){
        print("bullet init'd");

    }
    void OnTriggerEnter2D(Collider2D col){
        enemy enemy_script = col.gameObject.GetComponent("enemy") as enemy;
        if(enemy_script != null){
            col.gameObject.SendMessage("ApplyDamage", damage);
        }
    }
    
}
