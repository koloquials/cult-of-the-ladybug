using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvObjectManager : MonoBehaviour {

    public EnvironmentObject thisObject;
    GameObject interactionIcon;

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
        var player = FindObjectOfType<PlayerMove>();
        if ((player.gameObject.transform.position - transform.position).magnitude <= player.interactionRadius)
        {
            interactionIcon.SetActive(true);
            //if(!player.dossierActive && Input.GetKeyDown(KeyCode.Space)){
            //    player.dossierActive = true;
            //    npcCanvas.gameObject.SetActive(true);
            //}
            //if(player.dossierActive && Input.GetKeyDown(KeyCode.Space)){
            //    player.dossierActive = false;
            //    npcCanvas.gameObject.SetActive(true);
            //}
        }
        else
        {
            interactionIcon.SetActive(false);
        }
    }
}
