using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class turretController : MonoBehaviour
{
    public int radius = 99;
    public float rechargeTime = 1;
    public float bulletSpeed = 2;
    public float bulletDamage = 3;
    public float rotationSpeed = 1;
    private float nextShootTime;

    public GameObject blt;

    private placementController pc;
    private effectListener el;

    // Start is called before the first frame update
    void Start()
    {
        nextShootTime = Time.time + rechargeTime;
        el = gameObject.GetComponent<effectListener>() as effectListener;
        pc = gameObject.GetComponent<placementController>() as placementController;

    }


    // Update is called once per frame
    void Update()
    {
        if(pc.inPlacementMode){
            return;
        }

        float damageMultiplier = 1;
        float speedMultiplier = 1;
        if(el){
            damageMultiplier = el.damageMultiplier;
            speedMultiplier = el.speedMultiplier;
        }

        Collider2D[] nearby = Physics2D.OverlapCircleAll(transform.position, radius); 

        float nearestDist = (float)radius;
        Collider2D nearest = null;
        foreach(Collider2D col in nearby){
            if((col.gameObject.GetComponent<enemy>() as enemy ) != null && Vector2.Distance(col.transform.position, transform.position) < nearestDist){
                nearest = col;
                nearestDist = Vector2.Distance(col.transform.position, transform.position);
            }
        }

        if (nearest == null){
            return;
        }

        
        float angle = Mathf.Atan2(nearest.transform.position.y - transform.position.y, nearest.transform.position.x - transform.position.x ) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if(Time.time > nextShootTime){
            nextShootTime = Time.time + rechargeTime; 

            if(nearest != null){
                GameObject projectile = Instantiate(blt);
                projectile.transform.position = transform.position;
                bullet b = projectile.GetComponent<bullet>() as bullet;
                b.bulletDamage = bulletDamage * damageMultiplier;

                Quaternion rotation = Quaternion.LookRotation (nearest.transform.position - projectile.transform.position, transform.TransformDirection(Vector3.up));
                projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                Rigidbody2D projrb = projectile.GetComponent<Rigidbody2D>() as Rigidbody2D;

                Vector2 speed = transform.up;
                speed.Normalize();
                speed *= bulletSpeed * speedMultiplier;
                projrb.velocity = speed;

            }
        }

    }
}
