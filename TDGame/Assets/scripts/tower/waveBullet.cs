using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float range = 999;
    public float bulletDamage = 5f;

    void Start()
    {
        
    }
    void Update(){
        transform.localScale += new Vector3(speed*Time.deltaTime, speed*Time.deltaTime, 0);

        if(transform.localScale.x > range){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col){
        enemy enemy_script = col.gameObject.GetComponent("enemy") as enemy;
        if(enemy_script != null){
            col.gameObject.SendMessage("ApplyDamage", bulletDamage);
        }
    }

}
