using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marino : Enemy {

	// Use this for initialization
	void Start ()
    {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "Marino\n";

        dialogue.Add("\n“Slow your roll, kid. I guarantee you I had nothing to do with this.”");

        dialogue.Add("[DUEL:START]\n");
        options.Add("Why do you say that?\n");
        options.Add("You slow yours, I haven’t even gotten started yet.\n");
        options.Add("My roll is perfectly slow, thank you very much!\n");
        options.Add("I’m willing to bet good money that’s not true.\n");
        dialogue.Add("\"Wait, are you saying you haven’t heard of me? Marino, Marino Montemarano? “The Vine”?\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"Wait, are you saying you haven’t heard of me? Marino, Marino Montemarano? “The Vine”?\"\n");
        options.Add("Can’t say I have. Should I?\n");
        options.Add("What, are you a famous vineyard guy?\n");
        options.Add("Not a word.\n");
        options.Add("Well you are clearly an acquaintance of our late host.\n");
        dialogue.Add("\"Oh! This is...it’s great! My past isn’t all too pleasant, or important considering our current circumstances.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"Oh! This is...it’s great! My past isn’t all too pleasant, or important considering our current circumstances.\"\n");
        options.Add("You never know, in my line of work anything and everything can be a clue.\n");
        options.Add("I wouldn’t say great, a man is dead and I have zero answers.\n");
        options.Add("Something you don’t want me to know?\n");
        options.Add("Pleasant or not, it could be helpful.\n");
        dialogue.Add("\"It isn’t something I am very comfortable discussing, especially not with strangers.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\It isn’t something I am very comfortable discussing, especially not with strangers.\"\n");
        options.Add("I understand, but if it can help with this case.\n");
        options.Add("Then you better get comfortable, because I want to know.\n");
        options.Add("Don’t think of me as a stranger, then! Pretend we’re best friends and it’ll be easy.\n");
        options.Add("It doesn’t look like we have time to get to know each other, with a killer on the loose.\n");
        dialogue.Add("\"This ‘case’? You are a cop, and you haven’t heard of me?\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"This ‘case’? You are a cop, and you haven’t heard of me?\"\n");
        options.Add("I’m a private detective and there is a dead body, so I am calling this a homicide case. Why should I have heard of you?\n");
        options.Add("I’m not a cop and I haven’t heard of you, can we move on?\n");
        options.Add("Well, not an official case, but still important.\n");
        options.Add("Maybe you can tell me who you are, then I’ll know.\n");
        dialogue.Add("\"I...used to be on the wrong side of the law. But I swear to god I had nothing to do with this!\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"I...used to be on the wrong side of the law. But I swear to god I had nothing to do with this!\"\n");
        options.Add("The wrong side of the law? What did you do?\n");
        options.Add("Prove it!\n");
        options.Add("You’re a criminal? A murderer, maybe?\n");
        options.Add("Be careful don’t take the lord’s name in vain.\n");//here is where the script ends
        dialogue.Add("\"I...used to be on the wrong side of the law. But I swear to god I had nothing to do with this!\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.
    }

    // Update is called once per frame
    void Update () {
		
	}
}
