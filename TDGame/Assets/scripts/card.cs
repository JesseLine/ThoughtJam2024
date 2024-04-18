using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class card : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject turret;
    public GameObject handContainer;
    public GameObject image;

    public bool isActive = false;

    //called by turret on successful placement
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

    public void OnPlayed(){
        print("played card here");
        handContainer.SendMessage("PlayCard", gameObject);
    }



}
