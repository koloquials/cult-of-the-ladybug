using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eleanor : Enemy {

	// Use this for initialization
	void Start ()
    {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[ELEANOR]\n";

        dialogue.Add("\"Don't you know not to meddle in the personal affairs of others? I'm handling this situation.”");

        dialogue.Add("\"Don't you know not to meddle in the personal affairs of others? I'm handling this situation.\"\n");
        options.Add("You seem rather forward about moving on from this tragedy. Aren't you a little too detached?\n");
        options.Add("You're behaving rather oddly, ma'am. But I need to meddle a little to get a hold on this case.\n");
        options.Add("I know you have matters to attend to, but could you clarify a few things first?\n");
        options.Add("Everyone processes their grief differently. I just need a few moments of your time.\n");
        dialogue.Add("\"If you must drill me for answers, tread carefully girl. My dear nephew has been murdered, show some respect.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"If you must drill me for answers, tread carefully girl. My dear nephew has been murdered, show some respect.\"\n");
        options.Add("Marino says you always had your nose in Theodore’s business. Pretty controlling, huh?\n");
        options.Add("Shouldn't his next of kin be a little more distraught over his loss? You seem a little too alright.\n");
        options.Add("I understand. But as someone so pivotal in Theo's life, anything you know is extremely important to me.\n");
        options.Add("You really cared for him, didn't you? That's why I need you to tell me what you know.\n");
        dialogue.Add("\"Of course, I took that child under my wing. I raised him as my own. Now he's gone.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"Of course, I took that child under my wing. I raised him as my own. Now he's gone.\"\n");
        options.Add("And that would be pretty convenient for you, now wouldn't it? Your wealthy, heirless nephew, gone.\n");
        options.Add("He might be gone, but you're still here. Don't you know anyone who could've done this?\n");
        options.Add("And soon the healing can begin. We can put this to rest faster if you'd help me.\n");
        options.Add("It's difficult to process, I know. You'd know of Theo's past woes better than anyone else.\n");
        dialogue.Add("\"It's true that he inherited a great wealth. But even money couldn't make up for his lack in character.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"It's true that he inherited a great wealth. But even money couldn't make up for his lack in character.\"\n");
        options.Add("I see. Is that why you did away with him? Because his personality upset you?\n");
        options.Add("Lacking? You were the one who raised him, weren't you? Didn't you keep him on the straight and narrow?\n");
        options.Add("You did the best you could, I'm certain. Sounds like you had your hands full, huh?\n");
        options.Add("He inherited wealth, and you inherited the responsibility. It's a hard task, but you rose to it.\n");
        dialogue.Add("\"I was stern with him, certainly. But only because he was so young, so ready to bend to others' expectations.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"I was stern with him, but only because he was so young, so ready to bend to others' expectations.\"\n"); ;
        options.Add("You've failed him as his caretaker, then. Do you want to keep failing him?\n");
        options.Add("Did he not bend to your own expectations, too? He strayed too far from where you intended.\n");
        options.Add("Anyone would want to make use of someone with a weak constitution. Does anyone specific come to mind?\n");
        options.Add("You were harsh because you recognized his weakness to prevent him being taken advantage of. You tried.\n");
        dialogue.Add("\"However cruel, however cold I was to him, it was for his benefit. How does nobody see this?\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"However cruel, however cold I was to him, it was for his benefit. How does nobody see this?\"\n");
        options.Add("I do. I see your efforts, and I see your pain. Speak, and maybe we can begin to rebuild.\n");
        options.Add("You drove him away. Set him down the path that led to his demise. Provide me with evidence to absolve your guilt.\n");
        options.Add("Nobody can see your intentions. You have to speak through your actions.\n");
        options.Add("People hardly do. It's a shame you couldn't care for him more in his life. But you can help him now.\n"); //here is where the script ends
        dialogue.Add("\"...Are you satisfied with this ceaseless questioning? I have plenty on my mind as is.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"...Are you satisfied with this ceaseless questioning? I have plenty on my mind as is.\"\n");
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
