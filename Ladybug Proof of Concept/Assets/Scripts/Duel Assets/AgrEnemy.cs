using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgrEnemy : Enemy{

    void Start () {
        dialogue.Add("[Aggressive Foe]\n\n“It was you, motherfucker. The others may not see it, but my third eye is cracked wide open and it knows you're guilty as fuck.”\n\n[space]");

        dialogue.Add("[DUEL:START]\n");
        options.Add("Sure, it does look like I’m at fault.\n");
        options.Add("And it wasn’t. What evidence do you have to back up your accusation?\n");
        options.Add("Yet you aren't? It's telling that you're throwing around a wild accusation.\n");
        options.Add("You're wrong AND an absolute idiot.");
        dialogue.Add("\"Yeah? I'm saying it was you because I have proof! Heard your voice loud and clear before an impact. Blam. It was you.\"\n");
        types.Add(3);

        dialogue.Add("\"Yeah? I'm saying it was you because I have proof! Heard your voice loud and clear before an impact. Blam. It was you.\"\n");
        options.Add("I did yell, but I wasn't on the scene.\n");
        options.Add("You're confusing correlation with causation.\n");
        options.Add("Don't just jump to conclusions. And why were /you/ even there?\n");
        options.Add("Well great, just call yourself a big fancy detective then, bitch.");
        dialogue.Add("\"I was looking over from my balcony, too dark to see the scene, but I saw a figure your height making an escape!\"\n");
        types.Add(3);

        dialogue.Add("\"I was looking over from my balcony, too dark to see the scene, but I saw a figure your height making an escape!\"\n");
        options.Add("Maybe I was passing through, but I doubt it.\n");
        options.Add("Can you really judge height from that distance? I don't believe it.\n");
        options.Add("There's so much conjecture, how can you be sure of any of this?\n");
        options.Add("And your enlightened third eye calls that hard evidence?");
        dialogue.Add("\"Hey! This is rock solid case! I'll fucking throttle you.\"\n");
        types.Add(4);

        dialogue.Add("\"Hey! This is rock solid case! I'll fucking throttle you.\"\n");
        options.Add("True, there are points that make me seem culpable.\n");
        options.Add("Then you're gonna have to argue for it better than this.\n");
        options.Add("It shouldn't be this easy for me to poke holes into it then, what gives?\n");
        options.Add("I'd like to fucking see you try, given how shitty your arguement is.");
        dialogue.Add("\"Just admit defeat already! The writing's on the wall! You're a murderer! You're a filthy rotten mistake!\"\n");
        types.Add(4);

        dialogue.Add("\"Just admit defeat already! The writing's on the wall! You're a murderer! You're a filthy rotten mistake!\"\n");
        options.Add("Woah, it looks bad, I know that, but it's not on the /wall/.\n");
        options.Add("I can't because I'm flat-out not guilty.\n");
        options.Add("Why would I? I'm not the culprit. You still haven't given any solid evidence and look guilty in turn.\n");
        options.Add("I'll put your head through a wall if you don't stop screaming.");
        dialogue.Add("\"Ughhh this is so /frustrating/. I heard you, I saw you, it's so goddamn obvious. Admit it.\"\n");
        types.Add(3);

        dialogue.Add("\"Ughhh this is so /frustrating/. I heard you, I saw you, it's so goddamn obvious. Admit it.\"\n");
        options.Add("Come on, let's think through this. How could it have been me?\n");
        options.Add("Look man, aside from also being in the area, you have nothing on me specifically.\n");
        options.Add("You have nothing on me. The only thing that's obvious is how shady you are. Let's talk about that, hm?\n");
        options.Add("Shut up. Just shut up. You have the logical reasoning of a tragic dipshit. Leave this to smarter, more competent people.");
        dialogue.Add("\"Yeah? I'm saying it was you because I have proof! Heard your voice loud and clear before an impact. Blam. It was you.\"\n");
        types.Add(3);
    }
}
