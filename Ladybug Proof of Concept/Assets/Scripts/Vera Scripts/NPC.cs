using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public DialogueTree treeToLoad;
    public DialogueTree informationReward;
    public DuelManager thisDuelManager;

    public List<DialogueTree> possibleTrees;

    public NpcTemplate npcInfo;

    public bool AngryAtPlayer = false;
    public enum Attitude {
        AngryIfLose, AngryIfWin, Neutral, AngryIfOthersLose, AlwaysAngry
    }
    public Attitude attitude;
    VariableStorage variables;

    private void Start()
    {
        possibleTrees = new List<DialogueTree>();
        variables = FindObjectOfType<VariableStorage>();
    }

    private void Update()
    {
        try{
            thisDuelManager = GetComponent<DuelManager>();
            switch (attitude){
                case Attitude.AngryIfLose:
                    if(thisDuelManager.playerWin){
                        AngryAtPlayer = true;
                    }
                    break;
                case Attitude.AngryIfWin:
                    if(thisDuelManager.enemyWin){
                        AngryAtPlayer = true;
                    }
                    break;
                case Attitude.AngryIfOthersLose:
                    SympatheticNPC();
                    break;
                case Attitude.AlwaysAngry:
                    if(thisDuelManager.duelFinished){
                        AngryAtPlayer = true;
                    }
                    break;
            }

        } catch (System.NullReferenceException){}
    }

    void SympatheticNPC(){
        List<NPC> otherNPC = new List<NPC>(FindObjectsOfType<NPC>());
        if (otherNPC.Count!=0)
        {
            foreach (var npc in otherNPC)
            {
                for (int i = 0; i < npc.npcInfo.npcRelationships.Length; i++)
                {
                    if (npc.npcInfo.npcRelationships[i].person == this.npcInfo)
                    {
                        if (npc.AngryAtPlayer)
                        {
                            AngryAtPlayer= true;
                        }
                    }
                }
            }
        } 
    }
}
