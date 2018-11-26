using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {

    [Header("Dialogue Information")]
    public DialogueTree treeToLoad;
    public DialogueTree informationReward, lossTree;

    [Header ("Duel Information")]
    public DuelManager thisDuelManager;
    public int newDuelId;
    //public bool canDuel = false;
    public bool npcCanDuel = false;
    public bool npcBeaten = false;
    public Clue clueNeededToDuel;
    List<UnlockableInfo> unlocked;

    public NpcTemplate npcInfo;

    public bool AngryAtPlayer = false;
    public enum Attitude {
        AngryIfLose, AngryIfWin, Neutral, AngryIfOthersLose, AlwaysAngry
    }
    public Attitude attitude;
    public VariableStorage variables;
    PlayerMove player;

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

        SetDefaultDossier();
    }

    public virtual void Update()
    {
        if (clueNeededToDuel == null)
        {
            npcCanDuel = true;
        }
        else
        {
            ManageDuels();
        }
        if(!npcBeaten && !npcCanDuel){
            treeToLoad = npcInfo.possibleTrees[0];
        }
        if(npcCanDuel && !npcBeaten){
            treeToLoad = npcInfo.possibleTrees[1];
        }
        if(npcBeaten){
            treeToLoad = npcInfo.possibleTrees[2];
        }

        try{
            thisDuelManager = GetComponent<DuelManager>();
            CheckForPlayer();
            ManageDossierInformation();
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

    void ManageDuels(){
        if(variables.clueList.Contains(clueNeededToDuel)){
            npcCanDuel = true;
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

    Color[] unlockAlpha = new Color[3];

    [System.Serializable]
    public struct DossierUnlockable {
        public GameObject unlockObject;
        public bool unlocked;
    }

    [System.Serializable]
    public struct RelationshipUnlockable{
        public Image closeup;
        public bool unlocked;
    }

    DossierUnlockable[] dossierUnlockables = new DossierUnlockable[3];
    RelationshipUnlockable[] relationShipUnlockables = new RelationshipUnlockable[3];
    List<Clue.DossierEntry> currentDossierEntries = new List<Clue.DossierEntry>(3);
    List<Clue.HiddenRelationship> currentRelationshipEntries = new List<Clue.HiddenRelationship>(3);

    void ManageDossierInformation(){
        GameObject dossier = npcCanvas.gameObject.transform.Find("Dossier").gameObject;
        dossier.transform.Find("NameText").GetComponent<Text>().text = npcInfo.npcName;
        dossier.transform.Find("Closeup").GetComponent<Image>().sprite = npcInfo.dossierCloseup;
        dossier.transform.Find("DescriptionText").GetComponent<Text>().text = npcInfo.description;
        currentDossierEntries.Capacity = 3;
        currentRelationshipEntries.Capacity = 3;
        try
        {
            foreach (var c in variables.clueList)
            {
                for (int j = 0; j < c.dossierEntries.Length; j++)
                {
                    if(c.dossierEntries[j].personInQuestion==npcInfo && !currentDossierEntries.Contains(c.dossierEntries[j])){
                        currentDossierEntries.Add(c.dossierEntries[j]);
                    }
                }

                for (int l = 0; l < c.relationshipsToDisclose.Length; l++){
                    if(c.relationshipsToDisclose[l].personInQuestion == npcInfo && !currentRelationshipEntries.Contains(c.relationshipsToDisclose[l])){
                        currentRelationshipEntries.Add(c.relationshipsToDisclose[l]);
                    }
                }
            }
        } catch (System.NullReferenceException){}

        for (int i = 0; i < dossierUnlockables.Length; i++){
            dossierUnlockables[i].unlockObject = dossier.transform.Find("Unlockables").gameObject.transform.GetChild(i).gameObject;
            try
            {
                if (!dossierUnlockables[i].unlocked)
                {
                    foreach (var e in currentDossierEntries)
                    {
                        if (currentDossierEntries.IndexOf(e) == i)
                        {
                            dossierUnlockables[i].unlocked = true;
                            unlockAlpha[i].a = 0f;
                            dossierUnlockables[i].unlockObject.transform.GetChild(0).GetComponent<Text>().text = e.dossierEntry;
                        }
                    }
                }

                dossierUnlockables[i].unlockObject.GetComponent<Image>().color = unlockAlpha[i];
            } catch(System.IndexOutOfRangeException){
                
            }
        }

        for (int k = 0; k < relationShipUnlockables.Length; k++){
            relationShipUnlockables[k].closeup = dossier.transform.Find("Relationships").gameObject.transform.GetChild(k).GetComponent<Image>();
            try{
                if(!relationShipUnlockables[k].unlocked){
                    foreach(var r in currentRelationshipEntries){
                        if(currentRelationshipEntries.IndexOf(r)==k){
                            relationShipUnlockables[k].unlocked = true;
                            relationShipUnlockables[k].closeup.sprite = r.hasRelationshipWith.dossierCloseup;
                        }
                    }
                }
            } catch (System.IndexOutOfRangeException){}
        }
    }

    void SetDefaultDossier(){
        GameObject dossier = npcCanvas.gameObject.transform.Find("Dossier").gameObject;

        for (int i = 0; i < dossierUnlockables.Length; i++){
            dossierUnlockables[i].unlockObject = dossier.transform.Find("Unlockables").gameObject.transform.GetChild(i).gameObject;
            dossierUnlockables[i].unlockObject.transform.GetChild(0).GetComponent<Text>().text = "";
            unlockAlpha[i].a = 1f;
            unlockAlpha[i].r = 1f; unlockAlpha[i].g = 1f; unlockAlpha[i].b = 1f; 
            dossierUnlockables[i].unlockObject.GetComponent<Image>().color = unlockAlpha[i];
        }


    }
}
