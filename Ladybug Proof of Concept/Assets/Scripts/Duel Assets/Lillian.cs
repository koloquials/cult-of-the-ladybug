using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lillian : Enemy {

	// Use this for initialization
	void Start ()
    {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[LILLIAN]\n";
        startPos = 4;

        dialogue.Add("\n“Oh, my! Please, I'm not sure my poor heart can take this at the moment. But what can I do for you?”");

        dialogue.Add("\n“[WE DIDN'T FINISH THIS INTERROGATION, JUST SELECT THE TAGGED ONES.] Oh, my! Please, I'm not sure my poor heart can take this at the moment. But what can I do for you?”");
        options.Add("From what I can tell, you’re just as suspicious as anyone here.\n");
        options.Add("Yes I am asking you questions, you are the only one left to ask.\n");
        options.Add("You bet your bottom dollar!\n");
        options.Add("[!]You must admit you are rather suspicious.\n");
        dialogue.Add("\"Have you even talked to what’s-his-name? The mafia guy, he’s scary!\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"Have you even talked to what’s-his-name? The mafia guy, he’s scary!\"\n");
        options.Add("His name is Marino “The Vine” Montemarano, and he’s quite kind. You though, are still up for debate.\n");
        options.Add("I have, and he’s haunted and harmless. What about you?\n");
        options.Add("Forget him I am talking to you now.\n");
        options.Add("[!]I came over here to question you.\n");
        dialogue.Add("\"Why, how could you think I am even involved in any of this?\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"Why, how could you think I am even involved in any of this?\"\n");
        options.Add("You and Theodore were rather close, and from what I hear he hadn’t done right by you.\n");
        options.Add("You were present when the lights went out and you were here, for one.\n");
        options.Add("We are all involved in this.\n");
        options.Add("[!]Gerald thinks you are very involved, and so does Moonchild.\n");
        dialogue.Add("\"I was rather fond of Theodore, we were together, you know.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"I was rather fond of Theodore, we were together, you know.\"\n");
        options.Add("Was he the one who got you into this seance business?\n");
        options.Add("Oh I am well aware, my dear.\n");
        options.Add("By together, you mean dating, right?\n");
        options.Add("[!]Gerald seems to think you were together because you were after his wealth.\n");
        dialogue.Add("\"He promised me that we would have fun together. I believed him, too, and for a while we did have fun, lots of it. Not anymore though, it seems.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"He promised me that we would have fun together. I believed him, too, and for a while we did have fun, lots of it. Not anymore though, it seems.\"\n");
        options.Add("Moonchild said as much, she said he was stringing you along with the whole seance business.\n");
        options.Add("I heard that the seances were fake, was the relationship fake as well?\n");
        options.Add("Sounds like his whole heart wasn’t in it.\n");
        options.Add("[!]So his promises ran thin and the fun went with it.\n");
        dialogue.Add("\"Well it sure felt that way. I only realized that too late though, I’ve wasted so much time chasing ghosts. No longer and never again!\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"Well it sure felt that way. I only realized that too late though, I’ve wasted so much time chasing ghosts. No longer and never again!\"\n");
        options.Add("You must’ve been upset with him for fooling you. How upset, I wonder?\n");
        options.Add("Glad this murder has gotten you motivated, at least.\n");
        options.Add("Good for you! Get back on that horse!\n");
        options.Add("[!]The ghosts were never there, according to Moonchild.\n");//here is where the script ends
        dialogue.Add("\"Well it sure felt that way. I only realized that too late though, I’ve wasted so much time chasing ghosts. No longer and never again!\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"...Are you satisfied with this ceaseless questioning? I have plenty on my mind as is.\"\n");
        options.Add("...\n");
        options.Add("we fucked up!!!");
        options.Add("...\n");
        options.Add("...\n");
        dialogue.Add("\"AAAAAAAA!\"\n");
        types.Add(4);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
