using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerlad : Enemy {

    // Use this for initialization
    void Start()
    {
        //items to replace will be {inside these brackets!}, write inside them/follow their instructions and then delete the brackets!
        name = "[GERALD]\n";

        dialogue.Add("\"Yes. I conducted business with Theodore as an investor for several years. What of it?”");

        dialogue.Add("\"Yes. I conducted business with Theo as an investor for several years. What of it?\"\n");
        options.Add("The two of you had squabbles over business. Is it better for you, now that he's out of the picture?\n");
        options.Add("Several years, huh. Apologies that it had to end like this. Surely this will impact your business.\n");
        options.Add("I understand you're going through a loss, but there's no need to be snappy. How was business with Theo?\n");
        options.Add("Sir, I'm currently exploring motives for his death. Did you two often clash over financials?\n");
        dialogue.Add("\"Hmph. Theo was more than generous lending his funds. The issue is that he had no business acumen to speak of.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 
        //it's important that you stick to ~2 types and properly ramp up to them or else the player will think they're unpredictable.

        dialogue.Add("\"Hmph. Theo was more than generous lending his funds. The issue is that he had no business acumen to speak of.\"\n");
        options.Add("How inconvenient for you, I'm sure. He must have only dragged you down. Must have been frustrating.\n");
        options.Add("You speak as if you were not extorting him of his wealth just like everyone else in his life.\n");
        options.Add("It doesn't seem a wise move to stick with him then. Unless he was the only only one willing to invest in you? Why stay?\n");
        options.Add("Were the two of you close? I get the feeling you were. I'd love some insight.\n");
        dialogue.Add("\"Fool that he may have been, it was not the money that brought us together. We've known each other since childhood.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response. 

        dialogue.Add("\"Fool that he may have been, it was not the money that brought us together. We've known each other since childhood.\"\n");
        options.Add("Close friends. A good cover for when you need to drain funds out of him. That what you were arguing about?\n");
        options.Add("You'd know everything about his then. That puts you in the perfect position to manipulate him.\n");
        options.Add("Ah. Why don't you support his hobbies then? Some friend, if you ask me.\n");
        options.Add("You have good judgement. Surely you have a good reason for disproving of him then. What were your fights over?\n");
        dialogue.Add("\"As his closest friend, I can only be detested by these seances, these fantastical notions Theo threw his effort and funds into.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        //rinse and repeat!!

        dialogue.Add("\"As his closest friend, I can only be detested by these seances, these fantastical notions Theo threw his effort and funds into.\"\n");
        options.Add("Could a close friend as yourself not have dissuaded Theo? It could not have been a difficult ask.\n");
        options.Add("Smart. By being here you allow yourself to continue playing the role as the knowledgable, wiser friend. Quite a gambit.\n");
        options.Add("You came here to dissuade him then. I suppose outright disapproval works where subtleties have failed.\n");
        options.Add("But still you attend. Do you have a motive? A greater purpose behind you being here?\n");
        dialogue.Add("\"Look. We dwell in a nest of vipers. I would not trust a single one of these vagrants with honest intentions.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"Look. We dwell in a nest of vipers. I would not trust a single one of these vagrants with honest intentions.\"\n");
        options.Add("A bold move, casting fingers while you yourself are under fire. You all used your dear 'friend' and you kept him in the dark.\n");
        options.Add("Oh? Why is that? Too much competition for you to navigate around? Theo would be harder to handle if he was in the know.\n");
        options.Add("Were you going to clue Theo into any of this? You didn't, right? Some friend you turned out to be.\n");
        options.Add("I guess the chance to tell him never arose then. He was clueless to the end, huh? Do you regret that?\n");
        dialogue.Add("\"Theo's incompetence...it was only in the back of my mind. Hah. Seems his credulity was ultimately his greatest vice.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"Theo's incompetence...it was only in the back of my mind. Hah. Seems his credulity was ultimately his greatest vice.\"\n");
        options.Add("Seems like there were a lot of things happening behind the scenes. And a world of things you never did to improve the situation.\n");
        options.Add("A better friend would have cared more for such a hapless individual. The shame is yours.\n");
        options.Add("In the end, that inattention cost him his life. Is there anything else you'd like to add, or?\n");
        options.Add("He deserved better. You were caught up in your own life, and that's understandable. But you were there for him.\n");//here is where the script ends
        dialogue.Add("\"I do not appreciate having my time wasted. Men of this day and age should understand effective brevity.\"\n");
        types.Add(4); // <- replace with 1(concede)/2(stand)/3(aggress)/4(insult) depending on the tone of enemy response.

        dialogue.Add("\"I do not appreciate having my time wasted. Men of this day and age should understand effective brevity.\"\n");
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
