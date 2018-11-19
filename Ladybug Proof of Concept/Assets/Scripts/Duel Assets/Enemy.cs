using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    public string name = "";
    public int startPos = 3;
    public List<string> dialogue = new List<string>();
    public List<string> options = new List<string>();
    public List<int> types = new List<int>();
    public string returnText = "Back, huh?";

    public bool resumeInterrogation = false;
    public int resumedStep = 0;
    public int resumedPlayerPos = 0;
    public int resumedEnemyPos = 0;

    //the enemy abstract class!! don't touch it you don't need to do anything with it. make copies of ExampleEnemy!

}
