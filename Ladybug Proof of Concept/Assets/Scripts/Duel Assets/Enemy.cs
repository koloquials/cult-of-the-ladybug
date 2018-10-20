using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    public string name = "";
    public List<string> dialogue = new List<string>();
    public List<string> options = new List<string>();
    public List<int> types = new List<int>();

    //the enemy abstract class!! don't touch it you don't need to do anything with it. make copies of ExampleEnemy!

}
