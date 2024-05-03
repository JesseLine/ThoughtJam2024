using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class card : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject turret;
    public GameObject handContainer;
    public GameObject image;
    public TMP_Text energyText;

    public float cost;
    
    public bool isActive = false;

    public void setCost(float newCost){
        cost = newCost;
        energyText.SetText(newCost.ToString());
    }

    public float getCost(){
        return cost;
    }
    
    public void Clicked(GameObject hand){
        handContainer = hand;
        image.SetActive(false);
        GameObject created = Instantiate(turret);
        (created.GetComponent<placementController>() as placementController).card = gameObject;
    }

    public void OnUnplayed(){
        image.SetActive(true);
        Destroy(turret);
    }

    //called by turret on successful placement
    public void OnPlayed(){
        handContainer.SendMessage("PlayCard", gameObject);
    }



}
