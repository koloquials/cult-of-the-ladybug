using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public enum GameState{
        DialogueActive, DuelActive, OverworldActive
    }
    public GameState currentGameState;

    public Canvas dialogueCanvas;
    public Canvas duelCanvas;

    TimeManager timeManager;
    VariableStorage variableStorage;
    GameObject player;

    Text dialogueText;
    Text nameText;
    Image characterImage;

    public DialogueTree treeToRun;

    GameObject duelTrigger;
    public Color normalText, importantText;


    public DuelManager activeDuel;
    public NPC activeNPC;

    private int nodeIndex = 0;
    private int lineIndex = 0;

    float letterPause = 0.04f; //amt of time before next letter prints.
    float extraPause = 0.1f; //extra pause used on commas and periods.
    bool typing = false; //is the coroutine typing?
    bool lineComplete = false; //to ensure a line doesn't get repeated.
    Coroutine type; //holds the typing coroutine

    private void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
        variableStorage = FindObjectOfType<VariableStorage>();
        Transform dt = dialogueCanvas.gameObject.transform.Find("DialogueText");
        Transform it = dialogueCanvas.gameObject.transform.Find("Character");
        nameText = dialogueCanvas.gameObject.transform.Find("NameText").GetComponent<Text>();
        characterImage = it.GetComponent<Image>();
        dialogueText = dt.GetComponent<Text>();
        dialogueText.color = normalText;
        duelTrigger = GameObject.Find("DuelTrigger");
        duelTrigger.SetActive(false);
        dialogueCanvas.gameObject.SetActive(false);
        duelCanvas.gameObject.SetActive(false);
        activeDuel = null;
        player = GameObject.FindGameObjectWithTag("Player");
        currentGameState = GameState.OverworldActive;


    }
    private void Update()
    {
        if (currentGameState==GameState.DialogueActive)
        {
            dialogueCanvas.gameObject.SetActive(true);
            RunDialogue();
        }
        else if (currentGameState!=GameState.DialogueActive)
        {
            dialogueCanvas.gameObject.SetActive(false);
            StopDialogue();
        }

        if (currentGameState==GameState.DuelActive)
        {
            EnableDuel();
            if (activeDuel.duelFinished && currentGameState!=GameState.DialogueActive)
            {
                timeManager.modifier = 1f;
                if (activeDuel.enemyWin)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        ReprimandPlayer(10f);
                    }
                }
                else if (activeDuel.playerWin)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Debug.Log("Win");
                        activeDuel.Reset();
                        StartDialogue(activeNPC.informationReward);
                    }
                }
            }
        }
        else
        {
            try
            {
                activeNPC.GetComponent<DuelManager>().enabled = false;
                activeDuel = null;
                duelCanvas.gameObject.SetActive(false);
            }
            catch (System.NullReferenceException) { }
        }

    }

    public void StartDialogue(DialogueTree tree)
    {
        currentGameState = GameState.DialogueActive;
        treeToRun = tree;
        timeManager.modifier = 0f;

    }

    public void StopDialogue()
    {
        treeToRun = null;
        timeManager.modifier = 1f;
        nodeIndex = 0;
        lineIndex = 0;
        if (currentGameState!=GameState.DuelActive)
        {
            activeNPC = null;
        }
    }

    void RunDialogue()
    {
        try
        {
            //dialogueText.text = treeToRun.dialogueNodes[nodeIndex].dialogueLines[lineIndex].line;
            nameText.text = activeNPC.npcInfo.npcName;
            characterImage.sprite = activeNPC.npcInfo.npcSprites[0].thisSprite;

            if (typing == false && lineComplete == false)
            {
                dialogueText.text = "";
                type = StartCoroutine(TypeText(treeToRun.dialogueNodes[nodeIndex].dialogueLines[lineIndex].line));
            }

            if (treeToRun.dialogueNodes[nodeIndex].dialogueLines[lineIndex].valuableInfo)
            {
                dialogueText.color = importantText;
            }
            else
            {
                dialogueText.color = normalText;
            }

            if (Input.GetKeyDown(KeyCode.E) && typing && lineComplete == false)
            {
                StopCoroutine(type);
                typing = false;
                dialogueText.text = (treeToRun.dialogueNodes[nodeIndex].dialogueLines[lineIndex].line);
                lineComplete = true;
            }

            else if (Input.GetKeyDown(KeyCode.E) && currentGameState==GameState.DialogueActive && lineComplete)
            {
                lineIndex++;
                lineComplete = false;
            }

            if (lineIndex > treeToRun.dialogueNodes[nodeIndex].dialogueLines.Length - 1)
            {
                nodeIndex++;
                lineIndex = 0;
            }

            if (treeToRun.dialogueNodes[nodeIndex].dialogueLines[lineIndex].duelTrigger)
            {
                duelTrigger.SetActive(true);
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    currentGameState = GameState.DuelActive;
                }
            }
            else
            {
                duelTrigger.SetActive(false);
            }

            UnlockInformation(treeToRun.dialogueNodes[nodeIndex]);

            if (nodeIndex == treeToRun.dialogueNodes.Length - 1 && lineIndex > treeToRun.dialogueNodes[nodeIndex].dialogueLines.Length)
            {
                currentGameState = GameState.OverworldActive;
            }
        }
        catch (System.IndexOutOfRangeException)
        {
            currentGameState = GameState.OverworldActive;
        }
    }

    void ReprimandPlayer(float timeToSubtract)
    {
        timeManager.currentTime = (timeManager.currentTime - timeToSubtract);
        activeDuel.Reset();
        currentGameState = GameState.OverworldActive;
        duelCanvas.gameObject.SetActive(false);
    }

    void UnlockInformation(DialogueNode node)
    {
        switch (node.informationIndex)
        {
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

    void EnableDuel()
    {
        duelCanvas.gameObject.SetActive(true);
        activeNPC.GetComponent<DuelManager>().enabled = true;
        activeDuel = activeNPC.GetComponent<DuelManager>();
        timeManager.modifier = 0f;
    }

    IEnumerator TypeText(string message) //scrolling text!
    {
        typing = true;
        foreach (char letter in message.ToCharArray())
        {
            dialogueText.text += letter;

            //if (typeSound1 && typeSound2){ //[WIP] Sound! Can be implemented later!
            //    SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);
            //    yield return 0;
            //}

            if (letter == '.')
            {
                yield return new WaitForSeconds(letterPause + extraPause + extraPause);
                Debug.Log("period.");
            }
            else if (letter == ',' || letter == ';')
            {
                yield return new WaitForSeconds(letterPause + extraPause);
            }
            else
            {
                yield return new WaitForSeconds(letterPause);
            }
        }
        typing = false;
        lineComplete = true;
    }

}
