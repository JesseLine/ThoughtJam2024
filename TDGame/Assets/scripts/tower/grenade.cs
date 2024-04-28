using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{
    public float dropTime = 1;
    private float explosionTime;
    private float shrinkSize = .5f;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((gameObject.GetComponent<placementController>() as placementController).inPlacementMode){
            explosionTime = Time.time + dropTime;
            return;
        }

        float newScale = (1-shrinkSize) + shrinkSize * ((explosionTime - Time.time) / dropTime);
        transform.localScale = new Vector3(newScale, newScale, 1);

        if (Time.time > explosionTime){
            GameObject b = Instantiate(explosion);
            b.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
