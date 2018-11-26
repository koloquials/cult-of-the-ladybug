using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marino : Enemy {

	// Use this for initialization
	void Start ()
    {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[MARINO]\n";

        dialogue.Add("\n“Slow your roll, kid. I guarantee you I had nothing to do with this.”");

        dialogue.Add("\"Slow your roll, kid. I guarantee you I had nothing to do with this.\"\n");
        options.Add("Hm. And I’m willing to bet good money you can't guarantee that.\n");
        options.Add("You slow yours. We can't prove anything yet.\n");
        options.Add("Okay, but no need to get snappy. I just want to work through some things.\n");
        options.Add("While you may be able to guarantee it, I'm not there yet. Help me prove your innocence.\n");
        dialogue.Add("\"So be it. With God as my witness, I swear my days as “The Vine” Montemarano are behind me.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"So be it. With God as my witness, I swear my days as “The Vine” Montemarano are behind me.\"\n");
        options.Add("Perhaps. Yet there has been a truly gruesome murder tonight. Characteristic of the trade, no?\n");
        options.Add("Who's to say these petty words are worth anything, can you back this up, mafioso?\n");
        options.Add("Ah, right. You were with the mob. If there is any correlation, it will help us all to speak up.\n");
        options.Add("Say that I trust you're here for other, decent reasons. Will you deny a possible connection, though?\n");
        dialogue.Add("\"You have to believe me when I say I'm a changed man. In what happened tonight, I did not play a part.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"You have to believe me when I say I'm a changed man. In what happened tonight, I did not play a part.\"\n");
        options.Add("Interesting. But habits are hard to shake. People don't often make a clean break from their pasts.\n");
        options.Add("But surely you would know some old buddies with a motive? Anything incriminating?\n");
        options.Add("Maybe so. What are you keeping hidden, then? Something you don’t to reveal?\n");
        options.Add("I understand, I do. Wouldn't it help you reach absolution to lend me what you know?\n");
        dialogue.Add("\"Mm. I'm here because of my ties to Theo, the victim. That's the part of my history that matters here.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"Mm. I'm here because of my ties to Theo, the victim. That's the part of my history that matters here.\"\n");
        options.Add("A good deflection! But let's get back on topic. You wanted something from our host, didn't you?\n");
        options.Add("Oddly cagey, but alright. You know something about our host? Any ancient enemies?\n");
        options.Add("You have to tell me what part of your history connects then. Come on, man.\n");
        options.Add("Please. It will be tough, but I need you to elaborate. For Theo's sake, if not the case.\n");
        dialogue.Add("\"I'm connected with the boy through family, but he's isn't the only reason I attend.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"I'm connected with the boy through family, but he's isn't the only reason I attend.\"\n");
        options.Add("But. Are you sure? Are you trying to obscure how you're connected to our victim?\n");
        options.Add("Is the other reason you attend to settle a score, pay off a residual debt?\n");
        options.Add("What else do you attend such a wild event for? Surely you are not a believer of the supernatural.\n");
        options.Add("It's alright to admit you aren't quite free of your criminal roots. Are you looking for liberation?\n");
        dialogue.Add("\"People come to these events seeking all kinds of things. I guess I'm looking for freedom, yeah.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"People come to these events seeking all kinds of things. I guess I'm looking for freedom, yeah.\"\n");
        options.Add("What does this have to do with the case, though? Can we get back on topic?\n");
        options.Add("Would the lord not be disappointed in what you've provided thus far? What else can you tell me?\n");
        options.Add("You've given me a lot, but I'm not sure it's enough, surely you aren't giving all you have to provide.\n");
        options.Add("I think you've helped, in whatever way you can. May they lead to that forgiveness you desire.\n");//here is where the script ends
        dialogue.Add("\"I'm just a man with a tired past. If you are finished, I ask that you leave me be.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"I'm just a man with a tired past. If you are finished, I ask that you leave me be.\"\n");
        options.Add("...\n");
        options.Add("we fucked up!!!");
        options.Add("...\n");
        options.Add("...\n");
        dialogue.Add("\"AAAAAAAA!\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.
    }

    // Update is called once per frame
    void Update () {
		
	}
}
