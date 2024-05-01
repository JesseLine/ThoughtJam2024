using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turbineController : MonoBehaviour
{

    public float additionalEnergy = 1;
    private energy energyController;
    private bool energyIncreased = false;
    void Start(){
        energyController = GameObject.Find("energy").GetComponent<energy>() as energy;

    }
    // Update is called once per frame
    void Update()
    {
        if((gameObject.GetComponent<placementController>() as placementController).inPlacementMode){
            return;
        }
        if(!energyIncreased){
            energyController.energyGain += additionalEnergy;
            energyIncreased = true;
        }

    }

    void OnDestroy()
    {
        if(energyIncreased){
            energyController.energyGain -= additionalEnergy;
        }
    }
}
