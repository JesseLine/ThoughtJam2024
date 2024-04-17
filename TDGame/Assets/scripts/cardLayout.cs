using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class cardLayout : MonoBehaviour
{
    public bool isActiveCard = false;
    public int activeCard;
    public List<GameObject> cards;
    public float cardLength = .15f;


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
            //todo: make sure the active card is visible
            
        }
        else{
            //for each card in the array, put it at the right location.
            float cardDelta = .9f / cards.Count;
            if (cardDelta > cardLength * 1.1f){
                cardDelta = cardLength * 1.1f;
            }
            
            for(int i = 0; i < cards.Count; i++){
                cards[i].transform.localPosition = new Vector2(0, .4f - (i * cardDelta));
                (cards[i].GetComponent<SortingGroup>() as SortingGroup).sortingOrder = i;
            }
        }
    }
}
