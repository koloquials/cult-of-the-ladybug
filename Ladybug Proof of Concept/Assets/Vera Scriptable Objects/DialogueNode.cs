using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNode", menuName = "Dialogue/DialogueNode")]
public class DialogueNode : ScriptableObject {

    [System.Serializable]
    public struct DialogueLine{
        [TextAreaAttribute(3,7)]
        public string line;
        public bool valuableInfo, duelTrigger;
    }
    public string nodeName;
    public DialogueLine[] dialogueLines;
}
