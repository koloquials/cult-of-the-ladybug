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
    DuelSquare[] status = new DuelSquare[7]; //array of tiles' status, can be references to ex: change tile color.

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
    int enemyLine; //the left-most tile enemy controls on the board.
    int enemyType; //dialogue type enemy picks: 1 = concede, 2 = stand ground, 3 = aggressive, 4 = insult

    int step = 0; //enemy dialogue step, follow the documentation!
    int optStep = -4; //player's option dialogue! comes in sets of 4.
    int enTypeStep = -1; //line contains enemy's option number.
    bool combatRound = true;

    void Start () {
        //enemy = GetComponent<Enemy>();
    }

    void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && inDuel == false && duelFinished == false){
            textBox.text = enemies[enemyId].dialogue[step]; //introduction text. limited to only one line of dialogue.
            inDuel = true;
        } else if (Input.GetKeyDown(KeyCode.Space) && inDuel == true && combatRound == true){ //combat round.

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
                //needs to exit.
                //note to vera, use these on the main dialogue script:
                //MyGameObject.GetComponent<MyScript>().enabled = false; //toggle this script to re-invoke duel
                //MyGameObject.GetComponent<MyScript>().enabled = true;

            }else if (enemyWin == true){
                textBox.text = (enemies[enemyId].dialogue[step] + "\n\nEnemy wins!"); //displays the winning dialogue option, too!
                duelFinished = true;
                //needs to exit.
                //note to vera, use these on the main dialogue script:
                //MyGameObject.GetComponent<MyScript>().enabled = false; //toggle this script to re-invoke duel
                //MyGameObject.GetComponent<MyScript>().enabled = true;
            }else{ 
                //displays next round of dialogue + choices
                textBox.text = (enemies[enemyId].dialogue[step] + "[1][concede] " + enemies[enemyId].options[optStep] + "[2][stand] " + enemies[enemyId].options[optStep + 1] + 
                                "[3][aggress] " + enemies[enemyId].options[optStep + 2] + "[4][insult] " + enemies[enemyId].options[optStep + 3]);
            }
        }
        //result round. tells the player what they picked + the enemy reaction.
        //[WIP] enemy dialogue shouldn't display if this is the round where the player wins (an option is to just remove it but i like the drama it elicits) 
        else if (step > 0 && Input.GetKeyDown(KeyCode.Alpha1) && inDuel == true && combatRound == false) { //player chooses [1]
            step++;
            textBox.text = (enemies[enemyId].options[optStep] + "\n" + enemies[enemyId].dialogue[step] + "\n [space]");
            playerType = 1;
            processTable = true;
            combatRound = true;

        } else if (step > 0 && Input.GetKeyDown(KeyCode.Alpha2) && inDuel == true && combatRound == false){ //player chooses [2]
            step++;
            textBox.text = (enemies[enemyId].options[optStep+1] + "\n" + enemies[enemyId].dialogue[step] + "\n [space]");
            playerType = 2;
            processTable = true;
            combatRound = true;

        } else if (step > 0 && Input.GetKeyDown(KeyCode.Alpha3) && inDuel == true && combatRound == false){ //player chooses [3]
            step++;
            textBox.text = (enemies[enemyId].options[optStep+2] + "\n" + enemies[enemyId].dialogue[step] + "\n [space]");
            playerType = 3;
            processTable = true;
            combatRound = true;

        } else if (step > 0 && Input.GetKeyDown(KeyCode.Alpha4) && inDuel == true && combatRound == false){ //player chooses [4]
            step++;
            textBox.text = (enemies[enemyId].options[optStep+3] + "\n" + enemies[enemyId].dialogue[step] + "\n [space]");
            playerType = 4;
            processTable = true;
            combatRound = true;
        }

        //beginning of duel. create that table.
        if (step == 1 && crtTable == true){ 
            CreateTable();
        }

    }

    void ProcessCombat(){ //compares player and enemy type and decides what the interaction does
        enemyType = enemies[enemyId].types[enTypeStep];
        if (playerType == 1){ //concede
            if (enemyType == 1){
                playerLine -= 1;
                enemyLine += 1;
            }
            else if (enemyType == 2){
                playerLine -= 1;
                enemyLine -= 1;
            } else if (enemyType == 3){
                playerLine += 1;
                enemyLine += 1;
            } else if (enemyType == 4){
                playerLine -= 1;
                enemyLine -= 1;
            }
            playerPos -= 1;

        } else if (playerType == 2){ //stand
            if (enemyType == 1){
                playerLine += 1;
                enemyLine += 1;
            }
            else if (enemyType == 2){
                playerLine += 0;
                enemyLine += 0;
            }
            else if(enemyType == 3){
                playerLine += 1;
                enemyLine += 1;
            }
            else if (enemyType == 4){
                playerLine -= 1;
                enemyLine -= 1;
            }
            playerPos -= 0;

        } else if (playerType == 3){ //agress
            if (enemyType == 1){
                playerLine -= 1;
                enemyLine -= 1;
            }
            else if (enemyType == 2){
                playerLine -= 1;
                enemyLine -= 1;
            }
            else if(enemyType == 3){
                playerLine += 0;
                enemyLine += 0;
            }
            else if (enemyType == 4){
                playerLine += 1;
                enemyLine += 1;
            }
            playerPos += 1;

        } else{ //insult
            if (enemyType == 1){
                playerLine += 1;
                enemyLine += 1;
            }
            else if (enemyType == 2){
                playerLine += 1;
                enemyLine += 1;
            }
            else if (enemyType == 3){
                playerLine -= 1;
                enemyLine -= 1;
            }
            else if (enemyType == 4){
                playerLine += 0;
                enemyLine += 0;
            }
            playerPos += 1;
        }
    }

    void ProcessMovement(){ //reconciles spacing issue and nudges duelists on the board, detects win or lose state.
        if (playerPos >= enemyLine){ //player pushes forward into enemy space if on the edge.
            enemyLine = playerPos + 1;
            playerLine = playerPos;
        }
        if (enemyPos > 6 || playerLine > enemyPos || playerPos == enemyPos){ //detect player win. this goes first because they had the first attack.
            playerWin = true;
            if (enemyPos <= 6){
                status[enemyPos].struck = true;
            }
            //Debug.Log("player pos: " + playerPos + ", player line: " + playerLine + " | enemy pos: " + enemyPos + ", en line: " + enemyLine);
            //Debug.Log("player wins");
        }
        else{ //else statement used here so enemy doesn't move upon losing.

            //move the enemy depending on dialogue type.
            if (enemyType == 1){
                enemyPos += 1;
            }
            if (enemyType == 3){
                enemyPos -= 1;
            }
            else if (enemyType == 4){
                enemyPos -= 0;
            }

            if (enemyPos <= playerLine){ //enemy pushes forward into player space if on the edge.
                playerLine = enemyPos - 1;
                enemyLine = enemyPos;
            }

            if (playerPos < 0){ //idk why this needed its own if statement but it did.
                enemyWin = true; ;
            }
            if (playerPos < 0 || enemyLine < playerPos || playerPos == enemyPos){ //detect enemy win.
                enemyWin = true;
                if (playerPos >= 0){
                    status[playerPos].struck = true;
                }
                //Debug.Log("player pos: " + playerPos + ", player line: " + playerLine + " | enemy pos: " + enemyPos + ", en line: " + enemyLine);
                //Debug.Log("player loses");
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

    void CreateTable(){ //construct the whole dang table
        for (int i = 0; i < tiles.Length; i++){ //make them tiles
            tiles[i] = Instantiate(tile) as GameObject;
            tiles[i].transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            tiles[i].transform.Translate((170 * i), 0, 0);
            status[i] = tiles[i].GetComponent<DuelSquare>();
        }
        crtTable = false;

        //sets beginning tile states
        status[0].state = 1;
        status[1].state = 1;
        status[2].state = 1;
        status[3].state = 2;
        status[4].state = 2;
        status[5].state = 2;
        status[6].state = 2;

        playerLine = 2;
        enemyLine = 3;

        playerPos = 1;
        enemyPos = 5;

        status[playerPos].hasPlayer = true;
        status[enemyPos].hasEnemy = true;
    }

}
