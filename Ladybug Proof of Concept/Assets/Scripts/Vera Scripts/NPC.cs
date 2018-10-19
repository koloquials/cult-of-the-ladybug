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
        } catch (System.NullReferenceException){}
    }
}
