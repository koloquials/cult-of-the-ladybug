using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockableInfo : MonoBehaviour {

    public DialogueNode.InformationIndex thisInfo;
    VariableStorage variableStorage;
    public bool unlocked = false;
    public Text textInfo;
    public Button openInfo;
    Text buttonText;

    int index;

    private void Start()
    {
        variableStorage = FindObjectOfType<VariableStorage>();
        textInfo.text = null;
        buttonText = openInfo.gameObject.transform.FindChild("Text").GetComponent<Text>();
        openInfo.onClick.AddListener(OnClickRevelInfo);
    }

    private void Update()
    {
        switch (thisInfo)
        {
            case DialogueNode.InformationIndex.Node:
                break;
            case DialogueNode.InformationIndex.Info1:
                unlocked = variableStorage.infoOne;
                index = 1;
                break;
            case DialogueNode.InformationIndex.Info2:
                unlocked = variableStorage.infoTwo;
                index = 2;
                break;
            case DialogueNode.InformationIndex.Info3:
                unlocked = variableStorage.infoThree;
                index = 3;
                break;
            case DialogueNode.InformationIndex.Info4:
                index = 4;
                unlocked = variableStorage.infoFour;
                break;
            case DialogueNode.InformationIndex.Info5:
                unlocked = variableStorage.infoFive;
                index = 5;
                break;
            case DialogueNode.InformationIndex.Info6:
                unlocked = variableStorage.infoSix;
                index = 6;
                break;
        }
        if(!unlocked){
            //textInfo.text = "???";
            buttonText.text = "???";
            openInfo.interactable = false;
        } else {
            string[] temp = variableStorage.informationTitles.ToArray();
            buttonText.text = "Info " + index;
            openInfo.interactable = true;
        }
    }

    public void OnClickRevelInfo(){
        if(variableStorage.infoDisp == false){
            textInfo.text = null;
            variableStorage.infoDisp = true;
            string[] temp = variableStorage.informationList.ToArray();
            textInfo.text = temp[index - 1];
        } else {
            variableStorage.infoDisp = false;
            textInfo.text = null;
        }

    }
}
