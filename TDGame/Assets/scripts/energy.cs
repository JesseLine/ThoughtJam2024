using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class energy : MonoBehaviour
{
    public float currentEnergy;
    public float startingEnergy = 50;
    public float energyGain = 5;
    public float maxEnergy = 100;
    private float nextEnergyGainTime;

    public TMP_Text messageText;

    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = startingEnergy;
        nextEnergyGainTime = Time.time + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextEnergyGainTime){
            currentEnergy += energyGain;
            nextEnergyGainTime = Time.time + 1;
        }
        if (currentEnergy > maxEnergy){
            currentEnergy = maxEnergy;
        }

        messageText.SetText(currentEnergy.ToString());

    }

    public void spendEnergy(float energy){
        currentEnergy -= energy;
    }
}
