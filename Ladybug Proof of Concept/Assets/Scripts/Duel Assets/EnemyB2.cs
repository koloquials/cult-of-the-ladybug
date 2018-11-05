using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB2 : Enemy {

	// Use this for initialization
	void Start () {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[MOONCHILD]\n";

        dialogue.Add("\n“AH! Interrupting is rude…”");

        dialogue.Add("[DUEL:START]\n");
        options.Add("Apologies, miss. But I have some questions to ask of you.\n");
        options.Add("Justice waits for no one!\n");
        options.Add("Now is not the time for manners, but answers.\n");
        options.Add("One must always be ready for the unexpected.\n");
        dialogue.Add("\"You have questions for me? I can’t imagine why.\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"You have questions for me? I can’t imagine why.\"\n");
        options.Add("Well, yes I do. I imagine all of this is hard to process.\n");
        options.Add("No need to imagine, merely speak the truth.\n");
        options.Add("Yes I do, several. But let’s start with names.\n");
        options.Add("A man life just ended in this room, something you need not imagine.\n");
        dialogue.Add("\"I did not expect such a verbal assault when I accepted the invitation to this event.\"\n");
        types.Add(1); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"I did not expect such a verbal assault when I accepted the invitation to this event.\"\n");
        options.Add("I mean no offense, I assure you.\n");
        options.Add("I must know more, so I can’t let manners hold me back.\n");
        options.Add("I am doing what is necessary to find justice for our late host.\n");
        options.Add("And our host didn’t expect a knife in his back. Tonight, we all suffer surprises.\n");
        dialogue.Add("\"I-I’m not sure what I can tell you...\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"I-I’m not sure what I can tell you...\"\n");
        options.Add("Anything you might think of as helpful, please.\n");
        options.Add("What is there to be unsure of?\n");
        options.Add("To start, tell me your name!\n");
        options.Add("Surely you know your own name, at least?\n");
        dialogue.Add("\"I-I, uh, well...I’m, uh...\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"I-I, uh, well...I’m, uh...\"\n");
        options.Add("Are you unwell, miss?\n");
        options.Add("Focus yourself, please.\n");
        options.Add("Please, your name, miss.\n");
        options.Add("There’s no need to be so flustered, I’ve only asked your name.\n");
        dialogue.Add("\"Please, leave me be. This is...too much for me to handle.\"\n");
        types.Add(1); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"Please, leave me be. This is...too much for me to handle.\"\n");
        options.Add("All of this is rather overwhelming.\n");
        options.Add("Though I’d like to, I can’t leave any stone unturned.\n");
        options.Add("I cannot, miss, this is too important.\n");
        options.Add("I’ve only asked your name, and I intend to ask more.\n");//here is where the script ends
        dialogue.Add("\"Please, leave me be. This is...too much for me to handle.\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.
    }

    // Update is called once per frame
    void Update () {
		
	}
}
