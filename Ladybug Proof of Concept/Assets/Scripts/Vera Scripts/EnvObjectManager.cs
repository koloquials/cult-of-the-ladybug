using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvObjectManager : MonoBehaviour {

    public EnvironmentObject thisObject;
    GameObject interactionIcon;
    public bool partcilesActive;
    public GameObject particles;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = thisObject.objectSprite;
        interactionIcon = gameObject.transform.GetChild(0).gameObject;
        interactionIcon.SetActive(false);
    }

    private void Update()
    {
        //CheckForPlayer();
    }

    void CheckForPlayer()
    {

        print("Activate the fucking particles");

        var player = FindObjectOfType<PlayerMove>();
        if ((transform.position-player.gameObject.transform.position).magnitude <= player.interactionRadius)
        {
            //if(!partcilesActive){
            //    print("particles");
            //    Instantiate(particles);
            //    partcilesActive = true;
            //}
        }
        else
        {
            partcilesActive = false;
        }
    }
}
