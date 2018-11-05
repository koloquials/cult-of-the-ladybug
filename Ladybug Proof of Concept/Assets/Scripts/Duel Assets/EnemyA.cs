using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy {

	// Use this for initialization
	void Start () {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[JERRY]\n";

        dialogue.Add("\n“What do you want?!”");

        dialogue.Add("[DUEL:START]\n");
        options.Add("I don’t mean to intrude, I merely wish to talk.\n");
        options.Add("I want to talk. Calmly, if that’s possible.\n");
        options.Add("I want your name, and everyone else’s.\n");
        options.Add("No need to fly off the handle, I haven’t asked anything yet.\n");
        dialogue.Add("\"Pardon me, but this hardly seems the time nor the place for playing pretend-detective!\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"Pardon me, but this hardly seems the time nor the place for playing pretend-detective!\"\n");
        options.Add("I’d have to agree, but this situation seems dire.\n");
        options.Add("I assure you, I am not pretending.\n");
        options.Add("No one else is doing anything about this, therefore I must!\n");
        options.Add("Well pardon me, but a man has been murdered here tonight.\n");
        dialogue.Add("\"Well, never in my life have I been made to suffer so many indignities in one night!\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"Well, never in my life have I been made to suffer so many indignities in one night!\"\n");
        options.Add("Apologies, my intention is not to offend.\n");
        options.Add("Indignities aside, there are more important matters at hand.\n");
        options.Add("We all must sacrifice comfort in pursuit of the truth.\n");
        options.Add("Then you must be able to understand how our host feels!\n");
        dialogue.Add("\"My word, the gall of this one!\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"My word, the gall of this one!\"\n");
        options.Add("Though I may be acting brash, it must be done.\n");
        options.Add("One needs gall to investigate such morbid things as these.\n");
        options.Add("Regardless, I must know more than I do now!\n");
        options.Add("The gall of you, deflecting any questioning as you’ve been!\n");
        dialogue.Add("\"Why is my identity suddenly of such importance?\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"Why is my identity suddenly of such importance?\"\n");
        options.Add("Well, anything you could tell me would be appreciated.\n");
        options.Add("Every clue is of equal importance! I must gather all the facts!\n");
        options.Add("Your identity may exonerate you, or vilify you.\n");
        options.Add("Why wouldn’t your identity be important?\n");
        dialogue.Add("\"And why should I tell you anything at all?\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"And why should I tell you anything at all?\"\n");
        options.Add("Fair point, as I’ve done nothing for you. Consider it a favor, perhaps?\n");
        options.Add("Simply because I have asked. Manners, sir.\n");
        options.Add("Because a man has died here tonight, and he deserves justice.\n");
        options.Add("Because your willful withholding of information could wind up being lethal.\n");//here is where the script ends
        dialogue.Add("\"And why should I tell you anything at all?\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.
    }

    // Update is called once per frame
    void Update () {
		
	}
}
