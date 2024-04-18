using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placementController : MonoBehaviour
{
    public GameObject card;
    public bool inPlacementMode = true;
    public bool isInValidPosition = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inPlacementMode){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            print(mousePos);
            transform.position = mousePos;
            CheckValiditiy();
            if(!Input.GetMouseButton(0)){
                if(isInValidPosition){
                    card.SendMessage("OnPlayed");
                    
                }
                else{
                    card.SendMessage("OnUnplayed");
                }
                inPlacementMode = false;
            }
        }
        
    }

    void CheckValiditiy(){
        isInValidPosition = true;
    }
}
