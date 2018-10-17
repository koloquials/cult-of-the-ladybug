using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuelSquare : MonoBehaviour {
    public int state = 0;
    public bool hasPlayer = false;
    public bool hasEnemy = false;
    public Image square;
    public Image person;
    public bool struck = false;

    void Start () {
        square = GetComponent<Image>();
        person = transform.Find("Person").gameObject.GetComponentInChildren<Image>();
    }
	
	void Update () {
        if (state == 1){ //blue
            square.color = new Color(0.36f, 0.36f, 1, 1);

        }else if (state == 2){ //red
            square.color = new Color(1, 0.36f, 0.36f, 1);
        }
        else{
            square.color = new Color(0.59f, 0.59f, 0.59f, 1);
        }

        if (hasPlayer == true){
            person.color = new Color(0, 0, 0.2f, 1);
        } else if (hasEnemy == true){
            person.color = new Color(0.2f, 0, 0, 1);
        } else{
            person.color = new Color(0, 0, 0, 0);
        }

        if (struck == true){
            if (hasEnemy == true){
                person.color = new Color(0.8f, 0.8f, 1, 1);
            } else if (hasPlayer == true){
                person.color = new Color(1, 0.8f, 0.8f, 1);
            }
        }
    }
}
