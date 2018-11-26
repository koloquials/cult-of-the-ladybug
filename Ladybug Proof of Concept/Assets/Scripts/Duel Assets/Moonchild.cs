using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonchild : Enemy {

	// Use this for initialization
	void Start ()
    {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[MOONCHILD]\n";

        dialogue.Add("\n“Ah. Upon your quest for knowledge, I see I've also come under suspicion. How may I allay your concerns?”");

        dialogue.Add("\n“Ah. Upon your quest for knowledge, I see I've also come under suspicion. How may I allay your concerns?”");
        options.Add(".\n");
        options.Add(".\n");
        options.Add(".\n");
        options.Add(".\n");
        dialogue.Add("\"Trust is not cheap in a situation like this. I understand. Our late host was cut of a far too trusting cloth.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"Trust is not cheap in a situation like this. I understand. Our late host was cut of a far too trusting cloth.\"\n");
        options.Add(".\n");
        options.Add(".\n");
        options.Add(".\n");
        options.Add(".\n");
        dialogue.Add("\"I am guilty, and unguilty. Of some things here and others far between. Few live a truly untarnished existence.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"I am guilty, and unguilty. Of some things here and others far between. Few live a truly untarnished existence.\"\n");
        options.Add(".\n");
        options.Add(".\n");
        options.Add(".\n");
        options.Add(".\n");
        dialogue.Add("\"My child, I am here on matters linked strictly to my profession. Surely you understand this.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"My child, I am here on matters linked strictly to my profession. Surely you understand this.\"\n");
        options.Add(".\n");
        options.Add(".\n");
        options.Add(".\n");
        options.Add(".\n");
        dialogue.Add("\"For the long seasons I have been aquainted with this crowd, I cannot say I expected this. I am certainly shocked.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"For the long seasons I have been aquainted with this crowd, I cannot say I expected this. I am certainly shocked.\"\n");
        options.Add(".\n");
        options.Add(".\n");
        options.Add(".\n");
        options.Add(".\n");
        dialogue.Add("\"Theodore has been quite a character. However, I am only an outsider peering into affairs not my own.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"Theodore has been quite a character. However, I am only an outsider peering into affairs not my own.\"\n");
        options.Add(".\n");
        options.Add(".\n");
        options.Add(".\n");
        options.Add(".\n"); //here is where the script ends
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
