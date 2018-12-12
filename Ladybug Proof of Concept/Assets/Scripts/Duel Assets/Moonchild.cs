using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonchild : Enemy {

	// Use this for initialization
	void Start ()
    {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[MOONCHILD]\n";

        dialogue.Add("\"Ah. Upon your quest for knowledge, I see I've also come under suspicion. How may I allay your concerns?”");

        dialogue.Add("\"Ah. Upon your quest for knowledge, I see I've also come under suspicion. How may I allay your concerns?”");
        options.Add("This facade of yours ends here. You can't allay anything because I know you have the strongest motives.\n");
        options.Add("You've been putting on a helpful guise, but you're going to have to admit you're extremely shady.\n");
        options.Add("We both know you're the other outsider in this crowd, surely that turns some attention towards your motives here.\n");
        options.Add("I see you already understand the situation, then. I don't trust you, but maybe we can work out an understanding.\n");
        dialogue.Add("\"Trust is not cheap in a situation like this. I understand. Our late host was cut of a far too trusting cloth.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"Trust is not cheap in a situation like this. I understand. Our late host was cut of a far too trusting cloth.\"\n");
        options.Add("He absolutely was, and you're guilty for being the one to extort him time and time again for these seances.\n");
        options.Add("And you were the one who took him and played him like a puppet, weren't you? You cannot deny the hand you played.\n");
        options.Add("If you know this, then why didn't you speak up? Do you know something I don't yet? Speak up.\n");
        options.Add("So you acknowledge it, that Theo was a naive individual. Why then, did you carry on and just let this happen?\n");
        dialogue.Add("\"I am guilty, and unguilty. Of some things here and others far between. Few live a truly untarnished existence.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"I am guilty, and unguilty. Of some things here and others far between. Few live a truly untarnished existence.\"\n");
        options.Add("You're guilty! The writing could not be more blantantly splayed across the wall. Just. Why?\n");
        options.Add("And your life has been tarnished with this unsightly deed. Do you have nothing to say in your defense?\n");
        options.Add("Directly or not, your clear knowledge of the situation caused this grisly homocide. How could you do this.\n");
        options.Add("That's the nature of all people, but shouldn't you strive for goodness? You can still help me make a difference.\n");
        dialogue.Add("\"My child, I am here on matters linked strictly to my profession. Surely you understand this.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"My child, I am here on matters linked strictly to my profession. Surely you understand this.\"\n");
        options.Add("There's a lot of things I undestand perfectly well. Most of all the crime you've committed here tonight.\n");
        options.Add("The part you played in this is sinister, whether you were just doing a job or not. How could you?.\n");
        options.Add("All the things you've learned, you've selfishly kept to yourself then. Isn't it time to divulge something?\n");
        options.Add("You've picked up things about these individuals in your time then, right? I need your outsider's perspective, please.\n");
        dialogue.Add("\"For the long seasons I have been aquainted with this crowd, I cannot say I actually expected this. I am certainly shocked.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"For the long seasons I have been aquainted with this crowd, I cannot say I actually expected this. I am certainly shocked.\"\n");
        options.Add("Why are you so shocked? You of all people must have seen this end coming for Theo. Reading people is what you do, isn't it.\n");
        options.Add("You must not be a very good con artist if this truly shocked you. Tell the truth. What do you know?\n");
        options.Add("I get that you're out of your depth here, but do you have any more info, any at all, about their relations?.\n");
        options.Add("Then that means you are aquainted with the victim. You've proven to be perceptive of Theo, but what about his connections with the others?\n");
        dialogue.Add("\"Theodore has been quite a character. However, I am only an outsider peering into affairs not my own.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"Theodore has been quite a character. However, I am only an outsider peering into affairs not my own.\"\n");
        options.Add("A likely alibi, but one that doesn't add up. You've known this party for months after all, speak up.\n");
        options.Add("Perhaps you were once, but you're intimately connected now. That excuse doesn't hold up anymore.\n");
        options.Add("At this point, you're a witness and a point of contact. You have a duty to tell me what you know.\n");
        options.Add("But still, you've seen things. I don't mean to make lightly of the work you put into your profession, but I need some help.\n"); //here is where the script ends
        dialogue.Add("\"Dear investigator, do not run circles with your frantic reasoning. I will be of assistance if you need me.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"Dear investigator, do not run circles with your frantic reasoning. I will be of assistance if you need me.\"\n");
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
