using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static effectManager;

public class effectListener : MonoBehaviour
{
    //see effectManager for usage
    //mostly other scripts should just read these public values as needed though.
    public float damageMultiplier = 1;
    public float speedMultiplier = 1;

    private Dictionary<GameObject, (effectType, float)> activeEffects = new Dictionary<GameObject, (effectType, float)>();

    
    void OnTriggerEnter2D(Collider2D other)
    {
        print(other);
        effectManager manager = other.gameObject.GetComponent<effectManager>() as effectManager;
        if(manager != null){
            effectType type = manager.getEffectType();
            float value = manager.getValue();
            activeEffects[other.gameObject] = (type, value);

            switch(type){
                case effectType.towerDamageBuff:
                    damageMultiplier *= value;
                    break;
                case effectType.towerSpeedBuff:
                    speedMultiplier *= value;
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        print(other);
        if(activeEffects.ContainsKey(other.gameObject)){
            effectType type = activeEffects[other.gameObject].Item1;
            float value = activeEffects[other.gameObject].Item2;
            activeEffects.Remove(other.gameObject);
            switch(type){
                case effectType.towerDamageBuff:
                    damageMultiplier /= value;
                    break;
                case effectType.towerSpeedBuff:
                    speedMultiplier /= value;
                    break;
            }
        }
    }
}
