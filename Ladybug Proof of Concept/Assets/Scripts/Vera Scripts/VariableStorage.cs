using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableStorage : MonoBehaviour {

    public bool infoOne, infoTwo, infoThree, infoFour, infoFive, infoSix;
    public List<string> informationList = new List<string>();
    public List<string> informationTitles = new List<string>();
    public List<UnlockableInfo> unlockables;

    public bool infoDisp = false;

    private void Start()
    {
        unlockables = new List<UnlockableInfo>(FindObjectsOfType<UnlockableInfo>());
    }

    public void AddInfo(string toAdd, DialogueNode node){
        if(!informationList.Contains(toAdd)){
            foreach(var u in unlockables){
                if(u.thisInfo == node.informationIndex){
                    informationList.Add(toAdd);
                    informationTitles.Add(node.nodeName);
                   // u.textInfo.text = toAdd;
                }
            }
        }
    }
}
