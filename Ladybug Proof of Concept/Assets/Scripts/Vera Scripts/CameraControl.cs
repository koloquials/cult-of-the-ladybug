using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour {

    DialogueManager dialogueManager;

    public Transform lerpToAfterIntro;
    Vector3 startPos;
    Camera mainCam;
    public float introSceneTimer;

    public Button[] disable;


    private void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        mainCam = FindObjectOfType<Camera>();
        startPos = mainCam.transform.position;
        for (int i = 0; i < disable.Length; i++){
            disable[i].interactable = false;
        }
    }

    private void Update()
    {
        introSceneTimer -= Time.deltaTime;
        if(dialogueManager.currentGameState == DialogueManager.GameState.IntroScene && introSceneTimer<0f){
            dialogueManager.currentGameState = DialogueManager.GameState.OverworldActive;
        }  

        if(dialogueManager.currentGameState == DialogueManager.GameState.OverworldActive) {
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, lerpToAfterIntro.transform.position, Time.time / 20f);
            for (int i = 0; i < disable.Length; i++)
            {
                disable[i].interactable = true;
            }
        }
    }
}
