using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNPC", menuName = "Characters/Npc Template")]
public class NpcTemplate : ScriptableObject {

    public string npcName;

    [System.Serializable]
    public struct Relationship{
        public NpcTemplate person;
        public RelationshipNature nature;
        [TextAreaAttribute(3, 7)]
        public string relationshipDescription;
    }

    public enum RelationshipNature{
        Positive, Negative, StronglyPositive, StronglyNegative, Neutral
    }

    public Relationship[] npcRelationships;

}
