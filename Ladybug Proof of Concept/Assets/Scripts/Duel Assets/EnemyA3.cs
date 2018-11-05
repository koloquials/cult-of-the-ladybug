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
        options.Add("I could have been clearer with you. where were you earlier?\n");
        options.Add("Tell me the truth, where were you?\n");
        options.Add("Can you tell me your whereabouts at the time of death?\n");
        options.Add("How about where you were at the time of the murder?\n");
        dialogue.Add("\"Where I was? Are you implying I am a suspect?!\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"Where I was? Are you implying I am a suspect?!\"\n");
        options.Add("No! I'm trying to get to the bottom of this dreadful business.\n");
        options.Add("I’m not trying to imply anything.\n");
        options.Add("I need to know more before I make any decisions, so tell me more.\n");
        options.Add("Maybe I am, it depends on what you say next.\n");
        dialogue.Add("\"You are a goddamn piece of work!\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"You are a goddamn piece of work!\"\n");
        options.Add("I'll give you that, in return maybe you can give me your whereabouts.\n");
        options.Add("I am a detective! And I will investigate until I reach a conclusion!\n");
        options.Add("I am going to get to the goddamn truth in all this!\n");
        options.Add("It doesn't matter what I am! What matters is what you are: innocent or guilty?\n");
        dialogue.Add("\"I cannot BELIEVE this! TO HELL WITH THIS STUPID PARTY!\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"I cannot BELIEVE this! TO HELL WITH THIS STUPID PARTY!\"\n");
        options.Add("This party has gone to shit, what with the corpse.\n");
        options.Add("You need to calm down and answer my question.\n");
        options.Add("Believe that I will get the truth out of you!\n");
        options.Add("The host of this stupid party IS IN HELL, where were you when he left?\n");
        dialogue.Add("\"ENOUGH! ENOUGH OF THESE QUESTIONS!\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"ENOUGH! ENOUGH OF THESE QUESTIONS!\"\n");
        options.Add("If you can answer my question of your whereabouts, that will be enough.\n");
        options.Add("I'm a detective, 'enough questions' isn't in my vocabulary.\n");
        options.Add("Your friend is dead. Look at him, and tell me where your were!\n");
        options.Add("Enough frantic deflection! Where were you when your friend died?!\n");//here is where the script ends
        dialogue.Add("\"ENOUGH! ENOUGH OF THESE QUESTIONS!\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
