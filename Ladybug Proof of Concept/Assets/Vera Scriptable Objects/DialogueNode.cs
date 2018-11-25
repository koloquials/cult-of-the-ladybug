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
        public Tone deliveryTone;
    }
    public string nodeName;
    public string ClueTitle;
    public Clue clueDiscovered;
    public DialogueLine[] dialogueLines;

    [System.Serializable]
    public enum InformationIndex {
        Node, Info1, Info2, Info3, Info4, Info5, Info6
    }
    public InformationIndex informationIndex;

    [System.Serializable]
    public enum Tone{
        Neutral, Suspicious, Happy, Defensive
    }
}
