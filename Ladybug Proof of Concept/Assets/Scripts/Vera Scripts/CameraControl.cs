using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    DialogueManager dialogueManager;

    public Transform lerpToAfterIntro;
    Vector3 startPos;
    Camera mainCam;
    public float introSceneTimer;


    private void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        mainCam = FindObjectOfType<Camera>();
        startPos = mainCam.transform.position;
    }

    private void Update()
    {
        introSceneTimer -= Time.deltaTime;
        if(dialogueManager.currentGameState == DialogueManager.GameState.IntroScene && introSceneTimer<0f){
            dialogueManager.currentGameState = DialogueManager.GameState.OverworldActive;
        }  

        if(dialogueManager.currentGameState == DialogueManager.GameState.OverworldActive) {
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, lerpToAfterIntro.transform.position, Time.time / 20f);
        }
    }
}
