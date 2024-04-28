using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectManager : MonoBehaviour
{

    public enum effectType{
        towerDamageBuff,
        towerSpeedBuff
    }

    public effectType effect;
    public float value;
    //how this script works:
    //Any aoe buff/debuf should come with a rigidbody2d, a collider set to 'trigger' mode, and this script.
    //set 'effect' to the type of effect, and 'value' to the corresponding multiplier. Everything else should get taken care of by the object impacted.
    
    //Anything wishing to be impacted by an effect should have an effectListener attached, along with a collider of some kind.
    //effectListener will keep track of all effects currently impacting the object, and publish a value to be used by other scripts.
    
    public effectType getEffectType(){
        return effect;
    }
    public float getValue(){
        return value;
    }

}
