using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleEnemy : Enemy{

    void Start () {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[{NAME OF ENEMY}]\n";
        startPos = 3; //1-6. whatever tile they start on. 3 by default, which means they are on the fourth tile.

        dialogue.Add("\n“{intro text}”");
        returnText = "{text if the player rematches npc}";

        dialogue.Add("[INTERROGATION:START]\n");
        options.Add("{very bad option}\n"); //1
        options.Add("{bad option}\n"); //2
        options.Add("{okay option}\n"); //3
        options.Add("{great option}\n"); //4
        dialogue.Add("\"{enemy's response}\"\n"); //as in the next prompt, not rly a positive or negative response to what the player said. 
        types.Add(4);

        dialogue.Add("\"{copy and paste the enemy's response from above, that's it.}\"\n");
        options.Add("{very bad option}\n"); //1
        options.Add("{bad option}\n"); //2
        options.Add("{okay option}\n"); //3
        options.Add("{great option}\n"); //4
        dialogue.Add("\"{enemy's response}\"\n");
        types.Add(4);

        dialogue.Add("\"{copy and paste the enemy's response from above, that's it.}\"\n");
        options.Add("{very bad option}\n"); //1
        options.Add("{bad option}\n"); //2
        options.Add("{okay option}\n"); //3
        options.Add("{great option}\n"); //4
        dialogue.Add("\"{enemy's response}\"\n");
        types.Add(4);

        //rinse and repeat!!
    }
}