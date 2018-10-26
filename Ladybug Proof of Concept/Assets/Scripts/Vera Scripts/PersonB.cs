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

        if (!AngryAtPlayer)
        {

            treeToLoad = mainTree1;

        }
        else if (AngryAtPlayer)
        {

            treeToLoad = loopTree1;

        }
        else if ((variables.infoOne && variables.infoFour == false && !AngryAtPlayer) || (variables.infoTwo && !variables.infoFour))
        {

            treeToLoad = mainTree2;

        } else if((variables.infoOne && variables.infoFour == false && AngryAtPlayer) || (variables.infoTwo && !variables.infoFour)){

            treeToLoad = loopTree2;

        
        } else if(variables.infoFour){

            treeToLoad = mainTree3;

        } else if(variables.infoSix){

            treeToLoad = loopTree3;

        }
    }
}
