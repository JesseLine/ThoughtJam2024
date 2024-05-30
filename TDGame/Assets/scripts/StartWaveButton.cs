using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWaveButton : MonoBehaviour
{
    public void NextWaveButton()
    {
        EnemySpawner.onNextWaveButtonClick.Invoke();
    }
}
