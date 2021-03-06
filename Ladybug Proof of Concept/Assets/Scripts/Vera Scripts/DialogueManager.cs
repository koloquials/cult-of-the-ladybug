﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogueManager : MonoBehaviour
{
    [System.Serializable]

    public enum GameState{ //possible game states to be in
        DialogueActive, DuelActive, DescriptionActive, OverworldActive, TimerOut, MenuActive, IntroScene, Win, DossierActive
    }
    public GameState currentGameState; //current game state we're in (gets updated)

    public Canvas dialogueCanvas; //reference to the dialogue canvas 
    public Canvas duelCanvas; //reference to the Duel Canvas
    public Canvas descriptionCanvas;
    public Canvas cutsceneCanvas;
    public Canvas hudCanvas;

    TimeManager timeManager; //reference to the time manager 
    VariableStorage variableStorage; //reference to information storage
    GameObject player; //reference to the player

    Text dialogueText; //text that displays the dialogue being run
    Text nameText; //text that displays the name of the character you're talking to
    Image characterImage; //image that displays the sprite of the character you're talking to
    Text descriptionText; //text for displaying object description
    public Text cutsceneText;

    public DialogueTree treeToRun; //dialogue tree that's getting parsed
    public Cutscene introCutscene, endingCutscene;
    public Cutscene toRun;

    GameObject duelTrigger; //image that gets toggled to signify that a duel can be triggered
    public Color normalText, importantText; //colors to change the text to depending on how valuable it is


    public DuelManager activeDuel; //duel that's getting played
    public NPC activeNPC; //npc that is being interacted with
    public EnvObjectManager activeObject;

    public AudioSource bgNorm;
    public AudioSource bgDuel;
    public AudioSource importantInfoSFX;

    public AudioClip importante;
    public AudioClip failure;


    //public AudioClip correct;
    //public AudioClip incorrect;

    private bool hasPlayed = false;

    private int nodeIndex = 0; //node index for the dialogue node [] on the dialogue tree
    private int lineIndex = 0; //line index for the line [] on the dialogue nodes

    int descriptionIndex = 0; //index for the description node

    float letterPause = 0.04f; //amt of time before next letter prints.
    float extraPause = 0.1f; //extra pause used on commas and periods.
    bool typing = false; //is the coroutine typing?
    bool lineComplete = false; //to ensure a line doesn't get repeated.
    Coroutine type; //holds the typing coroutine




    private void Start()
    {
        timeManager = FindObjectOfType<TimeManager>(); //finds TimeManager script on start
        variableStorage = FindObjectOfType<VariableStorage>(); //finds VariableStorage script on start
        Transform dt = dialogueCanvas.gameObject.transform.Find("DialogueText"); //finds the Dialogue Text on start
        Transform it = dialogueCanvas.gameObject.transform.Find("Character"); //finds the character UI sprite on start
        nameText = dialogueCanvas.gameObject.transform.Find("NameText").GetComponent<Text>(); //assigns the name text on start
        characterImage = it.GetComponent<Image>(); //assigns the UI character sprite image
        dialogueText = dt.GetComponent<Text>(); //assigns the dialogue text
        dialogueText.color = normalText; //assigns the default text color
        duelTrigger = GameObject.Find("DuelTrigger"); //finds the duel trigger game object
        duelTrigger.SetActive(false); //turns the duel trigger off on start
        dialogueCanvas.gameObject.SetActive(false); //turns the dialogue canvas off at start
        duelCanvas.gameObject.SetActive(false); //turns the duel canvas off at start
        activeDuel = null; //sets active duel to null on start
        player = GameObject.FindGameObjectWithTag("Player"); //finds the player by tag on start
        currentGameState = GameState.IntroScene;

        descriptionText = descriptionCanvas.gameObject.transform.Find("Description").GetComponent<Text>();
        descriptionText.text = null;
        descriptionCanvas.gameObject.SetActive(false);
        hudCanvas.gameObject.SetActive(false);
        toRun = introCutscene;
        
    }
    private void Update()
    {
        if(currentGameState == GameState.OverworldActive){
            hudCanvas.gameObject.SetActive(true);
            introLineIndex = 0;
            introSceneIndex = 0;
            toRun = null;
        }

        if (currentGameState == GameState.IntroScene)
        {
            RunCutScene(toRun, cutsceneText);
        }
        else if (currentGameState == GameState.Win || currentGameState == GameState.TimerOut)
        {
            toRun = endingCutscene;
            cutsceneCanvas.gameObject.SetActive(true);
            hudCanvas.gameObject.SetActive(false);
            RunCutScene(toRun, cutsceneText);

        } else {
            cutsceneCanvas.gameObject.SetActive(false);
        }
        if (currentGameState==GameState.DialogueActive) //turns the dialogue canvas on and runs dialogue when dialogue is triggered 
        {
            dialogueCanvas.gameObject.SetActive(true);
            hudCanvas.gameObject.SetActive(false);
            RunDialogue();
        }
        else if (currentGameState!=GameState.DialogueActive) //turns the dialogue canvas off and stops dialogue when dialogue is finished or cancelled
        {
            dialogueCanvas.gameObject.SetActive(false);
            StopDialogue();
        }

        if(currentGameState == GameState.DescriptionActive){
            descriptionCanvas.gameObject.SetActive(true);
            RunDescription();
        } else if(currentGameState!= GameState.DescriptionActive){
            descriptionCanvas.gameObject.SetActive(false);
            StopDescription();
        }

        if (currentGameState==GameState.DuelActive) 
        {
            EnableDuel(); //enables the duel when it is triggered
            hudCanvas.gameObject.SetActive(false);

            if (activeDuel.duelFinished && currentGameState!=GameState.DialogueActive)
            {
                //timeManager.modifier = 1f; //resumes time when the duel concludes

                if (activeDuel.playerLose) //player loss handling
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        ReprimandPlayer(1f); //reprimands player upon loss when they press space 
                        activeDuel.enabled = false; //turns of the duel component on the npc we're interacting with

                        bgDuel.Stop();
                        bgNorm.Play();
                        Debug.Log("duel music stop");
                        //duel ends

                        StartDialogue(activeNPC.lossTree);
                    }
                }
                else if (activeDuel.playerWin) //player win handling
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        activeDuel.Reset(); //reset the duel componenet on the npc
                        activeDuel.enabled = false; //turn the duel component on the npc off

                        bgDuel.Stop();
                        bgNorm.Play();
                        Debug.Log("duel music stop");
                        //duel ends
                        StartDialogue(activeNPC.informationReward); //run the information to load tree on the npc
                        
                        activeNPC.duelingStatus = NPC.DuelingStatus.PostDuel;
                    }
                }
            }
        }
        else
        {
            try
            {
                activeNPC.GetComponent<DuelManager>().enabled = false; //this shit doesn't work but i'm too afraid to comment it out tbfh lmao
                activeDuel = null;
                duelCanvas.gameObject.SetActive(false);
                
            }
            catch (System.NullReferenceException) { }
        }

    }

    public void StartDialogue(DialogueTree tree) //function that initiates dialogue
    {
        currentGameState = GameState.DialogueActive; //sets current game state to dialogue active
        treeToRun = tree; //sets the tree that we're running to the tree in the parameter
       // timeManager.modifier = 0f; //stops time from decreasing 
        lineComplete = false; //fix dialogue loading bug

    }

    public void StopDialogue() //function that resets all the dialogue shit
    {
        treeToRun = null; //loses the reference to the tree that we passed in StartDialogue()
        //timeManager.modifier = 1f; //resumes timer countdown
        nodeIndex = 0; //resets node index to 0
        lineIndex = 0; //resets line index to 0
        if (currentGameState!=GameState.DuelActive) //loses reference to npc we're interacting with unless we're dueling them 
        {
            activeNPC = null;
        }
    }

    void RunDialogue() //function that runs the dialogue
    {
        try
        {
            //dialogueText.text = treeToRun.dialogueNodes[nodeIndex].dialogueLines[lineIndex].line;
            nameText.text = activeNPC.npcInfo.npcName;
            //characterImage.sprite = activeNPC.npcInfo.npcSprites[0].thisSprite;
            HandleUISprites(treeToRun.dialogueNodes[nodeIndex].dialogueLines[lineIndex], activeNPC.npcInfo);

            if (typing == false && lineComplete == false)
            {
                dialogueText.text = "";
                print("let's type " + treeToRun.dialogueNodes[nodeIndex].dialogueLines[lineIndex].line);
                type = StartCoroutine(TypeText(treeToRun.dialogueNodes[nodeIndex].dialogueLines[lineIndex].line, dialogueText));
            }

            if (treeToRun.dialogueNodes[nodeIndex].dialogueLines[lineIndex].valuableInfo)
            {
                dialogueText.color = importantText;
                variableStorage.AddInfo(treeToRun.dialogueNodes[nodeIndex].dialogueLines[lineIndex].line, treeToRun.dialogueNodes[nodeIndex]);
                variableStorage.DiscoverClue(treeToRun.dialogueNodes[nodeIndex]);

                //play important sfx here
                if (!hasPlayed)
                {
                    importantInfoSFX.PlayOneShot(importante);
                    Debug.Log("importante");
                }
                hasPlayed = true;

            }
            else
            {
                dialogueText.color = normalText;
                hasPlayed = false;
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

            if (treeToRun.dialogueNodes[nodeIndex].dialogueLines[lineIndex].duelTrigger && activeNPC.duelingStatus == NPC.DuelingStatus.CanDuel)
            {
                duelTrigger.SetActive(true);
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    
                    currentGameState = GameState.DuelActive;
                    bgNorm.Stop();
                    bgDuel.Play();
                    Debug.Log("duel music start");

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
        activeDuel.Reset();
        duelCanvas.gameObject.SetActive(false);
        activeNPC.currentStatus = NPC.NPCStatus.Heated;
        //play lose sfx here
        if (!hasPlayed)
        {
            importantInfoSFX.PlayOneShot(failure);
            Debug.Log("lose");
        }
        hasPlayed = true;
    }

    void UnlockInformation(DialogueNode node) //function that checks the nodes that get passed through the 
    {                                         //dialogue manager for information and passes it to variable storage once it finds information
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
            case DialogueNode.InformationIndex.Info6:
                variableStorage.infoSix = true;
                break;
        }

    }

    void HandleUISprites(DialogueNode.DialogueLine currentLine, NpcTemplate npc){
        for (int i = 0; i < npc.npcSprites.Length; i++){
            if(currentLine.deliveryTone == npc.npcSprites[i].spriteForTone){
                characterImage.sprite = npc.npcSprites[i].thisSprite;
            } 
        }
        
    }

    void EnableDuel() //I slapped all the duel enabling shit in a function because it looked ugly lmao
    {
        duelCanvas.gameObject.SetActive(true); //turns the duel canvas on
        activeNPC.GetComponent<DuelManager>().enabled = true; //enables the duel manager on the npc we're interacting with
        activeDuel = activeNPC.GetComponent<DuelManager>(); //sets active duel to the duel manager on the npc we're interacting with
        //timeManager.modifier = 0f; //stops time from decreasing during the duel
    }

    IEnumerator TypeText(string message, Text textToEdit) //scrolling text!
    {
        typing = true;
        foreach (char letter in message.ToCharArray())
        {
            //dialogueText.text += letter;
            textToEdit.text += letter;

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


    public void StartDescription()
    {
        currentGameState = GameState.DescriptionActive;
        Debug.Log("here");
        lineComplete = false;
        hudCanvas.gameObject.SetActive(false);
    }

    DialogueNode nodeToRun;

    void RunDescription()
    {
        try{
            nodeToRun = activeObject.thisObject.objectDescription;


            if (typing == false && lineComplete == false)
            {
                descriptionText.text = "";//nodeToRun.dialogueLines[descriptionIndex].line;
                print("let's type " + nodeToRun.dialogueLines[descriptionIndex].line);
                type = StartCoroutine(TypeText(nodeToRun.dialogueLines[descriptionIndex].line, descriptionText));
            }

            if (nodeToRun.dialogueLines[descriptionIndex].valuableInfo)
            {
                descriptionText.color = importantText;
                variableStorage.DiscoverClue(nodeToRun);
                //play important sfx here
                if (!hasPlayed)
                {
                    importantInfoSFX.PlayOneShot(importante);
                    Debug.Log("importante");
                }
                hasPlayed = true;
            }
            else
            {
                descriptionText.color = normalText;
                hasPlayed = false;
            }

            if (Input.GetKeyDown(KeyCode.E) && typing && lineComplete == false)
            {
                StopCoroutine(type);
                typing = false;
                descriptionText.text = (nodeToRun.dialogueLines[descriptionIndex].line);
                lineComplete = true;
            }

            else if (Input.GetKeyDown(KeyCode.E) && currentGameState == GameState.DescriptionActive && lineComplete)
            {
                descriptionIndex++;
                lineComplete = false;
            }

            UnlockInformation(nodeToRun);

            if (descriptionIndex > nodeToRun.dialogueLines.Length)
            {
                currentGameState = GameState.OverworldActive;
            }
            
        } catch(System.IndexOutOfRangeException){
            print("we outta here");
            currentGameState = GameState.OverworldActive;
        }

    }

    void StopDescription(){
        activeObject = null;
        nodeToRun = null;
        descriptionIndex = 0;
    }
    int introLineIndex = 0;
    int introSceneIndex = 0;
    float mult = 0.75f;

    void RunCutScene(Cutscene cutscene, Text cutText){
        try{

            Image mask = cutsceneCanvas.transform.Find("Mask").gameObject.GetComponent<Image>();
            Color alpha = new Color(0f, 0f, 0f, Mathf.Lerp(mask.color.a, cutscene.scenesInCutscene[introSceneIndex].blackfadeAlpha, mult * Time.deltaTime));
            mask.color = alpha;

            HandleCutsceneActors(cutscene, cutsceneCanvas);

            if(typing == false && lineComplete == false){
                cutText.text = "";
                type = StartCoroutine(TypeText(cutscene.scenesInCutscene[introSceneIndex].linesInScene[introLineIndex], cutText));
            }

            if (Input.GetKeyDown(KeyCode.E) && typing && lineComplete == false)
            {
                StopCoroutine(type);
                typing = false;
                cutText.text = (cutscene.scenesInCutscene[introSceneIndex].linesInScene[introLineIndex]);
                lineComplete = true;
            }

            else if (Input.GetKeyDown(KeyCode.E) && lineComplete && !cutscene.scenesInCutscene[introSceneIndex].exit)
            {

                if(currentGameState == GameState.IntroScene || currentGameState == GameState.TimerOut || currentGameState == GameState.Win){
                    introLineIndex++;
                    lineComplete = false;
                }

            } 

            if (cutscene.scenesInCutscene[introSceneIndex].exit)
            {
                mult = 0.35f;
                mask.transform.SetAsLastSibling();
                if (mask.color.a >= 0.95f)
                {
                    print("Change Scene");
                    SceneManager.LoadScene(2);
                }
                else
                {
                    print("bitch what the fuck");
                }
            }

            if (introLineIndex > cutscene.scenesInCutscene[introSceneIndex].linesInScene.Length-1)
            {
                introLineIndex = 0;
                introSceneIndex++;
            }
            if (introSceneIndex > cutscene.scenesInCutscene.Length && !cutscene.scenesInCutscene[introSceneIndex].exit)
            {
                currentGameState = GameState.OverworldActive;
            } 

                      
        } catch (System.IndexOutOfRangeException){
            currentGameState = GameState.OverworldActive;
        }

    }

    public Color active, notActive;

    void HandleCutsceneActors(Cutscene cutscene, Canvas canvas){
        GameObject actorList = canvas.gameObject.transform.Find("Actors").gameObject;
        int maxActors = actorList.transform.childCount;
        Image[] ActorImageSprites = new Image[maxActors];
        Text cutNameText = canvas.gameObject.transform.Find("NameText").GetComponent<Text>();
        Color noAlpha = new Color(0f,0f,0f,0f);
        for (int i = 0; i < ActorImageSprites.Length; i++)
        {
            ActorImageSprites[i] = actorList.transform.GetChild(i).GetComponent<Image>();
            try
            {
                ActorImageSprites[i].gameObject.SetActive(true);
                if(cutscene.scenesInCutscene[introSceneIndex].theoDead == true)
                {
                    GameObject.Find("Theodore").GetComponent<SpriteRenderer>().enabled = false;
                }
                if(!cutscene.scenesInCutscene[introSceneIndex].narration){
                    cutNameText.text = cutscene.scenesInCutscene[introSceneIndex].currentSpeaker.thisActor.npcName;
                    for (int j = 0; j < cutscene.scenesInCutscene[introSceneIndex].actorsInScene[i].thisActor.npcSprites.Length; j++)
                    {
                        if (cutscene.scenesInCutscene[introSceneIndex].actorsInScene[i].thisActor.npcSprites[j].spriteForTone
                           == cutscene.scenesInCutscene[introSceneIndex].actorsInScene[i].tone)
                        {
                            ActorImageSprites[i].sprite = cutscene.scenesInCutscene[introSceneIndex].actorsInScene[i].thisActor.npcSprites[j].thisSprite;
                            if (cutscene.scenesInCutscene[introSceneIndex].currentSpeaker.thisActor == cutscene.scenesInCutscene[introSceneIndex].actorsInScene[i].thisActor)
                            {
                                ActorImageSprites[i].color = active;
                            }
                            else
                            {
                                ActorImageSprites[i].color = notActive;
                            }
                        }
                    }
                } else {
                    cutNameText.text = "Narrator";
                    ActorImageSprites[i].color = noAlpha;
                }
            } catch (System.IndexOutOfRangeException){
                ActorImageSprites[i].gameObject.SetActive(false);
            }
        }
    }
}
