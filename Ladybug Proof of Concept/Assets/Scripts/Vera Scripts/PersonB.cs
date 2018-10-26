using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonB : NPC {


    public DialogueTree mainTree1, mainTree2, mainTree3;
    public DialogueTree loopTree1, loopTree2, loopTree3;

    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        base.Update();

        if (!AngryAtPlayer && !(variables.infoOne || variables.infoSix || variables.infoFour))
        {
            Debug.Log("Case 1");
            treeToLoad = mainTree1;

        }

        if (AngryAtPlayer && !(variables.infoOne || variables.infoSix || variables.infoFour))
        {
            Debug.Log("Case 2");
            treeToLoad = loopTree1;

        }

        if (((variables.infoOne && !variables.infoFour  && !AngryAtPlayer) || (variables.infoTwo && !variables.infoFour)) && !variables.infoSix){

            Debug.Log("Case 3");
            treeToLoad = mainTree2;

        }
            
        if(((variables.infoOne && !variables.infoFour && AngryAtPlayer) || (variables.infoTwo && !variables.infoFour)) && !variables.infoSix){

            Debug.Log("Case 4");
            treeToLoad = loopTree2;

        
        } 

        if(variables.infoFour){

            Debug.Log("Case 5");
            treeToLoad = mainTree3;

        } 

        if(variables.infoSix){

            Debug.Log("Case 6");
            treeToLoad = loopTree3;

        }
    }
}
