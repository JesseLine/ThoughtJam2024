using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shootNearestEnemy : MonoBehaviour
{
    public int radius = 99;
    public float rechargeTime = 1;
    public float bulletSpeed = 2;
    private float nextShootTime;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        nextShootTime = Time.time + rechargeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if((gameObject.GetComponent<placementController>() as placementController).inPlacementMode){
            return;
        }
        if(Time.time > nextShootTime){
            Collider2D[] nearby = Physics2D.OverlapCircleAll(transform.position, radius); 

            float nearestDist = (float)radius;
            Collider2D nearest = null;
            foreach(Collider2D col in nearby){
                if((col.gameObject.GetComponent<enemy>() as enemy ) != null && Vector2.Distance(col.transform.position, transform.position) < nearestDist){
                    nearest = col;
                    nearestDist = Vector2.Distance(col.transform.position, transform.position);
                }
            }
            nextShootTime = Time.time + rechargeTime; 

            if(nearest != null){
                print(nearest);
                GameObject projectile = Instantiate(bullet);
                projectile.transform.position = transform.position;

                Quaternion rotation = Quaternion.LookRotation (nearest.transform.position - projectile.transform.position, transform.TransformDirection(Vector3.up));
                projectile.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

                Rigidbody2D projrb = projectile.GetComponent<Rigidbody2D>() as Rigidbody2D;

                Vector2 speed = (nearest.transform.position - projectile.transform.position);
                speed.Normalize();
                speed *= bulletSpeed;
                projrb.velocity = speed;

            }
        }

    }
}
