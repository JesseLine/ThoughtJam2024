using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mortarBullet : MonoBehaviour
{
    public float damage = 5.0f;
    public float speed = 1.0f;
    public Vector3 target;
    private Rigidbody2D rb;
    private float maxYPosition = 10f;
    private bool startMode;
    private float epsilon = .1f;
    public GameObject explosion;
    void Start(){
        print("bullet init'd");
        rb = gameObject.GetComponent<Rigidbody2D>() as Rigidbody2D;
        startMode = true;
    }
    void FixedUpdate(){
        if(startMode){
            rb.AddForce(new Vector2(0, speed * Time.deltaTime));

            if(transform.position.y > maxYPosition){
                startMode = false;
                transform.position = new Vector3(target.x, maxYPosition, target.z);
                rb.velocity = new Vector2(0, -rb.velocity.y);
                transform.eulerAngles = new Vector3(0, 0, 180);
            }

        }
        else{
            if(Vector3.Distance(transform.position, target) < epsilon){
                //boom
                GameObject expl = Instantiate(explosion);
                expl.transform.position = transform.position;
                
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        enemy enemy_script = col.gameObject.GetComponent("enemy") as enemy;
        if(enemy_script != null){
            col.gameObject.SendMessage("ApplyDamage", damage);
        }
    }
    
}
