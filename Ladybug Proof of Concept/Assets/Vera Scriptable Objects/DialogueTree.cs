using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewTree", menuName = "Dialogue/DialogueTree")]
public class DialogueTree : ScriptableObject {

    public string treeName;
    public DialogueNode[] dialogueNodes;

}
