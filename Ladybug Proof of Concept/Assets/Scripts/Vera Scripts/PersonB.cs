using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonB : NPC {


    public DialogueTree mainTree1, mainTree2, mainTree3;
    public DialogueTree loopTree1, loopTree2, loopTree3;
    public DialogueTree infoTreeWin1, infoTreeWin2, infoTreeWin3, infoTreeLose1, infoTreeLose2, infoTreeLose3;


    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        base.Update();

        if (!AngryAtPlayer && !(variables.infoOne || variables.infoSix || variables.infoFour))
        {
            //Debug.Log("Case 1");
            treeToLoad = mainTree1;
            informationReward = UpdateInformation(infoTreeLose1, infoTreeWin1);

        }

        if (AngryAtPlayer && !(variables.infoOne || variables.infoSix || variables.infoFour))
        {
           // Debug.Log("Case 2");
            treeToLoad = loopTree1;
            informationReward = UpdateInformation(infoTreeLose1, infoTreeWin1);

        }

        if (((variables.infoOne && !variables.infoFour  && !AngryAtPlayer) || (variables.infoTwo && !variables.infoFour)) && !variables.infoSix){

           // Debug.Log("Case 3");
            treeToLoad = mainTree2;
            newDuelId = 1;
            informationReward = UpdateInformation(infoTreeLose2, infoTreeWin2);
        }
            
        if(((variables.infoOne && !variables.infoFour && AngryAtPlayer) || (variables.infoTwo && !variables.infoFour)) && !variables.infoSix){

            //Debug.Log("Case 4");
            treeToLoad = loopTree2;
            informationReward = UpdateInformation(infoTreeLose2, infoTreeWin2);

        
        } 

        if(variables.infoFour){

           // Debug.Log("Case 5");
            treeToLoad = mainTree3;
            newDuelId = 2;
            informationReward = UpdateInformation(infoTreeLose3, infoTreeWin3);

        } 

        if(variables.infoSix){

           // Debug.Log("Case 6");
            treeToLoad = loopTree3;
            informationReward = UpdateInformation(infoTreeLose3, infoTreeWin3);

        }
    }
}
