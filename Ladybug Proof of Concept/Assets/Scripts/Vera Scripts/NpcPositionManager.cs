using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcPositionManager : MonoBehaviour {

    [System.Serializable]
    public struct NpcPositioning {
        public NpcTemplate npc;
        public List<Position> positions;
        public Vector3 startPosition;
    }
    [System.Serializable]
    public struct Position {
        public Vector2 xyPos;
        public PositionType type;
    }

    public enum PositionType{
        Intro, Overworld
    }

    DialogueManager dialogueManager;

    List<NPC> allNPCs;
    NPC[] npcsToArray;

    private void Start()
    {
        allNPCs = new List<NPC>(FindObjectsOfType<NPC>());
        npcsToArray = allNPCs.ToArray();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {

        switch(dialogueManager.currentGameState){
            case DialogueManager.GameState.IntroScene:
                for (int i = 0; i < npcsToArray.Length; i++){
                    foreach(var p in npcsToArray[i].npcPositioning.positions){
                        if(p.type == PositionType.Intro){
                            npcsToArray[i].transform.position = new Vector3(p.xyPos.x, p.xyPos.y,npcsToArray[i].transform.position.z);
                                                                              
                        }
                    }
                }
                break;
            case DialogueManager.GameState.OverworldActive:
                for (int j = 0; j < npcsToArray.Length; j++)
                {
                    foreach (var p in npcsToArray[j].npcPositioning.positions)
                    {
                        if (p.type == PositionType.Overworld)
                        {
                            npcsToArray[j].transform.position = new Vector3(p.xyPos.x, p.xyPos.y, npcsToArray[j].transform.position.z);

                        }
                    }
                }
                break;
        }
        
    }


}
