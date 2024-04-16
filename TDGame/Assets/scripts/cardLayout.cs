using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardLayout : MonoBehaviour
{
    public bool isActiveCard = false;
    public GameObject[] cards;
    public float cardLength = 50;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        //set up hand display

        //1. Determine if there's an active card (true if a card is being hovered or played), and if so, which card it is.
        
        //if there is no active card: display all cards as well spaced as we can (but don't space them out too far, that would look odd)

        if(isActiveCard){

        }
        else{
            //for each card in the array, put it at the right location.
            
        }
    }
}
