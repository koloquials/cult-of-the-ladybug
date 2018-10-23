using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB3 : Enemy {

	// Use this for initialization
	void Start () {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[MOONCHILD]\n";

        dialogue.Add("\n“Let’s see...I know we had a couple drinks...”");

        dialogue.Add("[DUEL:START]\n");
        options.Add("Drinks are nice...\n");
        options.Add("Cool, so what about the murder?\n");
        options.Add("I want to know your whereabouts at the time of the crime, not your drink choice\n");
        options.Add("Don’t screw with me!\n");
        dialogue.Add("\"Then, um, Jerry said he had to go to the bathroom. I didn’t see him for a while after that… not sure where he went...\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"Then, um, Jerry said he had to go to the bathroom. I didn’t see him for a while after that… not sure where he went...\"\n");
        options.Add("Sorry, but, um, where were you?\n");
        options.Add("Okay, so no Jerry. What about Moonchild?\n");
        options.Add("Where were YOU?!\n");
        options.Add("You’re just Jerry’s little keeper then, huh? Pathetic.\n");
        dialogue.Add("\"Listen, you shouldn’t even bother with this whole thing. The host isn’t a guy worth your time and effort.\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"Listen, you shouldn’t even bother with this whole thing. The host isn’t a guy worth your time and effort..\"\n");
        options.Add("Sorry, what?\n");
        options.Add("Oh okay, but I’m still curious.\n");
        options.Add("Don’t care! Tell me where you were!\n");
        options.Add("Don’t try and distract me, you little shit!\n");
        dialogue.Add("\"The guy was an asshole. Sure they were Jerry’s friend, but they were the living worst!\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"The guy was an asshole. Sure they were Jerry’s friend, but they were the living worst!\"\n");
        options.Add("They were that bad?\n");
        options.Add("I’m sure they weren’t that bad.\n");
        options.Add("I still don’t care! I will figure this out!\n");
        options.Add("What-the-fuck-ever!\n");
        dialogue.Add("\"I mean, you could ask anyone here, whoever they didn’t alienate, the host ruined. They ruined their businesses and lives with their single-minded ambition!\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"I mean, you could ask anyone here, whoever they didn’t alienate, the host ruined. They ruined their businesses and lives with their single-minded ambition!\"\n");
        options.Add("Gee, that is pretty awful.\n");
        options.Add("This is still a murder, though.\n");
        options.Add("JUST TELL ME WHERE YOU WERE!\n");
        options.Add("Takes a real piece of shit to speak ill of the recently murdered.\n");
        dialogue.Add("\"It’s their fault our shop shut down! And that jerk had the gaul to have a party and invite us right after.\"\n");
        types.Add(1); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"It’s their fault our shop shut down! And that jerk had the gaul to have a party and invite us right after.\"\n");
        options.Add("Um, you still haven’t told me where you were at the time of the murder.\n");
        options.Add("That sucks and all, but you still haven’t really answered my question.\n");
        options.Add("WHERE WERE YOU JERI???\n");
        options.Add("Oh boo hoo, woe is you.\n");//here is where the script ends
        dialogue.Add("\"FUCK OFF ALREADY!!!\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
