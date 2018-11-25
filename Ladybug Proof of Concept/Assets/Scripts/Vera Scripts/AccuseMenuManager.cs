using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccuseMenuManager : MonoBehaviour {

    DialogueManager dialogueManager;
    VariableStorage variableStorage;

    public NpcTemplate culprit;
    public GameObject accuseMenu;
    public Button openAccuseMenu;

    public int culpritIndex;
    int accuseIndex;

    public List<Clue> cluesNeededToAccuse;
    bool canAccuse = false;

    [System.Serializable]
    public struct AccuseButton{
        
        public NpcTemplate thisNpc;
        public Button accusalButton;
    }

    public Image accuseBacking;

    public Dropdown[] clueDropdowns;
    public List<Clue> correctClues = new List<Clue>();
    List<Clue> selectedClues = new List<Clue>();

    public AccuseButton[] accuseButtons;

    List<NPC> npcList;
    NPC[] tempArray;

    private void Start()
    {
        npcList = new List<NPC>(FindObjectsOfType<NPC>());
        dialogueManager = GetComponent<DialogueManager>();
        accuseMenu.SetActive(false);
        tempArray = npcList.ToArray();
        variableStorage = FindObjectOfType<VariableStorage>();

        for (int i = 0; i < tempArray.Length; i++)
        {
            int tempIndex = i;
            if (tempArray[i].npcInfo == culprit)
            {
                culpritIndex = i;
            }
            accuseButtons[i].thisNpc = tempArray[i].npcInfo;
            accuseButtons[i].accusalButton.onClick.AddListener(() => AccuseNPC(tempIndex));
            accuseButtons[i].accusalButton.gameObject.transform.GetChild(0).GetComponent<Text>().text = tempArray[i].npcInfo.npcName;
            accuseButtons[i].accusalButton.GetComponent<Image>().sprite = tempArray[i].npcInfo.dossierCloseup;

        }

        for (int j = 0; j < clueDropdowns.Length; j++)
        {
            clueDropdowns[j].ClearOptions();

        }

    }

    public void Update()
    {

        ManageAccuseUnlock();

        if(!canAccuse){
            openAccuseMenu.interactable = false;
        } else {
            openAccuseMenu.interactable = true;
        }

        try{
            for (int i = 0; i < clueDropdowns.Length; i++)
            {
                foreach (var op in clueDropdowns[i].options)
                {
                    if (op == null)
                    {
                        clueDropdowns[i].options.Remove(op);
                    }
                }
            }
        } catch (System.NullReferenceException){}

        for (int j = 0; j < accuseButtons.Length; j++){
            if(accuseIndex == j){
                accuseBacking.GetComponent<RectTransform>().localPosition = 
                    new Vector3(accuseButtons[j].accusalButton.GetComponent<RectTransform>().localPosition.x, 
                                accuseButtons[j].accusalButton.GetComponent<RectTransform>().localPosition.y, 0f);
            }
        }
    }

    List<Clue> unlockedClues = new List<Clue>();

    public void ManageAccuseUnlock(){
        List<Clue> currentClues = FindObjectOfType<VariableStorage>().clueList;
        foreach(var cl in currentClues){
            foreach(var c in cluesNeededToAccuse){
                if (c==cl && !unlockedClues.Contains(c)){
                    unlockedClues.Add(c);
                }
            }
        }

        if(unlockedClues.Count == cluesNeededToAccuse.Count){
            canAccuse = true;
        }
    }

    public void ToggleMenu(GameObject menu){
        if(menu.gameObject.tag == "MainMenu"){
            if(dialogueManager.currentGameState == DialogueManager.GameState.OverworldActive){
                if(!menu.activeSelf){
                    menu.SetActive(true);
                    dialogueManager.currentGameState = DialogueManager.GameState.MenuActive;
                } 
            } else
            {
                if (menu.activeSelf)
                {
                    menu.SetActive(false);
                    dialogueManager.currentGameState = DialogueManager.GameState.OverworldActive;
                }
            }
        } else {
            if(menu.activeSelf){
                menu.SetActive(false);
            } else {
                menu.SetActive(true);
            }
        }
    }

    public void MoveMenu(GameObject menu)
    {
        if (menu.GetComponent<RectTransform>().localPosition.x !=-506f)
        {
            menu.GetComponent<RectTransform>().localPosition = new Vector3((menu.GetComponent<RectTransform>().localPosition.x+2000f),
                                                                           (menu.GetComponent<RectTransform>().localPosition.y),0f);
        }
        else
        {
            if (dialogueManager.currentGameState == DialogueManager.GameState.MenuActive)
            {
                menu.GetComponent<RectTransform>().localPosition = new Vector3((menu.GetComponent<RectTransform>().localPosition.x - 2000f),
                                                                               (menu.GetComponent<RectTransform>().localPosition.y), 0f);
                FindObjectOfType<VariableStorage>().infoDisp = false;
            }
        }
    }


    public void AccuseNPC(int i){
        accuseIndex = i;
        print(accuseIndex);
    }

    public int numCorrect = 0;

    public void Validate(){
        selectedClues.Clear();
        numCorrect = 0;
        for (int i = 0; i < clueDropdowns.Length; i++)
        {
            try
            {
                for (int j = 0; j < variableStorage.clueDataBase.Length; j++){
                    if(string.Compare(clueDropdowns[i].captionText.text, variableStorage.clueDataBase[j].accuseMenuDropdown)==0){
                        selectedClues.Add(variableStorage.clueDataBase[j]);
                        print(variableStorage.clueDataBase[j].clueDescription);
                    }
                }
            } catch (System.IndexOutOfRangeException){}
        }
        if(selectedClues.Count == clueDropdowns.Length){
            if (Tally() && (accuseIndex==culpritIndex)){
                dialogueManager.currentGameState = DialogueManager.GameState.Win;
                Debug.Log("Win");
            } else {
                dialogueManager.currentGameState = DialogueManager.GameState.TimerOut;
                Debug.Log("Lose");
            }
        } else {
            return;
        }
    }

    bool Tally(){
        foreach(var c in selectedClues){
            if(correctClues.Contains(c)){
                numCorrect++;
            }
        }
        if(numCorrect == correctClues.Count){
            return true;
        } else {
            return false;
        }

    }

}
