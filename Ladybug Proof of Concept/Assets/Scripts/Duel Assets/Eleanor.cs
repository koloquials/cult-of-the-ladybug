using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eleanor : Enemy {

	// Use this for initialization
	void Start ()
    {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "Eleanor\n";

        dialogue.Add("\n“This whole party is some big joke, and he now he’s died for it.”");

        dialogue.Add("[DUEL:START]\n");
        options.Add("I understand that this is a difficult situation, but I have some questions for you.\n");
        options.Add("Jokes aside, this is a murder scene.\n");
        options.Add("What are you talking about? He was a comedian?\n");
        options.Add("Are you saying he died as a joke?\n");
        dialogue.Add("\"Yeah, no. My best friend is lying dead. It’s not a joke. These seances, spiritualism, talking to the dead, THAT’S the real joke. It’s all boloney.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"Yeah, no. My best friend is lying dead. It’s not a joke. These seances, spiritualism, talking to the dead, THAT’S the real joke. It’s all boloney.\"\n");
        options.Add("Who do you believe could do this?\n");
        options.Add("I hear you, I only came because I thought it might be amusing.\n");
        options.Add("So you aren’t a true believer? \n");
        options.Add("Maybe, maybe not. All I believe is that I will find his killer.\n");
        dialogue.Add("\"I believe that some here are more suspicious than others, Lillian and Moonchild for instance.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"I believe that some here are more suspicious than others, Lillian and Moonchild for instance.\"\n");
        options.Add("Why are you suspicious of those two, what did they do?\n");
        options.Add("What is so suspicious about them?\n");
        options.Add("What did they ever do to you to deserve a murder accusation?\n");
        options.Add("They seem like a fine pair of ladies to me.\n");
        dialogue.Add("\"Moonchild has spoonfed them all lies with her tricks, and Lillian shows up out of nowhere and suddenly loves Theodore? He wasn’t that handsome.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"Moonchild has spoonfed them all lies with her tricks, and Lillian shows up out of nowhere and suddenly loves Theodore? He wasn’t that handsome.\"\n");
        options.Add("That is for me to decide, since I am the only one gathering the facts.\n");
        options.Add("It’s hard to see if he was ever handsome with all those knives.\n");
        options.Add("Tricks, lies, and a golddigger. That is pretty suspicious if it’s true.\n");
        options.Add("You’re suspicious because you haven’t bothered to get to know them.\n");
        dialogue.Add("\"Then allow me to enlighten you: there is no way that Moonchild is a real psychic, and Lillian is obviously only interested in his wealth.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"Then allow me to enlighten you: there is no way that Moonchild is a real psychic,  and Lillian is obviously only interested in his wealth.\"\n");
        options.Add("Have you actually told them of your suspicions, in upfront confrontation?\n");
        options.Add("A couple of con artists, eh? Were you going to call the cops?\n");
        options.Add("Were you going to tell Theodore any of this?\n");
        options.Add("You weren’t going to keep this to yourself, were you?\n");
        dialogue.Add("\"No, why would I? There’s no need, the only one who needed to know was Theo, and that won’t do him any good anymore.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"No, why would I? There’s no need, the only one who needed to know was Theo, and that won’t do him any good anymore.\"\n");
        options.Add("Then I will! After all, if they are the most suspicious, then they deserve my attention.\n");
        options.Add("You should’ve done something when he was still alive.\n");
        options.Add("You’ve got that right, he’s just a human shishkebab now.\n");
        options.Add("Someone has to do something about this, a man is dead!\n");//here is where the script ends
        dialogue.Add("\"No, why would I? There’s no need, the only one who needed to know was Theo, and that won’t do him any good anymore.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.
    }

    // Update is called once per frame
    void Update () {
		
	}
}
