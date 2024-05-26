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
        LevelManager.main.energy = startingEnergy;
        nextEnergyGainTime = Time.time + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextEnergyGainTime){
            LevelManager.main.energy += energyGain;
            nextEnergyGainTime = Time.time + 1;
        }
        if (LevelManager.main.energy > maxEnergy){
            LevelManager.main.energy = maxEnergy;
        }

        messageText.SetText(LevelManager.main.energy.ToString());

    }

    public void spendEnergy(float energy){
        LevelManager.main.energy -= energy;
    }
}
