using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static effectManager;
public class buffController : MonoBehaviour
{
    // Start is called before the first frame update
    private effectManager manager;
    public float speedBuff = 2.5f;
    public float damageBuff = 1.5f;
    public float fireRateBuff = 1.5f;
    public SpriteRenderer auraSprite;

    void Start()
    {
        manager = auraSprite.gameObject.GetComponent<effectManager>() as effectManager;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Input.GetMouseButtonDown(0)){
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        print("checking");
        if (hit.collider != null) {
            print("got hit");
            print(hit.collider.gameObject);
            if(hit.collider.gameObject == gameObject){
                if(manager.effect == effectType.towerSpeedBuff){
                    manager.effect = effectType.towerFireRateBuff;
                    manager.value = fireRateBuff;
                    auraSprite.color = new Color(0x22 / 256f, 0x00/ 256f, 0xcc/ 256f, 22/ 256f);
                }
                else if(manager.effect == effectType.towerFireRateBuff){
                    manager.effect = effectType.towerDamageBuff;
                    manager.value = damageBuff;
                    auraSprite.color = new Color(0xee/ 256f, 0x22/ 256f, 0x0/ 256f, 22/ 256f);
                }
                else if(manager.effect == effectType.towerDamageBuff){
                    manager.effect = effectType.towerSpeedBuff;
                    manager.value = speedBuff;
                    auraSprite.color = new Color(0x11/ 256f, 0xbb/ 256f, 0x33/ 256f, 22/ 256f);
                }
            }
        }
    }
}
