using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DuelManager : MonoBehaviour {
    public Text textBox;

    //TO LINK A NEW ENEMY SCRIPT IN INSPECTOR: add it to the manager's game object, make it the first Enemy script on the object,
    //and then hook it up through the list in the inspector, this will add the script on the top of the list.
    public List<Enemy> enemies = new List<Enemy>();
    public int enemyId = 1; //enemy id! iterate through these to change the enemy script you reference.

    public GameObject tile; //GameObject for tile on board
    GameObject[] tiles = new GameObject[7]; //array of tiles. only important for intialization.
    //DuelSquare[] status = new DuelSquare[7]; //array of tiles' status, can be references to ex: change tile color.
    DuelSqSprite[] status = new DuelSqSprite[7]; //array of tiles' status, can be references to ex: change tile color.

    public bool inDuel = false; //is a duel currently in process? (for a few dialogue if statements)
    bool crtTable = true; //does a table need to be created?
    bool processTable = false; //does the table need to be updated?
    public bool playerWin = false; //if player has won
    public bool enemyWin = false; //if enemy has won
    public bool duelFinished = false; //if the duel is over

    int playerPos; //player's tile on the board: 0 to 6
    int playerLine; //the right-most tile player controls on the board.
    int playerType; //dialogue type player picks: 1 = concede, 2 = stand ground, 3 = aggressive, 4 = insult

    int enemyPos; //player's tile on the board: 0 to 6
    int enemyPosFactor; //saves the enemy movement so it can be used later.
    int enemyLine; //the left-most tile enemy controls on the board.
    int enemyType; //dialogue type enemy picks: 1 = concede, 2 = stand ground, 3 = aggressive, 4 = insult

    List<int> rand = new List<int>(4);
    int n;
    bool isValid = false;
    bool notInArray = true;
    string enemyTag = "";

    int step = 0; //enemy dialogue step, follow the documentation!
    int optStep = -4; //player's option dialogue! comes in sets of 4.
    int enTypeStep = -1; //line contains enemy's option number.
    bool combatRound = true;

    float letterPause = 0.04f; //amt of time before next letter prints.
    float extraPause = 0.1f; //extra pause used on commas and periods.
    bool typing = false; //is the coroutine typing?
    bool typingStart = false; //is it typing the intro line? used to handle skip
    bool typingResult = false; //is it typing a result line? used to handle skip
    bool typingLose = false; //is it typing the lose result line? used to handle skip
    Coroutine type;

    void Update () {


        if (inDuel == false && duelFinished == false && typing == false){
            //textBox.text = enemies[enemyId].dialogue[step]; //introduction text. limited to only one line of dialogue.
            textBox.text = "";
            type = StartCoroutine(TypeText(enemies[enemyId].name, enemies[enemyId].dialogue[step], ("\n\n[space]")));
            inDuel = true;
            typingStart = true;
        } else if (Input.GetKeyDown(KeyCode.Space) && typing == true && typingStart == true && duelFinished == false){
            StopCoroutine(type);
            typing = false;
            textBox.text = (enemies[enemyId].name + enemies[enemyId].dialogue[step] + "\n\n[space]");
            inDuel = true;
            typingStart = false;

        } else if (Input.GetKeyDown(KeyCode.Space) && inDuel == true && combatRound == true && typing == false)
        { //combat round.
            typingStart = false;
            typingResult = false;
            //iterate the steps in the enemy document
            step++;
            optStep += 4;
            enTypeStep++;
            combatRound = false;

            //detects end of enemy dialogue and resets so that it repeats.
            if (step == enemies[enemyId].dialogue.Count){ 
                step = 3; 
                optStep = 4;
                enTypeStep = 1;
            }

            if (processTable == true){
                ProcessCombat(); //reconciles effect of player type vs. enemy type
                ProcessMovement(); //reconciles a few overlap issues and sees if someone has won or not
                UpdateTable(); //visually updates the table
                processTable = false;
            }
            //if there's a winner, otherwise print next round:
            if (playerWin == true){
                textBox.text = (enemies[enemyId].options[optStep + (playerType-5)] + "\n\nPlayer wins!"); //displays the winning dialogue option, too!
                duelFinished = true;
                inDuel = false;

            }else if (enemyWin == true){
                //textBox.text = (enemies[enemyId].dialogue[step] + "\n\nEnemy wins!"); //displays the winning dialogue option, too!
                textBox.text = "";
                type = StartCoroutine(TypeText("", enemies[enemyId].dialogue[step], "\n\nEnemy wins!"));
                typingLose = true;
                duelFinished = true;
                inDuel = false;
                if (Input.GetKeyDown(KeyCode.Space) && typing == true && typingLose == true)
                {
                    StopCoroutine(type);
                    typing = false;
                    textBox.text = (enemies[enemyId].dialogue[step] + "\n\nEnemy wins!");
                    typingLose = false;
                    inDuel = false;
                }
            }
                else{
                //displays next round of dialogue + choices

                rand.Clear();
                for (int i = 0; i < 4; i++){
                   n = Random.Range(0, 4);
                   while (rand.Contains(n)){
                        n = Random.Range(0, 4);
                    }
                    rand.Add(n);
                }

                Debug.Log(rand[0] + " " + rand[1] + " " + rand[2] + " " + rand[3]);

                //textBox.text = (enemies[enemyId].dialogue[step] + "[1] " + enemies[enemyId].options[optStep] + "[2] " + enemies[enemyId].options[optStep + 1] +
                //"[3] " + enemies[enemyId].options[optStep + 2] + "[4] " + enemies[enemyId].options[optStep + 3]);

                textBox.text = (enemies[enemyId].dialogue[step] + "[1] " + enemies[enemyId].options[optStep + rand[0]] + "[2] " + enemies[enemyId].options[optStep + rand[1]] +
                                      "[3] " + enemies[enemyId].options[optStep + rand[2]] + "[4] " + enemies[enemyId].options[optStep + rand[3]]);
            }
        }
       
        //result round. tells the player what they picked + the enemy reaction.
        //[WIP] enemy dialogue shouldn't display if this is the round where the player wins (an option is to just remove it but i like the drama it elicits) 
        else if (step > 0 && Input.GetKeyDown(KeyCode.Alpha1) && inDuel == true && combatRound == false) { //player chooses [1]
            step++;
            playerType = rand[0]+1;
            Debug.Log("playerType is: " + playerType);
            switch (playerType){
                case 1:
                    textBox.text = "[concede] ";
                    break;
                case 2:
                    textBox.text = "[stand] ";
                    break;
                case 3:
                    textBox.text = "[aggress] ";
                    break;
                case 4:
                    textBox.text = "[insult] ";
                    break;
            }
            enemyType = enemies[enemyId].types[enTypeStep];
            switch (enemyType){
                case 1:
                    enemyTag = "[concede] ";
                    break;
                case 2:
                    enemyTag = "[stand] ";
                    break;
                case 3:
                    enemyTag = "[aggress] ";
                    break;
                case 4:
                    enemyTag = "[insult] ";
                    break;
            }

            type = StartCoroutine(TypeText((enemies[enemyId].options[optStep-1+playerType] + "\n"), (enemyTag + enemies[enemyId].dialogue[step]), ("\n [space]")));
            processTable = true;
            combatRound = true;
            typingResult = true;

        } else if (step > 0 && Input.GetKeyDown(KeyCode.Alpha2) && inDuel == true && combatRound == false){ //player chooses [2]
            step++;
            playerType = rand[1]+1;
            Debug.Log("playerType is: " + playerType);
            switch (playerType){
                case 1:
                    textBox.text = "[concede] ";
                    break;
                case 2:
                    textBox.text = "[stand] ";
                    break;
                case 3:
                    textBox.text = "[aggress] ";
                    break;
                case 4:
                    textBox.text = "[insult] ";
                    break;
            }
            enemyType = enemies[enemyId].types[enTypeStep];
            switch (enemyType){
                case 1:
                    enemyTag = "[concede] ";
                    break;
                case 2:
                    enemyTag = "[stand] ";
                    break;
                case 3:
                    enemyTag = "[aggress] ";
                    break;
                case 4:
                    enemyTag = "[insult] ";
                    break;
            }

            type = StartCoroutine(TypeText((enemies[enemyId].options[optStep - 1 + playerType] + "\n"), (enemyTag + enemies[enemyId].dialogue[step]), ("\n [space]")));
            //textBox.text = (enemies[enemyId].options[optStep-1+playerType] + "\n" + enemies[enemyId].dialogue[step] + "\n [space]");
            processTable = true;
            combatRound = true;
            typingResult = true;

        } else if (step > 0 && Input.GetKeyDown(KeyCode.Alpha3) && inDuel == true && combatRound == false){ //player chooses [3]
            step++;
            playerType = rand[2]+1;
            Debug.Log("playerType is: " + playerType);
            switch (playerType){
                case 1:
                    textBox.text = "[concede] ";
                    break;
                case 2:
                    textBox.text = "[stand] ";
                    break;
                case 3:
                    textBox.text = "[aggress] ";
                    break;
                case 4:
                    textBox.text = "[insult] ";
                    break;
            }
            enemyType = enemies[enemyId].types[enTypeStep];
            switch (enemyType){
                case 1:
                    enemyTag = "[concede] ";
                    break;
                case 2:
                    enemyTag = "[stand] ";
                    break;
                case 3:
                    enemyTag = "[aggress] ";
                    break;
                case 4:
                    enemyTag = "[insult] ";
                    break;
            }
            type = StartCoroutine(TypeText((enemies[enemyId].options[optStep - 1 + playerType] + "\n"), (enemyTag + enemies[enemyId].dialogue[step]), ("\n [space]")));
            //textBox.text = (enemies[enemyId].options[optStep-1+playerType] + "\n" + enemies[enemyId].dialogue[step] + "\n [space]");
            processTable = true;
            combatRound = true;
            typingResult = true;

        } else if (step > 0 && Input.GetKeyDown(KeyCode.Alpha4) && inDuel == true && combatRound == false){ //player chooses [4]
            step++;
            playerType = rand[3]+1;
            Debug.Log("playerType is: " + playerType);
            switch (playerType){
                case 1:
                    textBox.text = "[concede] ";
                    break;
                case 2:
                    textBox.text = "[stand] ";
                    break;
                case 3:
                    textBox.text = "[aggress] ";
                    break;
                case 4:
                    textBox.text = "[insult] ";
                    break;
            }
            enemyType = enemies[enemyId].types[enTypeStep];
            switch (enemyType){
                case 1:
                    enemyTag = "[concede] ";
                    break;
                case 2:
                    enemyTag = "[stand] ";
                    break;
                case 3:
                    enemyTag = "[aggress] ";
                    break;
                case 4:
                    enemyTag = "[insult] ";
                    break;
            }
            type = StartCoroutine(TypeText((enemies[enemyId].options[optStep - 1 + playerType] + "\n"), (enemyTag + enemies[enemyId].dialogue[step]), ("\n [space]")));
            //textBox.text = (enemies[enemyId].options[optStep-1+playerType] + "\n" + enemies[enemyId].dialogue[step] + "\n [space]");
            processTable = true;
            combatRound = true;
            typingResult = true;
        } else if (Input.GetKeyDown(KeyCode.Space) && typing == true && typingResult == true && duelFinished == false){
            StopCoroutine(type);
            typing = false;
            textBox.text = (enemies[enemyId].options[optStep - 1 + playerType] + "\n" + enemies[enemyId].dialogue[step] + "\n [space]");
            typingResult = false;
        }

        //beginning of duel. create that table.
        if (step == 1 && crtTable == true){ 
            CreateTable();
            UpdateTable();
        }

    }

    IEnumerator TypeText (string begin, string message, string end) { //scrolling text!
        typing = true;
        textBox.text += begin;
        foreach (char letter in message.ToCharArray()) {
            textBox.text += letter;
            //if (typeSound1 && typeSound2){ //[WIP] Sound! Can be implemented later!
            //    SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);
            //    yield return 0;
            //}
            if (letter == '.'){
                yield return new WaitForSeconds (letterPause + extraPause + extraPause);
            } else if (letter == ',' || letter == ';'){
                yield return new WaitForSeconds(letterPause + extraPause);
            } else {
                yield return new WaitForSeconds(letterPause);
            }
        }
        typing = false;
        textBox.text += end;
    }

    void ProcessCombat(){ //compares player and enemy type and decides what the interaction does
        enemyType = enemies[enemyId].types[enTypeStep];
        if (playerType == 1){ //concede
            if (enemyType == 1){
                playerPos -= 1;
                enemyPosFactor = 1;
            }
            else if (enemyType == 2){
                playerPos -= 1;
                enemyPosFactor = 0;
            }
            else if (enemyType == 3){
                playerPos -= 1;
                enemyPosFactor = -1;
            }
            else if (enemyType == 4){
                playerPos -= 2;
                enemyPosFactor = -2;
            }

        } else if (playerType == 2){ //stand
            if (enemyType == 1){
                playerPos += 0;
                enemyPosFactor = 1;
            }
            else if (enemyType == 2){
                playerPos += 0;
                enemyPosFactor = 0;
            }
            else if (enemyType == 3){
                playerPos += 1;
                enemyPosFactor = 0;
            }
            else if (enemyType == 4){
                playerPos += 0;
                enemyPosFactor = -1;
            }

        } else if (playerType == 3){ //agress
            if (enemyType == 1){
                playerPos += 1;
                enemyPosFactor = 1;
            }
            else if (enemyType == 2){
                playerPos += 0;
                enemyPosFactor = -1;
            }
            else if (enemyType == 3){
                playerPos += 1;
                enemyPosFactor = -1;
            }
            else if (enemyType == 4){
                playerPos += 1;
                enemyPosFactor = 0;
            }

        } else{ //insult
            if (enemyType == 1){
                playerPos += 2;
                enemyPosFactor = 2;
            }
            else if (enemyType == 2){
                playerPos += 1;
                enemyPosFactor = 0;
            }
            else if (enemyType == 3){
                playerPos += 0;
                enemyPosFactor = -1;
            }
            else if (enemyType == 4){
                playerPos += 1;
                enemyPosFactor = -1;
            }
        }
        Debug.Log(playerType + " " + enemyType);
        playerLine = playerPos;
    }

    void ProcessMovement(){ 
        if (enemyPos > 6 || playerLine > enemyPos || playerPos == enemyPos){ //detect player win. this goes first because they had the first attack.
            playerWin = true;
            if (enemyPos <= 6){
                status[enemyPos].struck = true;
            }
        }
        else{ //else statement used here so enemy doesn't move upon losing.

            enemyPos += enemyPosFactor;
            enemyLine = enemyPos;

            if (enemyPos > 6){
                playerWin = true;
            }

            if (playerPos < 0){ //idk why this needed its own if statement but it did.
                enemyWin = true;
            }
            if (enemyLine < playerPos || playerPos == enemyPos){ //detect enemy win.
                enemyWin = true;
                if (playerPos >= 0){
                    status[playerPos].struck = true;
                }
            }

        }
    }

    void UpdateTable(){ //visual updates to table
        for (int i = 0; i < status.Length; i++){ 
            if (i <= playerLine){
                status[i].state = 1;
            }
            else if (i >= enemyLine){
                status[i].state = 2;
            }
            else{
                status[i].state = 0;
            }

            if (i == playerPos){
                status[i].hasPlayer = true;
            }
            else{
                status[i].hasPlayer = false;
            }

            if (i == enemyPos){
                status[i].hasEnemy = true;
            }
            else{
                status[i].hasEnemy = false;
            }
        }
    }

    public void Reset(){

        for (int i = 0; i < tiles.Length; i++)
        {
            Destroy(status[i]);
            Destroy(tiles[i]);
        }

        //tiles = new GameObject[7]; //array of tiles. only important for intialization.
        //status = new DuelSqSprite[7];

        inDuel = false; //is a duel currently in process? (for a few dialogue if statements)
        crtTable = true; //does a table need to be created?
        processTable = false; //does the table need to be updated?
        playerWin = false; //if player has won
        enemyWin = false; //if enemy has won
        duelFinished = false;

        step = 0; //enemy dialogue step, follow the documentation!
        optStep = -4; //player's option dialogue! comes in sets of 4.
        enTypeStep = -1; //line contains enemy's option number.
        combatRound = true;

        typingStart = false; 
        typingResult = false; 
        typingLose = false;

        //CreateTable();
        //UpdateTable();

        textBox.text = "";

    }

    void CreateTable(){ //construct the whole dang table
        tiles = new GameObject[7]; //array of tiles. only important for intialization.
        status = new DuelSqSprite[7];

        for (int i = 0; i < tiles.Length; i++){ //make them tiles
            tiles[i] = Instantiate(tile) as GameObject;
            tiles[i].SetActive(true);
            tiles[i].transform.Translate((2.3f * i), 0.65f, 0);
            status[i] = tiles[i].GetComponent<DuelSqSprite>();
        }
        crtTable = false;

        //sets beginning tile states
        status[0].state = 1;
        status[1].state = 1;
        status[2].state = 0;
        status[3].state = 0;
        status[4].state = 0;
        status[5].state = 2;
        status[6].state = 2;

        playerLine = 1;
        enemyLine = 5;

        playerPos = 1;
        enemyPos = 5;

        status[playerPos].hasPlayer = true;
        status[enemyPos].hasEnemy = true;
    }

}
