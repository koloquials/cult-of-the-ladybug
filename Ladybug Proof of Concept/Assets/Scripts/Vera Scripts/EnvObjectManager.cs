using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvObjectManager : MonoBehaviour {

    public EnvironmentObject thisObject;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = thisObject.objectSprite;
    }
}
