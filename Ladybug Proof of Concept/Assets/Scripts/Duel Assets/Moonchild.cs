using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonchild : Enemy {

	// Use this for initialization
	void Start ()
    {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "Moonchild\n";

        dialogue.Add("\n“I can assure you, I know all the gritty details of the people here. They’ve shown me the skeletons in their closets, and paid me well for the privilege.”");

        dialogue.Add("[DUEL:START]\n");
        options.Add("So you willingly admit that you aren’t a real medium?\n");
        options.Add("Skeletons! Do tell miss Real Psychic!\n");
        options.Add("You sound more like a conwoman than an actual medium.\n");
        options.Add("Pay? A real medium isn’t interested in that are they?\n");
        dialogue.Add("\"I’m as real as any other! But no, I can’t see any ghosts or the future, if that’s what you want to hear.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"I’m as real as any other! But no, I can’t see any ghosts or the future, if that’s what you want to hear.\"\n");
        options.Add("So you are a liar, why should I trust any further answers I get from you?\n");
        options.Add("So Theodore isn’t floating around the room, trying to tell me who the murderer is?\n");
        options.Add("Can mediums see the future? That doesn’t sound right. \n");
        options.Add("You only tell people what they want to hear, eh? What reason is there to trust you?\n");
        dialogue.Add("\"You should trust me, because my life could be at stake. There’s a killer among us, darling. And I don’t intend to be next.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"You should trust me, because my life could be at stake. There’s a killer among us, darling. And I don’t intend to be next.\"\n");
        options.Add("Who could have done this? Why would someone kill Theo?\n");
        options.Add("Nor do I, that’s why I intend to catch whoever did this.\n");
        options.Add("He seemed like a nice guy, I can’t imagine why someone would do this.\n");
        options.Add("All our lives are in danger, so I have to figure out the who and why of Theodore’s death.\n");
        dialogue.Add("\"Well the why is obvious to me.The boy threw vibrant parties and wasted his fortune left and right. Not only that, he squandered his love as well! That poor girl...\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"Well the why is obvious to me.The boy threw vibrant parties and wasted his fortune left and right. Not only that, he squandered his love as well! That poor girl...\"\n");
        options.Add("Lillian? What did he do to her?\n");
        options.Add("A frequent party goer and thrower is not much of a reason for murder.\n");
        options.Add("Wasted fortune?\n");
        options.Add("How does one squander love?\n");
        dialogue.Add("\"He spent so much on these gatherings, not that I’m complaining, and he assured his lady-friend that seeing the spirits would light up her life. Suffice to say, there have been no spirits.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"He spent so much on these gatherings, not that I’m complaining, and he assured his lady-friend that seeing the spirits would light up her life. Suffice to say, there have been no spirits.\"\n");
        options.Add("What about the others? Marino, Gerald and Eleanor?\n");
        options.Add("The seances were fake, if Marino knew he’d have gone berserk!\n");
        options.Add("Eleanor couldn’t have been enjoying Theodore wasting their fortune.\n");
        options.Add("Gerald must not have liked Theodore wasting their time and resources on whims.\n");
        dialogue.Add("\"Oh poor Marino, these days he couldn’t hurt a fly. And Eleanor and Gerald both loved Theodore, but Gerald was arguing with him earlier tonight.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"Oh poor Marino, these days he couldn’t hurt a fly. And Eleanor and Gerald both loved Theodore, but Gerald was arguing with him earlier tonight.\"\n");
        options.Add("So Gerald was fighting Theodore, and he was lying to Lillian, stringing her along?\n");
        options.Add("I KNEW Marino was good!\n");
        options.Add("I don’t know, Eleanor seemed cruel in her description of Theodore.\n");
        options.Add("Gerald did seem rather irritable, wasn’t giving too much care to his dead “best friend”.\n");//here is where the script ends
        dialogue.Add("\"Oh poor Marino, these days he couldn’t hurt a fly. And Eleanor and Gerald both loved Theodore, but Gerald was arguing with him earlier tonight.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.
    }

    // Update is called once per frame
    void Update () {
		
	}
}
