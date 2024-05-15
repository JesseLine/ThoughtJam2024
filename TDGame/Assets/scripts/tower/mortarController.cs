using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mortarController : MonoBehaviour
{
    public float rechargeTime = 1;
    public float bulletSpeed = 2;
    public float bulletDamage = 5;
    private float nextShootTime;
    public GameObject bullet;

    private placementController pc;
    private effectListener el;

    public Sprite loadedSprite;
    public Sprite unloadedSprite;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        nextShootTime = Time.time + rechargeTime;
        el = gameObject.GetComponent<effectListener>() as effectListener;
        pc = gameObject.GetComponent<placementController>() as placementController;
        sr = gameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
    }

    void shoot(Vector3 location){
        //shooting animation here
        
        GameObject projectile = Instantiate(bullet);
        projectile.transform.position = new Vector3(transform.position.x - 0.015f, transform.position.y + .312f, transform.position.z);
        mortarBullet mb = projectile.GetComponent<mortarBullet>() as mortarBullet;
        mb.target = location;
        mb.speed = bulletSpeed;
        mb.damage = bulletDamage;

        
    }
    // Update is called once per frame
    void Update()
    {
        if(pc.inPlacementMode){
            nextShootTime = Time.time + rechargeTime;
            return;
        }

        bool readyToShoot = Time.time > nextShootTime;

        if(readyToShoot){
            //Set some sprite up to indicate readiness
            if(sr.sprite != loadedSprite){
                sr.sprite = loadedSprite;
            }
            if(Input.GetMouseButtonDown(0)){
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0f;
                if(mousePos.x < 3.33){
                    nextShootTime = Time.time + rechargeTime;
                    shoot(mousePos);
                    sr.sprite = unloadedSprite;
                }
            }
        }

    }
}
