using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eleanor : Enemy {

	// Use this for initialization
	void Start ()
    {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "Eleanor\n";

        dialogue.Add("\n“And who are you? Theodore never mentioned a lady detective.”");

        dialogue.Add("[DUEL:START]\n");
        options.Add("Theodore? You mean Mr. Hampshire! What can you tell me about him?\n");
        options.Add("We hadn’t known each other long. Sadly, I didn’t get to know him too well.\n");
        options.Add("My name’s not super important. You can just keep on calling me lady detective.\n");
        options.Add("It’s not too odd that he didn’t mention me, we only met a couple weeks ago.\n");
        dialogue.Add("\"Well I can tell you the obvious, that my nephew has been murdered.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"Well I can tell you the obvious, that my nephew has been murdered.\"\n");
        options.Add("Can you also tell me who might’ve done this? Marino says you had your nose in Theodore’s business.\n");
        options.Add("Yes, I can see that. Can you tell me about what I’m not seeing?\n");
        options.Add("That is fairly obvious, what with all the knives. But I have heard that you might know more about this. \n");
        options.Add("I was told that you know more than just the obvious.\n");
        dialogue.Add("\"Of course, that gangster sent you my way! You should interrogate him further, I always knew he was a bad man.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"Of course, that gangster sent you my way! You should interrogate him further, I always knew he was a bad man.\"\n");
        options.Add("I already talked to him, and he isn’t going to tell me anything else. I’m interrogating you now.\n");
        options.Add("He’s not talking, but you still can.\n");
        options.Add("He seems like a he’s stand up guy these days, if you ask me. You, on the other hand...\n");
        options.Add("Yes well, I’m not going to do that. Instead, I’ll interrogate you.\n");
        dialogue.Add("\"If you are so intent to bother me, what is it you think I can tell you?\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"If you are so intent to bother me, what is it you think I can tell you?\"\n");
        options.Add("Who here could have killed your nephew?\n");
        options.Add("Where were you when the lights went out?\n");
        options.Add("Why eight knives?\n");
        options.Add("What is going on here?\n");
        dialogue.Add("\"What a question! How on Earth should I know that?\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"What a question! How on Earth should I know that?\"\n");
        options.Add("Way I hear it, you were rather involved in Theodore’s life.\n");
        options.Add("Well, from your age and wisdom I assumed you know a great many things.\n");
        options.Add("Well, you are supposed to know everything around here right?\n");
        options.Add("I just figured you might know something about your nephew’s life.\n");
        dialogue.Add("\"Well, I did raise the boy. But I cannot claim to know every detail of his affairs.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"Well, I did raise the boy. But I cannot claim to know every detail of his affairs.\"\n");
        options.Add("Who might’ve done this to him?\n");
        options.Add("What was his relationship with all these people?\n");
        options.Add("What can you tell me about him?\n");
        options.Add("How about these seance parties then? Why did he throw them?\n");//here is where the script ends
        dialogue.Add("\"Well, I did raise the boy.But I cannot claim to know every detail of his affairs.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.
    }

    // Update is called once per frame
    void Update () {
		
	}
}
