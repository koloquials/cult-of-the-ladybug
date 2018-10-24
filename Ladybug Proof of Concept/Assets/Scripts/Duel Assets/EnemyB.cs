using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : Enemy {

	// Use this for initialization
	void Start () {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[MOONCHILD]\n";

        dialogue.Add("\n“AH! Interrupting is rude…”");

        dialogue.Add("[DUEL:START]\n");
        options.Add("Oh gosh, I’m so sorry.\n");
        options.Add("Relax, dude. I just wanna know how you know the dead guy.\n");
        options.Add("DID YOU MURDER THE HOST?!\n");
        options.Add("Speak up, dumbass.\n");
        dialogue.Add("\"I-I’m not to sure what’s going on here...\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"I-I’m not to sure what’s going on here...\"\n");
        options.Add("Me neither.\n");
        options.Add("It is an odd situation for sure.\n");
        options.Add("TELL ME WHAT I WANT TO KNOW!\n");
        options.Add("Wow. It’s a murder, Sherlock. OPEN YOUR EYES!\n");
        dialogue.Add("\"Um, none of this is what I expected from a party. This isn’t very fun.\"\n");
        types.Add(1); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"Um, none of this is what I expected from a party. This isn’t very fun.\"\n");
        options.Add("Murder has put a bit of a damper on things.\n");
        options.Add("It could be fun, if you used your imagination.\n");
        options.Add("TELL MEEEE!\n");
        options.Add("WHAT THIS MURDER ISN’T FUN ENOUGH FOR YOU, YOU SICKO?!\n");
        dialogue.Add("\"H-h-hey, um, this is all really scary. Could you maybe go talk to someone else? I know Jerry is probably more ready to talk than me.\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"H-h-hey, um, this is all really scary. Could you maybe go talk to someone else? I know Jerry is probably more ready to talk than me.\"\n");
        options.Add("Y-yeah it is pretty scary out here in the woods, plus the dead guy in here.\n");
        options.Add("It’s not that scary, just take a breath so we can talk.\n");
        options.Add("I’LL GIVE YOU SOMETHING TO BE SCARED OF!\n");
        options.Add("Frickin’ scaredy-cat-loser-baby.\n");
        dialogue.Add("\"Th-this is all too much for me. Please stop bothering me.\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"Th-this is all too much for me. Please stop bothering me.\"\n");
        options.Add("I’m so sorry, I didn’t mean any harm.\n");
        options.Add("Alright, alright now just relax.\n");
        options.Add("I’M BOTHERING YOU? YOU’RE BOTHERING ME BY IGNORING ME!\n");
        options.Add("What’re you gonna do, cry? Ya big baby.\n");
        dialogue.Add("\"Waaaaaaaaaaaaaah!\"\n");
        types.Add(1); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"Waaaaaaaaaaaaaah!\"\n");
        options.Add("Oh no, please don’t cry.\n");
        options.Add("You seriously need to chill out.\n");
        options.Add("ANSWER MY QUESTIONS DAMMIT!\n");
        options.Add("WHAT A LITTLE CRY-BITCH BABY!\n");//here is where the script ends
        dialogue.Add("\"FUCK OFF ALREADY!!!\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
