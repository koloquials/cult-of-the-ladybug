using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewObject", menuName = "Environment/Object")]
public class EnvironmentObject : ScriptableObject {

    public string objectName;
    public DialogueNode objectDescription;
    public Sprite objectSprite;

}
