using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootWave : MonoBehaviour
{
    public float bulletSpeed = 2;
    public float rechargeTime = 1;
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
            GameObject b = Instantiate(bullet);
            b.transform.position = transform.position;
            nextShootTime = Time.time + rechargeTime;
        }
    }
}
