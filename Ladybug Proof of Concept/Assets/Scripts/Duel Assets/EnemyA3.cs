using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA3 : Enemy {

	// Use this for initialization
	void Start () {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[JERRY]\n";

        dialogue.Add("\n“Jesus Christ, I already answered your question!”");

        dialogue.Add("[DUEL:START]\n");
        options.Add("Sorry, sorrysorrysorry.\n");
        options.Add("Easy bud, now I have another question.\n");
        options.Add("Now you are going to answer my new question!\n");
        options.Add("Fuck off.\n");
        dialogue.Add("\"I don’t know what else to tell you.\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"I don’t know what else to tell you.\"\n");
        options.Add("(whispered) Um, where were you?\n");
        options.Add("Bro, just wanna know where you were.\n");
        options.Add("YOUR WHEREABOUTS NOW!\n");
        options.Add("Fuck off!\n");
        dialogue.Add("\"Where I was? Are you implying I am a suspect?!\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"Where I was? Are you implying I am a suspect?!\"\n");
        options.Add("No! Nonono, of course not! Hehe...heh… (sweats profusely)\n");
        options.Add("I’m not trying to imply anything, bruh.\n");
        options.Add("YES!!\n");
        options.Add("Fuck you.\n");
        dialogue.Add("\"You are a goddamn piece of work!\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"You are a goddamn piece of work!\"\n");
        options.Add("I know, I’m so sorry.\n");
        options.Add("I’m just tryin’ to figure this stuff out.\n");
        options.Add("HELLO POT, MY NAME IS KETTLE!\n");
        options.Add("Fuck You\n");
        dialogue.Add("\"I cannot even BELIEVE this! GOD DAMN THIS STUPID PARTY!\"\n");
        types.Add(2); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"I cannot even BELIEVE this! GOD DAMN THIS STUPID PARTY!\"\n");
        options.Add("(whimpers like a puppy)\n");
        options.Add("Easy dude, chillax.\n");
        options.Add("WHERE WERE YOU? TELL MEEEE!\n");
        options.Add("FUCK YOU.\n");
        dialogue.Add("\"GRAAAAAAHHHHHH\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"GRAAAAAAHHHHHH\"\n");
        options.Add("Wahhhh!\n");
        options.Add("Chill dude, it was just a question.\n");
        options.Add("GRAAAAAAAAAAAHSAKSJHDFKSJDHFNSKJDNF\n");
        options.Add("FUCK YOU!\n");//here is where the script ends
        dialogue.Add("\"FUCK OFF ALREADY!!!\"\n");
        types.Add(3); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
