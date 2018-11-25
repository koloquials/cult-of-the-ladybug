﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableStorage : MonoBehaviour {

    public bool infoOne, infoTwo, infoThree, infoFour, infoFive, infoSix;
    public List<string> informationList = new List<string>();
    public List<UnlockableInfo> unlockables;

    public Clue[] clueDataBase;


    public List<Clue> clueList = new List<Clue>();

    public bool infoDisp = false;

    private void Start()
    {
        unlockables = new List<UnlockableInfo>(FindObjectsOfType<UnlockableInfo>());
    }

    private void Update()
    {
        
    }

    public void AddInfo(string toAdd, DialogueNode node){
        if(!informationList.Contains(toAdd)){
            foreach(var u in unlockables){
                if(u.thisInfo == node.informationIndex){
                    informationList.Add(toAdd);
                    u.informationToDisplay = toAdd;
                    u.clueDisplay = node.ClueTitle;
                }
            }
        }
    }

    public void DiscoverClue(DialogueNode node){
        if(node.clueDiscovered!=null){
            if(!clueList.Contains(node.clueDiscovered)){
                clueList.Add(node.clueDiscovered);
                Dropdown.OptionData newOption = new Dropdown.OptionData();
                newOption.text = node.clueDiscovered.accuseMenuDropdown;
                var accuse = FindObjectOfType<AccuseMenuManager>();
                for (int i = 0; i < accuse.clueDropdowns.Length;i++){
                    accuse.clueDropdowns[i].options.Add(newOption);
                }
            }
        }
    }
}
