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
    public bool holdingTurret = false;
    public energy energySystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        //set up hand display

        //1. Determine if there's an active card (true if a card is being hovered or played), and if so, which card it is.
        getActiveCard();
        //if there is no active card: display all cards as well spaced as we can (but don't space them out too far, that would look odd)

        if(Input.GetMouseButtonDown(0)){
            if(isActiveCard){
                //active card was just clicked on.
                if (energySystem.currentEnergy >= (cards[activeCard].GetComponent<card>() as card).getCost()){

                    print(activeCard);
                    holdingTurret = true;
                    cards[activeCard].SendMessage("Clicked", gameObject);
                }
                else{
                    print("insufficient energy");
                    //todo: animate failure (wiggle energy / turn red?)
                }
            }
        }
        else{
            holdingTurret = false;
        }
        
        if(isActiveCard){
            //todo: make sure the active card is visible
            float cardDelta = .9f / cards.Count;
            if (cardDelta > cardLength * 1.1f){
                cardDelta = cardLength * 1.1f;
            }
            
            for(int i = 0; i < cards.Count; i++){
                cards[i].transform.localPosition = new Vector2(0, .4f - (i * cardDelta));
                (cards[i].GetComponent<SortingGroup>() as SortingGroup).sortingOrder = i;
            }
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

    void getActiveCard(){
        if(holdingTurret){
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null) {
            for(int i = 0; i < cards.Count; i++){
                if(hit.collider.gameObject == cards[i]){
                    isActiveCard = true;
                    activeCard = i;
                    return;
                }
            }
        }
        isActiveCard = false;
    }


    public void PlayCard(GameObject card){
        print("playing card ");
        print(card);
        for(int i = 0; i < cards.Count; i++){
            if(cards[i] == card){
                energySystem.spendEnergy((cards[i].GetComponent<card>() as card).getCost());
                Destroy(cards[i]);
                cards.RemoveAt(i);
            }
        }
    }

}
