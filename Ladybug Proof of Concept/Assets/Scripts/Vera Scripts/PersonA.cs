using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonA : NPC {

    public DialogueTree mainTree1, mainTree2, mainTree3;
    public DialogueTree loopTree1, loopTree2, loopTree3;
    public DialogueTree infoTreeWin1, infoTreeWin2, infoTreeWin3, infoTreeLose1, infoTreeLose2, infoTreeLose3;

    public override void Start () {
        base.Start();
	}

    public override void Update()
    {
        base.Update();

        //load tree 1 if info 1 is true
        if (!variables.infoOne && !(variables.infoTwo|| variables.infoThree || variables.infoFive))
        {

            treeToLoad = mainTree1;
            informationReward = UpdateInformation(infoTreeLose1, infoTreeWin1);

        }
        if (variables.infoOne && !(variables.infoTwo || variables.infoThree || variables.infoFive))
        {

            treeToLoad = loopTree1;
            informationReward = UpdateInformation(infoTreeLose1, infoTreeWin1);
        }
         if (!variables.infoThree && AngryAtPlayer)
        {

            treeToLoad = mainTree2;
            newDuelId = 1;
            informationReward = UpdateInformation(infoTreeLose2, infoTreeWin2);
           // Debug.Log("Case 3");

        }
        if (variables.infoTwo)
        {
            
           // Debug.Log("Case 4");
            treeToLoad = loopTree2;
            informationReward = UpdateInformation(infoTreeLose2, infoTreeWin2);

        }
        if (variables.infoThree && !(variables.infoTwo || variables.infoTwo || variables.infoFive))
        {
          //  Debug.Log("Case 5");
            treeToLoad = mainTree3;
            newDuelId = 2;
            informationReward = UpdateInformation(infoTreeLose3, infoTreeWin3);
        }
        if (variables.infoFive)
        {
            treeToLoad = loopTree3;
            informationReward = UpdateInformation(infoTreeLose3, infoTreeWin3);
        }

    }
}
