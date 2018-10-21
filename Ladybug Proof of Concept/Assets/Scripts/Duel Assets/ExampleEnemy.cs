using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleEnemy : Enemy{

    void Start () {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[{NAME OF ENEMY}]\n";

        dialogue.Add("\n“{intro text}”");

        dialogue.Add("[DUEL:START]\n");
        options.Add("{concede option}\n");
        options.Add("{stand ground option}\n");
        options.Add("{aggressive option}\n");
        options.Add("{insult option}\n");
        dialogue.Add("\"{enemy's response}\"\n");
        types.Add(0); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"{copy and paste the enemy's response from above, that's it.}\"\n");
        options.Add("{concede option}\n");
        options.Add("{stand ground option}\n");
        options.Add("{aggressive option}\n");
        options.Add("{insult option}\n");
        dialogue.Add("\"{enemy's response}\"\n");
        types.Add(0); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"{copy and paste the enemy's response from above, that's it.}\"\n");
        options.Add("{concede option}\n");
        options.Add("{stand ground option}\n");
        options.Add("{aggressive option}\n");
        options.Add("{insult option}\n");
        dialogue.Add("\"{enemy's response}\"\n");
        types.Add(0); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!
    }
}