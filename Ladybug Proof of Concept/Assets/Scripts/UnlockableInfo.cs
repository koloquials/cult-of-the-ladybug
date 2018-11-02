using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockableInfo : MonoBehaviour {

    public DialogueNode.InformationIndex thisInfo;
    VariableStorage variableStorage;
    public bool unlocked = false;
    public Text textInfo;

    private void Start()
    {
        variableStorage = FindObjectOfType<VariableStorage>();
        textInfo = GetComponent<Text>();
    }

    private void Update()
    {
        switch (thisInfo)
        {
            case DialogueNode.InformationIndex.Node:
                break;
            case DialogueNode.InformationIndex.Info1:
                unlocked = variableStorage.infoOne;
                break;
            case DialogueNode.InformationIndex.Info2:
                unlocked = variableStorage.infoTwo;
                break;
            case DialogueNode.InformationIndex.Info3:
                unlocked = variableStorage.infoThree;
                break;
            case DialogueNode.InformationIndex.Info4:
                unlocked = variableStorage.infoFour;
                break;
            case DialogueNode.InformationIndex.Info5:
                unlocked = variableStorage.infoFive;
                break;
            case DialogueNode.InformationIndex.Info6:
                unlocked = variableStorage.infoSix;
                break;
        }
        if(!unlocked){
            textInfo.text = "???";
        }
    }
}
