using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableStorage : MonoBehaviour {

    public bool infoOne, infoTwo, infoThree, infoFour, infoFive, infoSix;
    public List<string> informationList = new List<string>();
    public List<UnlockableInfo> unlockables;

    private void Start()
    {
        unlockables = new List<UnlockableInfo>(FindObjectsOfType<UnlockableInfo>());
    }

    public void AddInfo(string toAdd, DialogueNode.InformationIndex index){
        if(!informationList.Contains(toAdd)){
            foreach(var u in unlockables){
                if(u.thisInfo == index){
                    informationList.Add(toAdd);
                    u.textInfo.text = toAdd;
                }
            }
        }
    }
}
