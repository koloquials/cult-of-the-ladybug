using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour {

    DialogueManager dialogueManager;
    PlayerMove player;

    public Transform lerpToAfterIntro, leftRoom, rightRoom, diningRoom, staircase;
    bool introDone = false;
    Vector3 startPos;
    public Vector3 enterLeft, enterRight, enterDining, enterStairs;
    Camera mainCam;
    public float introSceneTimer;

    float overworldOrtho;
    public float focusOrtho, staircaseOrtho;

    public Button[] disable;
    public GameObject theoDisable;


    private void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        player = FindObjectOfType<PlayerMove>();
        mainCam = FindObjectOfType<Camera>();
        startPos = mainCam.transform.position;
        overworldOrtho = mainCam.orthographicSize;
        for (int i = 0; i < disable.Length; i++){
            disable[i].interactable = false;
        }
    }

    private void Update()
    {
      
        if(dialogueManager.currentGameState == DialogueManager.GameState.OverworldActive && !introDone) {
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, lerpToAfterIntro.transform.position, Time.time/20f);
            for (int i = 0; i < disable.Length; i++)
            {
                disable[i].interactable = true;
            }
        } else if (introDone) {
            theoDisable.SetActive(false);
        }
        if (mainCam.transform.position == lerpToAfterIntro.transform.position)
        {
            introDone = true;
        } 
        if(introDone && dialogueManager.currentGameState == DialogueManager.GameState.OverworldActive){
            if(player.transform.position.x < enterLeft.x){
                mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, leftRoom.transform.position, Time.deltaTime * 1.5f );
            }
            else if(player.transform.position.x > enterRight.x){
                mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, rightRoom.transform.position, Time.deltaTime * 1.5f);
            }
            else if(player.transform.position.y > enterDining.y){
                mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, lerpToAfterIntro.transform.position, Time.deltaTime * 1.5f);
            } else if(player.transform.position.y < enterDining.y){
                mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, diningRoom.transform.position, Time.deltaTime * 1.5f);
            } 
            if(player.transform.position.y > enterStairs.y && player.transform.position.x > enterLeft.x && player.transform.position.x < enterRight.x){
                mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, staircase.transform.position, Time.deltaTime * 1.5f);
                SlightZoom(staircaseOrtho);
            } else {
                ResetOrtho();
            }

            //if(mainCam.orthographicSize != overworldOrtho || mainCam.orthographicSize != staircaseOrtho){
            //    ResetOrtho();
            //}

        } else if(introDone && dialogueManager.currentGameState == DialogueManager.GameState.DossierActive){
            FocusOnNpc();
        } else if(!introDone){
            SlightZoom(staircaseOrtho);
        }


    }

    void FocusOnNpc(){
        List<NPC> nPCs = new List<NPC>(FindObjectsOfType<NPC>());
        NPC focus = null;
        foreach (var n in nPCs){
            if(n.npcCanvas.gameObject.activeSelf){
                focus = n;
            }
        }

        mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, 
                                                  new Vector3(focus.transform.position.x+4.5f, focus.transform.position.y + 1f,
                                                             -10f), Time.deltaTime * 1.5f);
        mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, focusOrtho, Mathf.Pow(Time.deltaTime * 15f, 2f));


    }

    public void SlightZoom(float newSize){
        mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, newSize, Time.deltaTime);
    }

    public void ResetOrtho(){
        mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, overworldOrtho, Mathf.Pow(Time.deltaTime * 15f, 2f));
    }
}
