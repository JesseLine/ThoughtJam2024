using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp = 1.0f;


    void Start(){

    }

    void Update(){

    }
    void ApplyDamage(float damage){
        hp -= damage;
        if(hp < 0){
            Destroy(gameObject);
        }
    }

}
