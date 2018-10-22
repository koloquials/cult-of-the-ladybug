using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA2 : Enemy {

	// Use this for initialization
	void Start () {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[JERRY]\n";

        dialogue.Add("\n“SHE IS A GENTLE ANGEL AND YOU MADE HER CRY!”");

        dialogue.Add("[DUEL:START]\n");
        options.Add(" It’s all my fault, I’m sorry.\n");
        options.Add("I didn’t mean to, it just happened.\n");
        options.Add("She didn’t answer my questions, so I made her cry!\n");
        options.Add("She sucks and you suck.\n");
        dialogue.Add("\"What could be so damn important that you’d go so far?\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"What could be so damn important that you’d go so far?\"\n");
        options.Add("I’m sorry, I went too far.\n");
        options.Add("Um, a guy got murdered.\n");
        options.Add("WE ARE SURROUNDED BY DEATH\n");
        options.Add("Yo mamma.\n");
        dialogue.Add("\"You’re gonna answer my questions now. Or else.\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"You’re gonna answer my questions now. Or else.\"\n");
        options.Add("Please don’t hurt me.\n");
        options.Add("Uh, no.\n");
        options.Add("You answer me, dangit!\n");
        options.Add("Hell no, asshole!\n");
        dialogue.Add("\"GRRRRR\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"GRRRRR\"\n");
        options.Add("AH! Don’t hurt me please!\n");
        options.Add("rawr\n");
        options.Add("Talk like a person and tell me some answers!\n");
        options.Add("You sound zoo animal  and ya smell like one too.\n");
        dialogue.Add("\"You are literally the most annoying person here.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"You are literally the most annoying person here.\"\n");
        options.Add("I know. I suck.\n");
        options.Add("Maybe.\n");
        options.Add("TELL ME WHAT I WANT TO KNOW\n");
        options.Add("I know you are but what am I?\n");
        dialogue.Add("\"I don’t even know what you want me to tell you, asshole.\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"I don’t even know what you want me to tell you, asshole.\"\n");
        options.Add("Um...how did you know, um…the host? You don’t have to say. Please don’t hurt me Scary Jerry.\n");
        options.Add("Not much. Were you close with the host?  No pressure.\n");
        options.Add("HOW DO YOU KNOW THE HOST?\n");
        options.Add("Fuck you.\n");//here is where the script ends
        dialogue.Add("\"FUCK OFF ALREADY!!!\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
