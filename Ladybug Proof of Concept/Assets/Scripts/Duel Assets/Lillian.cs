using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lillian : Enemy {

	// Use this for initialization
	void Start ()
    {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[LILLIAN]\n";
        startPos = 4;

        dialogue.Add("\"Oh, my! Please, I'm not sure my poor heart can take this at the moment. But what can I do for you?”");

        dialogue.Add("\"Oh, my! Please, I'm not sure my poor heart can take this at the moment. But what can I do for you?”");
        options.Add("Please, darling, I just need a few moments of your time if you'd spare them.\n");
        options.Add("You can start by helling me what the hell's up with you!\n");
        options.Add("Well, I'm going around asking questions. Do you have any answers?\n");
        options.Add("I have to barge in, regardless. Could you help clarify some things?\n");
        dialogue.Add("\"Are you sure you've talked to everyone? You've already done that?\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"Are you sure you've talked to everyone? You've already done that?\"\n");
        options.Add("I'm certain times are tough for you right now. Please hold out a little longer.\n");
        options.Add("It's been hard work, but I have, that's why I'm here now.\n");
        options.Add("Forget that, I'm talking to you now.\n");
        options.Add("I have, and they're all very harmless. What about you?\n");
        dialogue.Add("\"I just want to warn you, make sure you've hit all your bases, I want to figure things out too.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"I just want to warn you, make sure you've hit all your bases, I want to figure things out too.\"\n");
        options.Add("You're a good person, and I thank you for that. You and Theo were close, we need that.\n");
        options.Add("Of course, ideally we all figure things out very soon.\n");
        options.Add("We are all involved in this. And that's why you should cooperate.\n");
        options.Add("Could you stop deflecting and start telling me what your relationship with the victim was?\n");
        dialogue.Add("\"Ah. I can only assume you're here on the basis of rumor. All you need to know is I loved Theo!\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"Ah. I can only assume you're here on the basis of rumor. All you need to know is I loved Theo!\"\n");
        options.Add("You two did seem awfull involved in each other's lives, right? What kind of man was he?\n");
        options.Add("Oh I am well aware, my dear. But I'm dyng to hear more if you could.\n");
        options.Add("That's sweet. It is. I'm sure you're beyond upset. How were you?\n");
        options.Add("Odd that you'd need to reaffirm that, isn't it? Can you elaborate?\n");
        dialogue.Add("\"I think he treated me right, no matter what. He was truly a gentleman and I was enamoured by that.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"I think he treated me right, no matter what. He was truly a gentleman and I was enamoured by that.\"\n");
        options.Add("I understand, I really do. This was no way for someone as good as him to go.\n");
        options.Add("I'm truly sorry for his grisly passing then. May the mourning be swift.\n");
        options.Add("Good of you to emphasize his pros but let's go further. What about his cons?\n");
        options.Add("Was his whole heart in it? I feel like there's more to this you aren't telling.\n");
        dialogue.Add("\"However, he was the wishy washy type. In a lot of ways he wasn't reliable. It was cause for concern.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"However, he was the wishy washy type. In a lot of ways he wasn't reliable. It was cause for concern.\"\n");
        options.Add("I'm sorry it was the sort of thing you couldn't get patched up in time then.\n");
        options.Add("Time is truly cruel, but at least his weaknesses are no longer alive to hurt people.\n");
        options.Add("Must be hard work, living with such a man. But you persisted and you should be proud of that.\n");
        options.Add("You must’ve been upset with him for being noncommital. Upsetting, I wonder?\n");
        dialogue.Add("\"If you don't mind, my poor head is fraught with woes. Please, could I be alone for some time?\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"If you don't mind, my poor head is fraught with woes. Please, could I be alone for some time?\"\n");
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
