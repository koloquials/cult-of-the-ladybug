using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Clue", menuName = "Dialogue/Clue")]
public class Clue : ScriptableObject {

    [Header("What is the clue about?")]
    public string clueDescription; //what does the clue entail?
    [Header("What gets relayed to the Dossiers?")]
    public DossierEntry[] dossierEntries;
    public HiddenRelationship[] relationshipsToDisclose;
    [Header("What gets displayed in the Accusation Menu?")]
    public string accuseMenuDropdown;
    public string accuseMenuDescription;

    [System.Serializable]
    public struct DossierEntry {
        public NpcTemplate personInQuestion;
        [TextArea(3,3)]
        public string dossierEntry;
    }

    [System.Serializable]
    public struct HiddenRelationship {
        public NpcTemplate personInQuestion;
        public NpcTemplate hasRelationshipWith;
    }

    public int index;

}
