using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deck : MonoBehaviour
{
    public GameObject handContainer;
    public float drawTime = 5;
    public List<GameObject> activeDeck;
    private cardLayout hand;
    private float nextDrawTime;
    // Start is called before the first frame update
    void Start()
    {
        hand = handContainer.GetComponent<cardLayout>() as cardLayout;
        nextDrawTime = Time.time + drawTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextDrawTime){
            nextDrawTime = Time.time + drawTime;
            if(activeDeck.Count == 0){
                //fizzle animation here
                return;
            }

            int cardNum = Random.Range(0, activeDeck.Count-1);
            GameObject card = Instantiate(activeDeck[cardNum]);
            card.transform.SetParent(handContainer.transform);
            hand.cards.Add(card);
            activeDeck.RemoveAt(cardNum);
            
        }
    }
}
