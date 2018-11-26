using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNPC", menuName = "Characters/Npc Template")]
public class NpcTemplate : ScriptableObject {

    public string npcName;
    [TextAreaAttribute(4,7)]
    public string description;

    [System.Serializable]
    public struct Relationship{
        public NpcTemplate person;
        [TextAreaAttribute(3, 7)]
        public string relationshipDescription;
    }

    [System.Serializable]
    public struct UISprite{
        public string spriteName;
        public Sprite thisSprite;
        public DialogueNode.Tone spriteForTone;
    }

    public Sprite dossierCloseup;

    public UISprite[] npcSprites;
    public Relationship[] npcRelationships;

    public DialogueTree[] possibleTrees;

}
