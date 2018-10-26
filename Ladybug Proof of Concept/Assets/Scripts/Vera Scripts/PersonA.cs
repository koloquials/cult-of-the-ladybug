using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonA : NPC {

    public DialogueTree mainTree1, mainTree2, mainTree3;
    public DialogueTree loopTree1, loopTree2, loopTree3;

    public override void Start () {
        base.Start();
	}

    public override void Update()
    {
        base.Update();

        //load tree 1 if info 1 is true
        if (!variables.infoOne)
        {

            treeToLoad = mainTree1;

        }
        else if (variables.infoOne)
        {

            treeToLoad = loopTree1;

            //load tree 2 if info three is false and angry at player is true
        }
        else if (variables.infoThree != true && AngryAtPlayer)
        {

            treeToLoad = mainTree2;

        }
        else if (variables.infoTwo)
        {

            treeToLoad = loopTree2;

        }
        else if (variables.infoThree)
        {

            treeToLoad = mainTree3;
        }
        else if (variables.infoFive)
        {
            treeToLoad = loopTree3;
        }

    }
}
