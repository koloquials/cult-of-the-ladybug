using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewCutscene", menuName = "Cutscene")]
public class Cutscene : ScriptableObject {

    [System.Serializable]
    public struct Scene {
        public Actor[] actorsInScene;
        public Actor currentSpeaker;
        [TextArea(4,6)]
        public string[] linesInScene;
        public float blackfadeAlpha;
        public bool narration;
        public bool exit;
    }

    [System.Serializable]
    public struct Actor {
        public NpcTemplate thisActor;
        public DialogueNode.Tone tone;
    }

    public Scene[] scenesInCutscene;

	
}
