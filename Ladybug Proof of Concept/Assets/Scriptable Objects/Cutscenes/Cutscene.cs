<<<<<<< HEAD:Ladybug Proof of Concept/Assets/Scriptable Objects/Cutscenes/Cutscene.cs
﻿using System.Collections;
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
    }

    [System.Serializable]
    public struct Actor {
        public NpcTemplate thisActor;
        public DialogueNode.Tone tone;
    }

    public Scene[] scenesInCutscene;

	
}
=======
﻿using System.Collections;
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
>>>>>>> a8e6a60b39f5e463be6a0ce481abf36c6ea12ed9:Ladybug Proof of Concept/Assets/Vera Scriptable Objects/Cutscenes/Cutscene.cs
