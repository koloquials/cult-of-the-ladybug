using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public bool dialogueActive = false;
    public bool duelActive = false;
    public Canvas dialogueCanvas;
    TimeManager timeManager;
    Text dialogueText;
    public DialogueTree treeToRun;
    GameObject duelTrigger;
    public Color normalText, importantText;

    private int nodeIndex = 0;
    private int lineIndex = 0;

    private void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
        Transform dt = dialogueCanvas.gameObject.transform.Find("DialogueText");
        dialogueText = dt.GetComponent<Text>();
        dialogueText.color = normalText;
        duelTrigger = GameObject.Find("DuelTrigger");
        duelTrigger.SetActive(false);

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

    }

    public void StartDialogue(DialogueTree treeToRun)
    {
        dialogueActive = true;
        timeManager.modifier = 0f;

    }

    public void StopDialogue()
    {
        timeManager.modifier = 1f;
        nodeIndex = 0;
        lineIndex = 0;
    }

    void RunDialogue()
    {
        try
        {
            dialogueText.text = treeToRun.dialogueNodes[nodeIndex].dialogueLines[lineIndex].line;
            if (Input.GetKeyUp(KeyCode.E) && dialogueActive)
            {
                Debug.Log("Here");
                lineIndex++;
            }

            if (lineIndex > treeToRun.dialogueNodes[nodeIndex].dialogueLines.Length - 1)
            {
                Debug.Log("Finished this node");
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

            if (nodeIndex >= treeToRun.dialogueNodes.Length - 1 && lineIndex> treeToRun.dialogueNodes[nodeIndex].dialogueLines.Length)
            {
                dialogueActive = false;
            }
            Debug.Log(lineIndex + nodeIndex);
        } catch(System.IndexOutOfRangeException e){
            Debug.Log("Index out of range???");
            dialogueActive = false;
        }
    }

}
