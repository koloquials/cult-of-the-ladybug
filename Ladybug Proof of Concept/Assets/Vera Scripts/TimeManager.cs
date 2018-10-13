using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public float timeLimit, currentTime, modifier;

    private void Start()
    {
        currentTime = timeLimit;
    }

    private void Update()
    {
        DisplayTime();
        currentTime -= (Time.deltaTime * modifier);
        
    }

    void DisplayTime(){
        GameObject timertext = GameObject.Find("TimerText");
        Text tt = timertext.GetComponent<Text>();
        tt.text = "" + Mathf.FloorToInt(currentTime);
    }
}
