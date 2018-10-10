using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DuelManager : MonoBehaviour {
    public Text textBox;
    bool inDuel = false;
    AgrEnemy aggro;
    int step = 0;
    int optStep = -4;
    int enTypeStep = -1;
    bool createTable = true;

    public GameObject tile;
    GameObject[] tiles = new GameObject[7];
    DuelSquare[] status = new DuelSquare[7];
    bool updateTable = false;

    int playerPos;
    int playerLine;
    int playerType;
    int enemyPos;
    int enemyLine;
    int enemyType;

    bool enemyWin = false;
    bool playerWin = false;

    bool duelFinished = false;
    int optNum;

    void Start () {
        aggro = GetComponent<AgrEnemy>();
    }

    void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && inDuel == false && duelFinished == false){
            textBox.text = aggro.dialogue[step];
            inDuel = true;
        } else if (Input.GetKeyDown(KeyCode.Space) && inDuel == true && (step%2 == 0)){

            step++;
            optStep += 4;
            enTypeStep++;
            if (step == 13){
                step = 3; 
                optStep = 4;
                enTypeStep = 1;
            }
            //Debug.Log(step);

            if (updateTable == true)
            {
                enemyType = aggro.types[enTypeStep];
                //status[3].state = 1;
                if (playerType == 1){ //concede
                    if (enemyType == 3){
                        playerLine += 1;
                        enemyLine += 1;
                    } else if (enemyType == 4){
                        playerLine -= 1;
                        enemyLine -= 1;
                    }

                    playerPos -= 1;

                } else if (playerType == 2){ //stand
                    if (enemyType == 3){
                        playerLine += 1;
                        enemyLine += 1;
                    }
                    else if (enemyType == 4){
                        playerLine -= 1;
                        enemyLine -= 1;
                    }
                    playerPos -= 0;

                } else if (playerType == 3){ //agress
                    if (enemyType == 3){
                        playerLine += 0;
                        enemyLine += 0;
                    }
                    else if (enemyType == 4){
                        playerLine += 1;
                        enemyLine += 1;
                    }
                    playerPos += 1;

                } else{ //insult
                    if (enemyType == 3){
                        playerLine -= 1;
                        enemyLine -= 1;
                    }
                    else if (enemyType == 4){
                        playerLine += 0;
                        enemyLine += 0;
                    }
                    playerPos += 1;
                }

                if (playerPos >= enemyLine){
                    enemyLine = playerPos + 1;
                    playerLine = playerPos;
                }


                Debug.Log("player pos: " + playerPos + ", player line: " + playerLine + " | enemy pos: " + enemyPos + ", en line: " + enemyLine);
                if (enemyPos > 6 || playerLine > enemyPos || playerPos == enemyPos)
                {
                    Debug.Log("WINN");
                    playerWin = true;
                    if (enemyPos <= 6){
                        status[enemyPos].struck = true;
                    }
                } else {

                    if (enemyType == 3)
                    {
                        enemyPos -= 1;
                    }
                    else if (enemyType == 4)
                    {
                        enemyPos -= 0;
                    }

                    if (enemyPos <= playerLine)
                    {
                        playerLine = enemyPos - 1;
                        enemyLine = enemyPos;
                    }

                    Debug.Log("player pos: " + playerPos + ", player line: " + playerLine + " | enemy pos: " + enemyPos + ", en line: " + enemyLine);
                    if (playerPos < 0 || enemyLine < playerPos || playerPos == enemyPos)
                    {
                        Debug.Log("lose");
                        enemyWin = true;
                        if (playerPos >= 0)
                        {
                            status[playerPos].struck = true;
                        }
                    }

                }


                for (int i = 0; i < status.Length; i++){ //visual updates to table

                    if (i <= playerLine)
                    {
                        status[i].state = 1;
                    }
                    else if (i >= enemyLine)
                    {
                        status[i].state = 2;
                    } else{
                        status[i].state = 0;
                    }

                    if (i == playerPos){
                        status[i].hasPlayer = true;
                    } else{
                        status[i].hasPlayer = false;
                    }

                    if (i == enemyPos){
                        status[i].hasEnemy = true;
                    } else{
                        status[i].hasEnemy = false;
                    }
                }

                updateTable = false;
            }

            if (playerWin == true){
                textBox.text = (aggro.options[optStep + (playerType-5)] + "\n\nPlayer wins!");
                duelFinished = true;
            }
            else if (enemyWin == true){
                textBox.text = (aggro.dialogue[step] + "\n\nEnemy wins!");
                duelFinished = true;
            }
            else{
                textBox.text = (aggro.dialogue[step] + aggro.options[optStep] + aggro.options[optStep + 1] + aggro.options[optStep + 2] + aggro.options[optStep + 3]);
            }

        } else if (step > 0 && Input.GetKeyDown(KeyCode.Alpha1) && inDuel == true && (step % 2 == 1))
        {
            step++;
            textBox.text = (aggro.options[optStep] + "\n" + aggro.dialogue[step] + "\n [space]");
            playerType = 1;
            updateTable = true;

        } else if (step > 0 && Input.GetKeyDown(KeyCode.Alpha2) && inDuel == true && (step % 2 == 1))
        {
            step++;
            textBox.text = (aggro.options[optStep+1] + "\n" + aggro.dialogue[step] + "\n [space]");
            playerType = 2;
            updateTable = true;

        } else if (step > 0 && Input.GetKeyDown(KeyCode.Alpha3) && inDuel == true && (step % 2 == 1))
        {
            step++;
            textBox.text = (aggro.options[optStep+2] + "\n" + aggro.dialogue[step] + "\n [space]");
            playerType = 3;
            updateTable = true;

        } else if (step > 0 && Input.GetKeyDown(KeyCode.Alpha4) && inDuel == true && (step % 2 == 1))
        {
            step++;
            textBox.text = (aggro.options[optStep+3] + "\n" + aggro.dialogue[step] + "\n [space]");
            playerType = 4;
            updateTable = true;
        }

        //if (inDuel == true && (step % 2 == 0) && createTable == false && updateTable == true)
        //{
        //    Debug.Log("hi mom!");
        //    updateTable = false;
        //}

        if (step == 1 && createTable == true){
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i] = Instantiate(tile) as GameObject;
                tiles[i].transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                tiles[i].transform.Translate((170 * i), 0, 0);
                status[i] = tiles[i].GetComponent<DuelSquare>();
            }
            createTable = false;

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
}
