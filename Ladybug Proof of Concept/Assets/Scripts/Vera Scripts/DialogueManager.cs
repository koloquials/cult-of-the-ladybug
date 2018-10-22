using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public bool dialogueActive = false;
    public bool duelActive = false;

    public Canvas dialogueCanvas;
    public Canvas duelCanvas;

    TimeManager timeManager;
    VariableStorage variableStorage;

    Text dialogueText;

    public DialogueTree treeToRun;

    GameObject duelTrigger;
    public Color normalText, importantText;


    public DuelManager activeDuel;
    public NPC activeNPC;

    private int nodeIndex = 0;
    private int lineIndex = 0;

    private void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
        variableStorage = FindObjectOfType<VariableStorage>();
        Transform dt = dialogueCanvas.gameObject.transform.Find("DialogueText");
        dialogueText = dt.GetComponent<Text>();
        dialogueText.color = normalText;
        duelTrigger = GameObject.Find("DuelTrigger");
        duelTrigger.SetActive(false);
        dialogueCanvas.gameObject.SetActive(false);
        duelCanvas.gameObject.SetActive(false);
        activeDuel = null;

    }
    private void Update()
    {
        if (dialogueActive)
        {
            dialogueCanvas.gameObject.SetActive(true);
            RunDialogue();
        }
        else if(!dialogueActive || duelActive)
        {
            dialogueCanvas.gameObject.SetActive(false);
            StopDialogue();
        }

        if(duelActive){
            EnableDuel();
            if(activeDuel.duelFinished && !dialogueActive){
                timeManager.modifier = 1f;
                if (activeDuel.enemyWin)
                {
                    ReprimandPlayer(10f);
                } else if(activeDuel.playerWin){
                    Debug.Log("Win");
                    StartDialogue(activeNPC.informationReward);
                }
            }
        } else {
            try
            {
                activeNPC.GetComponent<DuelManager>().enabled = false;
                activeDuel = null;
                duelCanvas.gameObject.SetActive(false);
            }catch (System.NullReferenceException){}
        }

    }

    public void StartDialogue(DialogueTree tree)
    {

        if (duelActive)
        {
            duelActive = false;
        }

        dialogueActive = true;
        treeToRun = tree;
        timeManager.modifier = 0f;

    }

    public void StopDialogue()
    {
        treeToRun = null;
        timeManager.modifier = 1f;
        nodeIndex = 0;
        lineIndex = 0;
    }

    void RunDialogue()
    {
        try
        {
            dialogueText.text = treeToRun.dialogueNodes[nodeIndex].dialogueLines[lineIndex].line;
            if (Input.GetKeyUp(KeyCode.R) && dialogueActive)
            {
                lineIndex++;
            }

            if (lineIndex > treeToRun.dialogueNodes[nodeIndex].dialogueLines.Length - 1)
            {
                nodeIndex++;
                lineIndex = 0;
            }

            if(treeToRun.dialogueNodes[nodeIndex].dialogueLines[lineIndex].duelTrigger){
                duelTrigger.SetActive(true);   
                if(Input.GetKeyUp(KeyCode.Space)){
                    duelActive = true;
                    dialogueActive = false;
                }
            } else {
                duelTrigger.SetActive(false);
            }

            if(treeToRun.dialogueNodes[nodeIndex].dialogueLines[lineIndex].valuableInfo){
                dialogueText.color = importantText;
            } else {
                dialogueText.color = normalText;
            }

            UnlockInformation(treeToRun.dialogueNodes[nodeIndex]);

            if (nodeIndex == treeToRun.dialogueNodes.Length - 1 && lineIndex > treeToRun.dialogueNodes[nodeIndex].dialogueLines.Length)
            {
                dialogueActive = false;
            }
        } catch(System.IndexOutOfRangeException){
            dialogueActive = false;
        }
    }

    void ReprimandPlayer(float timeToSubtract){
        timeManager.currentTime = (timeManager.currentTime - timeToSubtract);
        duelActive = false;
    }

    void UnlockInformation(DialogueNode node){
        switch(node.informationIndex){
            case DialogueNode.InformationIndex.Node:
                break;
            case DialogueNode.InformationIndex.Info1:
                variableStorage.infoOne = true;
                break;
            case DialogueNode.InformationIndex.Info2:
                variableStorage.infoTwo = true;
                break;
            case DialogueNode.InformationIndex.Info3:
                variableStorage.infoThree = true;
                break;
            case DialogueNode.InformationIndex.Info4:
                variableStorage.infoFour = true;
                break;
            case DialogueNode.InformationIndex.Info5:
                variableStorage.infoFive = true;
                break;
        }
    }

    void EnableDuel(){
        duelCanvas.gameObject.SetActive(true);
        activeNPC.GetComponent<DuelManager>().enabled = true;
        activeDuel = activeNPC.GetComponent<DuelManager>();
        activeDuel.inDuel = true;
        timeManager.modifier = 0f;
    }

}
