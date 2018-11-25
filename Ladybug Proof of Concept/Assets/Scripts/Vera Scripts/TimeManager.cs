using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {

    public float timeLimit; 
    float currentTime, modifier;
    DialogueManager manager;

    public GameObject gameOverText;
    public int GameOverSceneIndex;

    private void Start()
    {
        //timeLimit = 100f;
        currentTime = timeLimit;
        manager = FindObjectOfType<DialogueManager>();
        gameOverText.SetActive(false);
    }

    private void Update()
    {
        DisplayTime();
        if(currentTime<=0f){
            
            manager.currentGameState = DialogueManager.GameState.TimerOut;
        }

        if (manager.currentGameState == DialogueManager.GameState.OverworldActive)
        {
            currentTime -= (Time.deltaTime * modifier);
            modifier = 1f;
        } else {
            modifier = 0f;
        }

        if(manager.currentGameState == DialogueManager.GameState.TimerOut){

            currentTime = 0f;
            gameOverText.SetActive(true);
        }

        
    }

    void DisplayTime(){
        GameObject timertext = GameObject.Find("TimerText");
        Text tt = timertext.GetComponent<Text>();
        tt.text = "" + Mathf.CeilToInt(currentTime);
    }
}
