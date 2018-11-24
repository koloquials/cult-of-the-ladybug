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
        public string[] linesInScene;
        public float blackfadeAlpha;
    }

    [System.Serializable]
    public struct Actor {
        public NpcTemplate thisActor;
        public DialogueNode.Tone tone;
    }

    public Scene[] scenesInCutscene;

	
}
