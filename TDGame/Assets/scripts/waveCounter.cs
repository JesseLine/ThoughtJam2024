using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class waveCounter : MonoBehaviour
{

    public TMP_Text waveText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waveText.SetText(EnemySpawner.main.getCurrentWave().ToString());
    }
}
