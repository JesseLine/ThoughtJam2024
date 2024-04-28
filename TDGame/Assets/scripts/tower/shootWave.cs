using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootWave : MonoBehaviour
{
    public float bulletDamage = 2;
    public float rechargeTime = 1;
    private float nextShootTime;

    public GameObject bullet;

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
        if(el){
            damageMultiplier = el.damageMultiplier;
        }

        if(Time.time > nextShootTime){
            GameObject b = Instantiate(bullet);
            waveBullet wb = b.GetComponent<waveBullet>() as waveBullet;
            wb.bulletDamage = bulletDamage * damageMultiplier;

            b.transform.position = transform.position;
            nextShootTime = Time.time + rechargeTime;
        }
    }
}
