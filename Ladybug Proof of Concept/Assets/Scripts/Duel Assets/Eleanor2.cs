using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eleanor2: Enemy {

	// Use this for initialization
	void Start ()
    {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[ELEANOR]\n";
        startPos = 4;

        dialogue.Add("\"Unbelievable. You're back? Why have you returned?”");

        dialogue.Add("\"Unbelievable. You're back? Why have you returned?”");
        options.Add("Proof that you did this. Would you like to fess up now?\n");
        options.Add("Evidence of culpability, the fast you talk the fast we can leave.\n");
        options.Add("Got some more information. Could be talk it out?\n");
        options.Add("I have some more thoughts I'd like to feel out if that's alright.\n");
        dialogue.Add("\"Surely you've already heckled me out of everything I have to say?\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"Surely you've already heckled me out of everything I have to say?\"\n");
        options.Add("I'm back because I've learned that isn't true. I hate wasting time as much as you.\n");
        options.Add("Previously, maybe, but isn't that the beauty of learning new information?\n");
        options.Add("Not quite. If you've just give me a little bit more time, I'd appreciate it.\n");
        options.Add("I know it's a lot. But none of us can rest until I get this info.\n");
        dialogue.Add("\"You can't see I've lost a son today? Theo was my very own child, in my heart.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"You can't see I've lost a son today? Theo was my very own child, in my heart.\"\n");
        options.Add("Maybe you say that, but it's hard to believe. You detested him, didn't you?\n");
        options.Add("Yet still you treated him so cruely in life. How could you have done that?\n");
        options.Add("Sure, but often parents will mistreat those they meant to protect, no?\n");
        options.Add("Yes, but if I could hazard a moment, how did you feel about him? Disappointed?\n");
        dialogue.Add("\"How could you ask something like that? An unfair thing to ask of someone in mourning.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"How could you ask something like that? An unfair thing to ask of someone in mourning.\"\n");
        options.Add("Lots of life is cruel. Perhaps I am too. But I need answers.\n");
        options.Add("How exactly is this unfair? Just tell me about Theo again.\n");
        options.Add("I ask because I need to, surely you understand that.\n");
        options.Add("The implications sounds bad, but I'm sure you cared.\n");
        dialogue.Add("\"Tch. I think I treated him as best I could. You don't seem the sort with children, how would you know?\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"Tch. I think I treated him as best I could. You don't seem the sort with children, how would you know?\"\n");
        options.Add("One doesn't need children to see the abuse you've dealt him.\n");
        options.Add("I may not have any, but I know how humans ought to be treated. You've been inhumane.\n");
        options.Add("So what if I don't? I've lived a life and been shaped by it. What you did was wrong.\n");
        options.Add("That's all you have to say? Surely there was always the option to do better.\n");
        dialogue.Add("\"He had faults. So many of them. Often times I wonder how he'd come to be such a disaster.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"He had faults. So many of them. Often times I wonder how he'd come to be such a disaster.\"\n");
        options.Add("And that question soon took on a disastrous angle of its own, didn't it.\n");
        options.Add("Surely the conundrum built unconceivable stress into your life.\n");
        options.Add("Our children don't often turn out the way we'd like them to. I think you know this now.\n");
        options.Add("We all have disappointments in our lives, but that doesn't negate the love we have for them. I get it.\n");
        dialogue.Add("\"Was this really necessary?\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"Was this really necessary?\"\n");
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
