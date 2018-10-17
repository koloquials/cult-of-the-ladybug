using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public DialogueTree treeToLoad;
    public DuelManager thisDuelManager;

    public List<DialogueTree> possibleTrees;

    public NpcTemplate npcInfo;

    public bool AngryAtPlayer = false;

    private void Start()
    {
        possibleTrees = new List<DialogueTree>();
    }

    private void Update()
    {
        try{
            thisDuelManager = GetComponent<DuelManager>();
        } catch (System.NullReferenceException){
            Debug.Log("Duel manager is not enabled yet");
            return;
        }
    }
}
