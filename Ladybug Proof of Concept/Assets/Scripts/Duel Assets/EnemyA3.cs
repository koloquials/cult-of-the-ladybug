using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA3 : Enemy {

	// Use this for initialization
	void Start () {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[JERRY]\n";

        dialogue.Add("\n“Good Lord, I already answered your question!”");

        dialogue.Add("[DUEL:START]\n");
        options.Add("Yes, you did. Now I have another.\n");
        options.Add("Investigations tend to have more than a couple questions involved.\n");
        options.Add("I need to know more to compile a solid case.\n");
        options.Add("And I sense there is more you can tell me.\n");
        dialogue.Add("\"I don’t know what else to tell you.\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"I don’t know what else to tell you.\"\n");
        options.Add("\n");
        options.Add("\n");
        options.Add("\n");
        options.Add("\n");
        dialogue.Add("\"Where I was? Are you implying I am a suspect?!\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"Where I was? Are you implying I am a suspect?!\"\n");
        options.Add("\n");
        options.Add("I’m not trying to imply anything.\n");
        options.Add("\n");
        options.Add("\n");
        dialogue.Add("\"You are a goddamn piece of work!\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"You are a goddamn piece of work!\"\n");
        options.Add("\n");
        options.Add("\n");
        options.Add("\n");
        options.Add("\n");
        dialogue.Add("\"I cannot BELIEVE this! GOD DAMN THIS STUPID PARTY!\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"I cannot BELIEVE this! GOD DAMN THIS STUPID PARTY!\"\n");
        options.Add("\n");
        options.Add("\n");
        options.Add("\n");
        options.Add("\n");
        dialogue.Add("\"GRAAAAAAHHHHHH\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"GRAAAAAAHHHHHH\"\n");
        options.Add("\n");
        options.Add("\n");
        options.Add("\n");
        options.Add("\n");//here is where the script ends
        dialogue.Add("\"\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
