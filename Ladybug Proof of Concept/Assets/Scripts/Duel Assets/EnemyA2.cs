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
        options.Add("I assure you, that was not my intention.\n");
        options.Add("I only asked her name.\n");
        options.Add("I need to get to the bottom of things, I can't worry about feelings.\n");
        options.Add("I didn;t make her cry, she did that on her own.\n");
        dialogue.Add("\"What could be so damn important that you’d go so far?\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"What could be so damn important that you’d go so far?\"\n");
        options.Add("I'll concede, I didn't need to push her so far.\n");
        options.Add("A man has died here tonight, we could all be in danger.\n");
        options.Add("Justice and the search for truth!\n");
        options.Add("Can you not see the corpse over there?\n");
        dialogue.Add("\"I understand our current circumstance, but your behavior is out of bounds!\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"I understand our current circumstance, but your behavior is out of bounds!\"\n");
        options.Add("Perhaps I went to far, but something must be done!\n");
        options.Add("My behavior and investigation are warranted, considering the crime.\n");
        options.Add("One must act when in pursuit of justice, regardless of the consequences.\n");
        options.Add("If you really understand our circumstances, then you'll forgive my behavior!\n");
        dialogue.Add("\"I've had my fill of you, your behavior, and your questions!\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"I've had my fill of you, your behavior, and your questions!\"\n");
        options.Add("I'm sorry, but I can't just leave this crime unsolved!\n");
        options.Add("A life has been lost and lives are at stake! I stand by my actions!\n");
        options.Add("Too bad because I have more of all three!\n");
        options.Add("I have barely begun to get to my real question!\n");
        dialogue.Add("\"If you know what's good for you, you'll leave me and my sister alone. Now!\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"If you know what's good for you, you'll leave me and my sister alone. Now!\"\n");
        options.Add("I don't mean to harm you or your sister! I mean to do the opposite, in fact!\n");
        options.Add("My safety is of little importance, the safety of an innocent is another matter.\n");
        options.Add("You and your sister knew the host, I want to know how.\n");
        options.Add("I guess I don't know what's good for me, since I don't intend to leave this alone.\n");
        dialogue.Add("\"I don’t even know what you want me to tell you!\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"I don’t even know what you want me to tell you!\"\n");
        options.Add("Perhaps I haven't been clear, I want to know how you knew the host.\n");
        options.Add("I want you to tell me the truth!\n");
        options.Add("I need to know the nature of your relationship to our mutual dead friend!\n");
        options.Add("Yes you do! A part of you knows exactly what I want to hear!\n");//here is where the script ends
        dialogue.Add("\"I don’t even know what you want me to tell you!\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
