using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {

    public DialogueTree treeToLoad;
    public DialogueTree informationReward, lossTree;
    public DuelManager thisDuelManager;
    public PlayerMove player;

    public int newDuelId;

    public bool canDuel = true;
    public List<DialogueNode.InformationIndex> informationIndices;
    List<UnlockableInfo> unlocked;

    public NpcTemplate npcInfo;

    public bool AngryAtPlayer = false;
    public enum Attitude {
        AngryIfLose, AngryIfWin, Neutral, AngryIfOthersLose, AlwaysAngry
    }
    public Attitude attitude;
    public VariableStorage variables;

    public List<NPC> otherNPC;
    public Canvas npcCanvas;

    public enum NPCStatus{
        Neutral, Heated
    }
    public NPCStatus currentStatus;
    float heatedTimer;

    [HideInInspector]
    public GameObject interactionIcon, heatedIcon;

    DialogueManager dialogue;

    public virtual void Start()
    {
        informationIndices = new List<DialogueNode.InformationIndex>();
        unlocked = new List<UnlockableInfo>(FindObjectsOfType<UnlockableInfo>());
        variables = FindObjectOfType<VariableStorage>();
        interactionIcon = this.gameObject.transform.Find("InteractionIcon").gameObject;
        heatedIcon = this.gameObject.transform.Find("HeatedIcon").gameObject;
        npcCanvas = gameObject.transform.Find("npcCanvas").GetComponent<Canvas>();
        npcCanvas.gameObject.SetActive(false);
        interactionIcon.SetActive(false);
        otherNPC = new List<NPC>(FindObjectsOfType<NPC>());
        otherNPC.Remove(this);
        currentStatus = NPCStatus.Neutral;
        player = FindObjectOfType<PlayerMove>();

        dialogue = FindObjectOfType<DialogueManager>();
    }

    public virtual void Update()
    {
        try{
            thisDuelManager = GetComponent<DuelManager>();
            CheckForPlayer();
            PopulateDossier();
            LockDuel();
            switch (attitude){
                case Attitude.AngryIfLose:
                    if(thisDuelManager.playerWin){
                        AngryAtPlayer = true;
                    }
                    break;
                case Attitude.AngryIfWin:
                    if(thisDuelManager.playerLose){
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

           
                thisDuelManager.enemyId = newDuelId;


        } catch (System.NullReferenceException){}

        switch(currentStatus){
            case NPCStatus.Neutral:
                heatedTimer = 10f;
                heatedIcon.gameObject.SetActive(false);
                break;

            case NPCStatus.Heated:
                heatedTimer -= Time.deltaTime;
                heatedIcon.gameObject.SetActive(true);
                Color heat = heatedIcon.GetComponent<SpriteRenderer>().color;
                heat.a = heatedTimer/10f;
                heatedIcon.GetComponent<SpriteRenderer>().color = heat;
                if(heatedTimer <=0f){
                    currentStatus = NPCStatus.Neutral;
                }
                break;
        }
    }


    void LockDuel(){
        foreach(var ind in informationIndices){
            foreach(var u in unlocked){
                if(ind == u.thisInfo && !u.unlocked){
                    canDuel = false;
                } else if(ind == u.thisInfo && u.unlocked){
                    canDuel = true;
                }
            }
        }
    }

    void CheckForPlayer()
    {
        CameraControl camera = FindObjectOfType<CameraControl>();

        if((player.gameObject.transform.position - transform.position).magnitude <= player.interactionRadius && currentStatus!= NPCStatus.Heated){
            interactionIcon.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)){
                if(dialogue.currentGameState == DialogueManager.GameState.OverworldActive && !npcCanvas.gameObject.active){
                    npcCanvas.gameObject.SetActive(true);
                    dialogue.currentGameState = DialogueManager.GameState.DossierActive;
                } else if(dialogue.currentGameState == DialogueManager.GameState.DossierActive && npcCanvas.gameObject.active){
                    npcCanvas.gameObject.SetActive(false);
                    dialogue.currentGameState = DialogueManager.GameState.OverworldActive;
                }
            }
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

    public void UpdateInformation(DialogueTree loseTree, DialogueTree winTree){
        try
        {
            if (thisDuelManager.playerLose)
            {
                informationReward = loseTree;
            } else if(thisDuelManager.playerWin){
                informationReward = winTree;
            }

        }
        catch (System.NullReferenceException) {  }
    }


    int relIndex = 0;
    bool relationshipDisclosed = false;
    void PopulateDossier(){
        GameObject dossier = npcCanvas.gameObject.transform.Find("Dossier").gameObject;
        dossier.transform.Find("NameText").GetComponent<Text>().text = npcInfo.npcName;
        dossier.transform.Find("Closeup").GetComponent<Image>().sprite = npcInfo.dossierCloseup;
        dossier.transform.Find("DescriptionText").GetComponent<Text>().text = npcInfo.description;
        dossier.transform.Find("Disclose").gameObject.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(OnClickDiscloseFalse);
        Button[] relationships = new Button [3];
        for (int i = 0; i < relationships.Length;i++){
            int tempIndex = i;
            relationships[i] = dossier.transform.Find("RelationshipButtons").transform.GetChild(i).GetComponent<Button>();
            relationships[i].onClick.AddListener(() => OnClickDiscloseRelationship(tempIndex));;
            if (!relationshipDisclosed)
            {
                dossier.transform.Find("Disclose").gameObject.SetActive(false);
                dossier.transform.Find("RelationshipText").GetComponent<Text>().text = null;
            }
            else
            {
                dossier.transform.Find("Disclose").gameObject.SetActive(true);
                dossier.transform.Find("RelationshipText").GetComponent<Text>().text = npcInfo.npcRelationships[relIndex].relationshipDescription;

            }
            try{
                relationships[i].transform.Find("Text").GetComponent<Text>().text = npcInfo.npcRelationships[i].person.npcName;
            } catch(System.IndexOutOfRangeException){}
        }

        if(dialogue.currentGameState != DialogueManager.GameState.DossierActive){
            relationshipDisclosed = false;
        }
    }

    void OnClickDiscloseRelationship(int i){
        if (!relationshipDisclosed)
        {
            relationshipDisclosed = true;
        }
        relIndex = i;
        
    }

    void OnClickDiscloseFalse(){
        relationshipDisclosed = false;
    }
}
