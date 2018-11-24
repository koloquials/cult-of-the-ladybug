using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelSqSprite : MonoBehaviour {
 public int state = 0;
    public bool hasPlayer = false;
    public bool hasEnemy = false;
    //public Image square;
   // public Image person;
    public bool struck = false;

    public Sprite[] zone = new Sprite[3];
    public SpriteRenderer zoneRenderer;

    public Sprite[] person = new Sprite[4];
    public SpriteRenderer personRenderer;

    void Start () {
        zoneRenderer = GetComponent<SpriteRenderer>();
        //zoneRenderer.sprite = zone[0];

        zoneRenderer = GetComponent<SpriteRenderer>();
        //personRenderer.sprite = person[2];
        personRenderer.sortingLayerName = "Duel Tiles";

    }

    void Update () {
        if (state == 1){ //blue
            zoneRenderer.sprite = zone[0];

        }else if (state == 2){ //red
            zoneRenderer.sprite = zone[1];
        }
        else{
            zoneRenderer.sprite = zone[2];
        }

        if (hasPlayer == true){
            personRenderer.sprite = person[0];
        } else if (hasEnemy == true){
            personRenderer.sprite = person[1];
        } else{
            personRenderer.sprite = null;
        }

        if (struck == true){
            personRenderer.sprite = person[2];
        }
    }
}
