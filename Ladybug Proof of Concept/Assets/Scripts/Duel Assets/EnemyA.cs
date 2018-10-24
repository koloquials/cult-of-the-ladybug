using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy {

	// Use this for initialization
	void Start () {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[JERRY]\n";

        dialogue.Add("\n“Like hell I’m tellin ya anything, ya nosey jerkwad!”");

        dialogue.Add("[DUEL:START]\n");
        options.Add("Sorry...I didn’t mean to offend you.\n");
        options.Add("Chill bro\n");
        options.Add("Heck yea I do, and you’re gonna tell me!\n");
        options.Add("Who you callin a jerkwad, toadface?!\n");
        dialogue.Add("\"Who do you think you are, anyway? Sherlock Holmes?\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"Who do you think you are, anyway? Sherlock Holmes?\"\n");
        options.Add("No...I usually can’t even find my keys...\n");
        options.Add("I’m just another bro, livin their truth.\n");
        options.Add("I’m the goddamn boss!\n");
        options.Add(" And who are you supposed to be, the douche-y HULK?\n");
        dialogue.Add("\"If you keep buggin me, I swear there’s gonna be another murder here tonight.\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"If you keep buggin me, I swear there’s gonna be another murder here tonight.\"\n");
        options.Add("Oh god, please don’t kill me.\n");
        options.Add("Take a breath dude-bro.\n");
        options.Add("Yeah and it’s gonna be you if you keep being so difficult.\n");
        options.Add("Fuck you.\n");
        dialogue.Add("\"I do not like you, little weirdo.\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"I do not like you, little weirdo.\"\n");
        options.Add("I’m average height, I’m not that little...\n");
        options.Add("You don’t have to like me to talk to me.\n");
        options.Add("Tell me who you are!\n");
        options.Add("Well I hate you, so there!\n");
        dialogue.Add("\"I ain’t a snitch, and I ain’t talkin’ to you!\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"I ain’t a snitch, and I ain’t talkin’ to you!\"\n");
        options.Add("Snitches do get stitches after all, so I understand. \n");
        options.Add("I’m not a cop or anything, though.\n");
        options.Add("TALK TO ME!\n");
        options.Add("I’ll give you your stitches, you jerk.\n");
        dialogue.Add("\"FUCK OFF ALREADY!!!\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"FUCK OFF ALREADY!!!\"\n");
        options.Add("(Whimper like a puppy) \n");
        options.Add("Ummm, okay then.\n");
        options.Add("GRAAAAAAAHHHH!!!\n");
        options.Add("NO, YOU FUCK OFF!\n");//here is where the script ends
        dialogue.Add("\"FUCK OFF ALREADY!!!\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.
    }

    // Update is called once per frame
    void Update () {
		
	}
}
