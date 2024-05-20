using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float damage = 5f;
    public float extantTime = 1;

    private float startTime;

    void Start()
    {
        startTime = Time.time;
        
    }
    void Update(){
        if(Time.time > startTime + extantTime){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col){
        enemy enemy_script = col.gameObject.GetComponent("enemy") as enemy;
        if(enemy_script != null){
            col.gameObject.SendMessage("ApplyDamage", damage);
        }
    }

}
