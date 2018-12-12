using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DuelManager : MonoBehaviour {
    public Text textBox; //Text container for the player's dialogue
    public Text enemyBox; //Text container for the enemy's dialogue

    public List<Enemy> enemies = new List<Enemy>();
    public int enemyId = 1; //enemy id! iterate through these to change the enemy script you reference.
    public bool resumeInterrogation = false;

    public GameObject tile; //GameObject for tile on board
    GameObject[] tiles = new GameObject[7]; //array of tiles. only important for intialization.
    DuelSqSprite[] status = new DuelSqSprite[7]; //array of tiles' status, can be references to ex: change tile color.

    public bool inDuel = false; //is a duel currently in process? (for a few dialogue if statements)
    bool crtTable = true; //does a table need to be created?
    bool processTable = false; //does the table need to be updated?
    public bool playerWin = false; //if player has won
    public bool playerLose = false; //if enemy has won
    public bool duelFinished = false; //if the duel is over

    private bool hasPlayed = false;
    public AudioSource importantSFX;
    public AudioClip success;
    public AudioClip failure;


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

    void Update()
    {
        if (inDuel == false && duelFinished == false && typing == false && resumeInterrogation == false){
            enemyBox.text = "";
            type = StartCoroutine(TypeText(enemies[enemyId].name, enemies[enemyId].dialogue[step], ("\n\n[space]")));
            inDuel = true;
            typingStart = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && typing == true && typingStart == true && duelFinished == false && resumeInterrogation == false){
            StopCoroutine(type);
            typing = false;
            enemyBox.text = (enemies[enemyId].name + enemies[enemyId].dialogue[step] + "\n\n[space]");
            inDuel = true;
            typingStart = false;

        }

        if (inDuel == false && duelFinished == false && typing == false && resumeInterrogation == true){
            enemyBox.text = "";
            type = StartCoroutine(TypeText(enemies[enemyId].name, enemies[enemyId].returnText, ("\n\n[space]")));
            inDuel = true;
            typingStart = true;
            step = enemies[enemyId].resumedStep;
            optStep = enemies[enemyId].resumedOptStep;
            enTypeStep = enemies[enemyId].resumedEnTypeStep;
            Debug.Log("RESUMED: step[" + step + "], optStep[" + optStep + "], enTypeStep[" + enTypeStep + "]");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && typing == true && typingStart == true && duelFinished == false && resumeInterrogation == true){
            StopCoroutine(type);
            typing = false;
            enemyBox.text = (enemies[enemyId].name + enemies[enemyId].returnText + "\n\n[space]");
            inDuel = true;
            typingStart = false;

        }

        else if (Input.GetKeyDown(KeyCode.Space) && inDuel == true && combatRound == true && typing == false)
        { //combat round.
            typingStart = false;
            typingResult = false;

            //iterate the steps in the enemy document
            step++;
            optStep += 4;
            enTypeStep++;
            combatRound = false;
            Debug.Log("A: step[" + step + "], optStep[" + optStep + "], enTypeStep [" + enTypeStep + "]");

            //detects end of enemy dialogue and resets so that it repeats.
            if (step == enemies[enemyId].dialogue.Count)
            {
                step = 3;
                optStep = 4;
                enTypeStep = 1;
            }

            if (processTable == true) {
                ProcessCombat(); //reconciles effect of player type vs. enemy type
                ProcessMovement(); //reconciles a few overlap issues and sees if someone has won or not
                UpdateTable(); //visually updates the table
                processTable = false;
            }

            //if there's a winner,
            if (playerWin == true){
                enemyBox.text = (enemies[enemyId].options[optStep + (playerType - 5)] + "\n\nBreakthrough!"); //displays the winning dialogue option, too!
                duelFinished = true;
                inDuel = false;

            } else if (playerLose == true){
                enemyBox.text = "";
                type = StartCoroutine(TypeText("", enemies[enemyId].dialogue[step], "\n\nInterrogation failed."));
                typingLose = true;
                duelFinished = true;
                inDuel = false;
                if (Input.GetKeyDown(KeyCode.Space) && typing == true && typingLose == true){
                    StopCoroutine(type);
                    typing = false;
                    enemyBox.text = (enemies[enemyId].dialogue[step] + "\n\nInterrogation failed.");
                    typingLose = false;
                    inDuel = false;

                    //enemies[enemyId].resumedStep = step;
                    //enemies[enemyId].resumedOptStep = optStep;
                    //enemies[enemyId].resumedEnTypeStep = enTypeStep;
                    //enemies[enemyId].resumeInterrogation = true;
                    //enemies[enemyId].resumedPlayerPos = playerPos;

                    //if ((playerPos + enemies[enemyId].startPos) > 6){
                    //    enemies[enemyId].resumedEnemyPos = 6;
                    //} else {
                    //    enemies[enemyId].resumedEnemyPos = (playerPos + enemies[enemyId].startPos);
                    //}

                    //print(enemies[enemyId].resumedStep);
                    //resumeInterrogation = true;

                }

            }
            //otherwise, displays next round of dialogue + choices
            else{
                rand.Clear();
                for (int i = 0; i < 4; i++){
                    n = Random.Range(0, 4);
                    while (rand.Contains(n)){
                        n = Random.Range(0, 4);
                    }
                    rand.Add(n);
                }
                Debug.Log(rand[0] + " " + rand[1] + " " + rand[2] + " " + rand[3]);
                enemyBox.text = (enemies[enemyId].dialogue[step]);
                textBox.text = ("[1] " + enemies[enemyId].options[optStep + rand[0]] + "[2] " + enemies[enemyId].options[optStep + rand[1]] +
                                      "[3] " + enemies[enemyId].options[optStep + rand[2]] + "[4] " + enemies[enemyId].options[optStep + rand[3]]);
            }
        }

        //result round. tells the player what they picked + the enemy reaction.
        else if (step > 0 && Input.GetKeyDown(KeyCode.Alpha1) && inDuel == true && combatRound == false){ //player chooses [1]
            step++;
            playerType = rand[0] + 1;
            enemyType = enemies[enemyId].types[enTypeStep];
            DetermineType(playerType, enemyType);
            Debug.Log("B: step[" + step + "], optStep[" + optStep + "], enTypeStep [" + enTypeStep + "]");

        }
        else if (step > 0 && Input.GetKeyDown(KeyCode.Alpha2) && inDuel == true && combatRound == false){ //player chooses [2]
            step++;
            playerType = rand[1] + 1;
            enemyType = enemies[enemyId].types[enTypeStep];
            DetermineType(playerType, enemyType);

        }
        else if (step > 0 && Input.GetKeyDown(KeyCode.Alpha3) && inDuel == true && combatRound == false){ //player chooses [3]
            step++;
            playerType = rand[2] + 1;
            enemyType = enemies[enemyId].types[enTypeStep];
            DetermineType(playerType, enemyType);

        }
        else if (step > 0 && Input.GetKeyDown(KeyCode.Alpha4) && inDuel == true && combatRound == false){ //player chooses [4]
            step++;
            playerType = rand[3] + 1;
            enemyType = enemies[enemyId].types[enTypeStep];
            DetermineType(playerType, enemyType);

        }
        else if (Input.GetKeyDown(KeyCode.Space) && typing == true && typingResult == true && duelFinished == false)
        {
            StopCoroutine(type);
            typing = false;
            textBox.text = (enemies[enemyId].options[optStep - 1 + playerType] + "\n [space]");
            enemyBox.text = (enemies[enemyId].dialogue[step]);
            typingResult = false;
        }

        //beginning of duel. create that table.
        if (step == 1 && crtTable == true){
            CreateTable();
            UpdateTable();
        } else if(step>1 && crtTable == true){
            ResumeTable();
            UpdateTable();
        }

    }

    IEnumerator TypeText(string begin, string message, string end)
    { //scrolling text!
        typing = true;
        enemyBox.text += begin;
        foreach (char letter in message.ToCharArray())
        {
            enemyBox.text += letter;
            //if (typeSound1 && typeSound2){ //[WIP] Sound! Can be implemented later!
            //    SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);
            //    yield return 0;
            //}
            if (letter == '.')
            {
                yield return new WaitForSeconds(letterPause + extraPause + extraPause);
            }
            else if (letter == ',' || letter == ';')
            {
                yield return new WaitForSeconds(letterPause + extraPause);
            }
            else
            {
                yield return new WaitForSeconds(letterPause);
            }
        }
        typing = false;
        enemyBox.text += end;
    }

    void DetermineType(int playerTy, int enemyTy)
    {
        Debug.Log("playerType is: " + playerTy);
        hasPlayed = false;
        switch (playerTy){
            case 1:
                textBox.text = "";
                if (!hasPlayed)
                {
                    importantSFX.PlayOneShot(failure);
                    Debug.Log("failure");
                }
                hasPlayed = true;
                Debug.Log("[very bad] ");
                break;
            case 2:
                textBox.text = "";
                if (!hasPlayed)
                {
                    importantSFX.PlayOneShot(failure);
                    Debug.Log("failure");
                }
                hasPlayed = true;
                Debug.Log("[bad] ");
                break;
            case 3:
                textBox.text = "";
                if (!hasPlayed)
                {
                    importantSFX.PlayOneShot(failure);
                    Debug.Log("failure");
                }
                hasPlayed = true;
                Debug.Log("[okay] ");
                break;
            case 4:
                //where the correct answer is shown
                textBox.text = "[!] ";

                //play important sfx here
                if (!hasPlayed)
                {
                    importantSFX.PlayOneShot(success);
                    Debug.Log("success");
                }
                hasPlayed = true;

                Debug.Log("[great] ");
                break;
        }

        textBox.text = (enemies[enemyId].options[optStep - 1 + playerType]);
        enemyBox.text = "";
        type = StartCoroutine(TypeText((""), (enemies[enemyId].dialogue[step]), ("\n [space]")));

        processTable = true;
        combatRound = true;
        typingResult = true;
    }

    void ProcessCombat() { //compares player and enemy type and decides what the interaction does
        enemyType = enemies[enemyId].types[enTypeStep];
        if (playerType == enemyType) { //correct
            playerPos += 1;
            enemyPos += 0;
        } else {
            playerPos += 1;
            enemyPos += 1;
            Camera.main.GetComponent<ScreenShake>().shakeDuration = 1f;
            Camera.main.GetComponent<ScreenShake>().Shake();
        }
        Debug.Log(playerType + " " + enemyType);
        playerLine = playerPos;
        enemyLine = enemyPos;
    }

    void ProcessMovement(){
        if (enemyPos > 6){
            playerLose = true;
        } else if (playerPos == enemyPos) {
            playerWin = true;
            status[playerPos].struck = true;
        }
    }

    void UpdateTable()
    { //visual updates to table
        for (int i = 0; i < status.Length; i++){
            if (i <= playerLine){
                status[i].state = 1;
            } else if (i >= enemyLine){
                status[i].state = 0;
            } else{
                status[i].state = 0;
            }

            if (i == playerPos){
                status[i].hasPlayer = true;
            } else {
                status[i].hasPlayer = false;
            }

            if (i == enemyPos){
                status[i].hasEnemy = true;
            } else{
                status[i].hasEnemy = false;
            }
        }
    }

    public void Reset(){

        for (int i = 0; i < tiles.Length; i++){
            Destroy(status[i]);
            Destroy(tiles[i]);
        }


        inDuel = false; //is a duel currently in process? (for a few dialogue if statements)
        crtTable = true; //does a table need to be created?
        processTable = false; //does the table need to be updated?
        playerWin = false; //if player has won
        playerLose = false; //if enemy has won
        duelFinished = false;

        step = 0; //enemy dialogue step, follow the documentation!
        optStep = -4; //player's option dialogue! comes in sets of 4.
        enTypeStep = -1; //line contains enemy's option number.
        combatRound = true;

        typingStart = false;
        typingResult = false;
        typingLose = false;

        textBox.text = "";
        enemyBox.text = "";

    }

    void CreateTable()
    { //construct the whole dang table
        tiles = new GameObject[7]; //array of tiles. only important for intialization.
        status = new DuelSqSprite[7];

        for (int i = 0; i < tiles.Length; i++){ //make them tiles
            tiles[i] = Instantiate(tile) as GameObject;
            tiles[i].gameObject.transform.SetParent(FindObjectOfType<Camera>().transform);
            tiles[i].SetActive(true);
            tiles[i].transform.Translate((FindObjectOfType<Camera>().transform.position.x+(2.3f * i)), FindObjectOfType<Camera>().transform.position.y + 0.65f, -1f);
            status[i] = tiles[i].GetComponent<DuelSqSprite>();
            tiles[i].GetComponent<SpriteRenderer>().sortingLayerName = "Duel Tiles"; //makes the part of a new sorting layer
        }
        crtTable = false;

        //sets beginning tile states
        status[0].state = 1;
        status[1].state = 0;
        status[2].state = 0;
        status[3].state = 0;
        status[4].state = 0;
        status[5].state = 0;
        status[6].state = 0;

        playerPos = 0;
        enemyPos = enemies[enemyId].startPos;

        playerLine = playerPos;
        enemyLine = enemyPos;

        status[playerPos].hasPlayer = true;
        status[enemyPos].hasEnemy = true;
    }

    void ResumeTable(){
        tiles = new GameObject[7]; //array of tiles. only important for intialization.
        status = new DuelSqSprite[7];

        for (int i = 0; i < tiles.Length; i++)
        { //make them tiles
            tiles[i] = Instantiate(tile) as GameObject;
            tiles[i].gameObject.transform.SetParent(FindObjectOfType<Camera>().transform);
            tiles[i].SetActive(true);
            tiles[i].transform.Translate((FindObjectOfType<Camera>().transform.position.x+(2.3f * i)), FindObjectOfType<Camera>().transform.position.y + 0.65f, -1f);
            status[i] = tiles[i].GetComponent<DuelSqSprite>();
            tiles[i].GetComponent<SpriteRenderer>().sortingLayerName = "Duel Tiles"; //makes the part of a new sorting layer
        }
        crtTable = false;

        //sets beginning tile states
        status[0].state = 1;
        status[1].state = 0;
        status[2].state = 0;
        status[3].state = 0;
        status[4].state = 0;
        status[5].state = 0;
        status[6].state = 0;

        playerPos = enemies[enemyId].resumedPlayerPos;
        enemyPos = enemies[enemyId].resumedEnemyPos;



        playerLine = playerPos;
        enemyLine = enemyPos;

        status[playerPos].hasPlayer = true;
        status[enemyPos].hasEnemy = true;
    }

}
