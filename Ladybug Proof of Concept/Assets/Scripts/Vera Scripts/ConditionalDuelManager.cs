using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalDuelManager : MonoBehaviour {

    NPC nPC;
    VariableStorage variables;

    [System.Serializable]
    public struct DuelCondition {
        public List<Clue> cluesNeededForCondition;
        public DialogueTree newInfoReward;
        public int duelId;
    }

    public DuelCondition currentDuelCondition;
    public DuelCondition[] duelConditions;

    private void Start()
    {
        nPC = GetComponent<NPC>();
        variables = FindObjectOfType<VariableStorage>();
        currentDuelCondition = duelConditions[0];
    }

    private void Update()
    {
        for (int i = 0; i < duelConditions.Length;i++){
            DuelConditionManagement(duelConditions[i]);
        }

        nPC.newDuelId = currentDuelCondition.duelId;
    }

    public void DuelConditionManagement(DuelCondition condition){
        int conditionsMet = 0;
        print("we in this bitch");
        if(condition.cluesNeededForCondition.Count!=0){
            foreach(var c in condition.cluesNeededForCondition){
                if(!variables.clueList.Contains(c)){
                    return;
                } else {
                    conditionsMet++;
                }
            }
        }

        if(conditionsMet == condition.cluesNeededForCondition.Count){
            currentDuelCondition = condition;
            nPC.informationReward = condition.newInfoReward;
        }
    }
}
