using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccuseMenuManager : MonoBehaviour {

    DialogueManager dialogueManager;

    public NpcTemplate culprit;
    public GameObject accuseMenu;

    public int culpritIndex;

    [System.Serializable]
    public struct AccuseButton{
        
        public NpcTemplate thisNpc;
        public Button accusalButton;
    }

    public AccuseButton[] accuseButtons;

    List<NPC> npcList;
    NPC[] tempArray;

    private void Start()
    {
        npcList = new List<NPC>(FindObjectsOfType<NPC>());
        dialogueManager = GetComponent<DialogueManager>();
        accuseMenu.SetActive(false);
        tempArray = npcList.ToArray();

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
            accuseButtons[i].accusalButton.GetComponent<Image>().sprite = tempArray[i].npcInfo.npcSprites[0].thisSprite;
        }
    }

    public void ToggleMenu(GameObject menu){
        if (dialogueManager.currentGameState == DialogueManager.GameState.OverworldActive)
        {
            if(menu.activeSelf == false){
                menu.SetActive(true);
                dialogueManager.currentGameState = DialogueManager.GameState.MenuActive;
            }
        } else {
            if(menu.activeSelf){
                menu.SetActive(false);
                dialogueManager.currentGameState = DialogueManager.GameState.OverworldActive;
            }
        }
    }

    public void MoveMenu(GameObject menu)
    {
        if (dialogueManager.currentGameState == DialogueManager.GameState.OverworldActive)
        {
            dialogueManager.currentGameState = DialogueManager.GameState.MenuActive;
            menu.GetComponent<RectTransform>().localPosition = new Vector3((menu.GetComponent<RectTransform>().localPosition.x+500f),
                                                                           (menu.GetComponent<RectTransform>().localPosition.y),0f);
        }
        else
        {
            if (dialogueManager.currentGameState == DialogueManager.GameState.MenuActive)
            {
                dialogueManager.currentGameState = DialogueManager.GameState.OverworldActive;
                menu.GetComponent<RectTransform>().localPosition = new Vector3((menu.GetComponent<RectTransform>().localPosition.x - 500f),
                                                                               (menu.GetComponent<RectTransform>().localPosition.y), 0f);
                FindObjectOfType<VariableStorage>().infoDisp = false;
            }
        }
    }

    public void AccuseNPC(int i){
        if(i == culpritIndex){
            dialogueManager.currentGameState = DialogueManager.GameState.Win;
            Debug.Log("Win");
        } else {
            dialogueManager.currentGameState = DialogueManager.GameState.TimerOut;
            Debug.Log("Lose");
        }
    }

}
