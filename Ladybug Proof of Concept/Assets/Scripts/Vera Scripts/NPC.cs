using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public DialogueTree treeToLoad;
    public DialogueTree informationReward;
    public DuelManager thisDuelManager;

    public int newDuelId;

    public List<DialogueTree> possibleTrees;

    public NpcTemplate npcInfo;

    public bool AngryAtPlayer = false;
    public enum Attitude {
        AngryIfLose, AngryIfWin, Neutral, AngryIfOthersLose, AlwaysAngry
    }
    public Attitude attitude;
    public VariableStorage variables;

    public List<NPC> otherNPC;

    [HideInInspector]
    public GameObject interactionIcon;

    public virtual void Start()
    {
        possibleTrees = new List<DialogueTree>();
        variables = FindObjectOfType<VariableStorage>();
        interactionIcon = this.gameObject.transform.Find("InteractionIcon").gameObject;
        interactionIcon.SetActive(false);
        otherNPC = new List<NPC>(FindObjectsOfType<NPC>());
        otherNPC.Remove(this);
    }

    public virtual void Update()
    {
        try{
            thisDuelManager = GetComponent<DuelManager>();
            CheckForPlayer();
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

            if(AngryAtPlayer){
                thisDuelManager.enemyId = newDuelId;
            }

        } catch (System.NullReferenceException){}
    }


    void CheckForPlayer()
    {
        var player = FindObjectOfType<PlayerMove>();
        if((player.gameObject.transform.position - transform.position).magnitude <= player.interactionRadius){
            interactionIcon.SetActive(true);
        } else {
            interactionIcon.SetActive(false);
        }
    }

    void SympatheticNPC(){
       
        foreach (var npc in otherNPC)
        {
            for (int i = 0; i < npcInfo.npcRelationships.Length; i++)
            {
                if (npcInfo.npcRelationships[i].person == npc.npcInfo)
                {
                    if (npc.AngryAtPlayer)
                    {
                        AngryAtPlayer = true;
                    } 
                }
            }
        }
         
    }
}
