using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour{
    public float interactionRadius, speed;
    public bool dossierActive = false;
    DialogueManager dialogue;
    public void Start()
    {
        dialogue = FindObjectOfType<DialogueManager>();
    }
    public void Update()
    {
        if(dialogue==null || dialogue.currentGameState!=DialogueManager.GameState.OverworldActive || dossierActive){
            return;
        }else {
            MovePlayer();  
            if (Input.GetKeyDown(KeyCode.E) && dialogue.currentGameState==DialogueManager.GameState.OverworldActive)
            {
                CheckForNPC();
                CheckForNearbyObjects();
            }
        } 

    }

    void MovePlayer()
    {
        Vector2 currentPos = transform.position;
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        currentPos.x += speed * horizontalInput * Time.deltaTime;
        currentPos.y += speed * verticalInput * Time.deltaTime;

        transform.position = currentPos;
    }

    void CheckForNPC()
    {
        var allNps = new List<NPC>(FindObjectsOfType<NPC>());
        var target = allNps.Find(delegate (NPC p)
        {
            return (p.transform.position - this.transform.position)
                    .magnitude <= interactionRadius;
            
        });

        if (target != null && dialogue.activeNPC == null && target.currentStatus != NPC.NPCStatus.Heated)
        {
           
                Debug.Log("Interacting with npc");
                dialogue.activeNPC = target;
                dialogue.StartDialogue(dialogue.activeNPC.treeToLoad);

        } else {
            return;
        }
    }

    void CheckForNearbyObjects()
    {
        var allObjects = new List<EnvObjectManager>(FindObjectsOfType<EnvObjectManager>());
        var obj = allObjects.Find(delegate (EnvObjectManager env)
        {
            return (env.transform.position - this.transform.position).magnitude <= (interactionRadius);

        });

        if(obj != null){
            Debug.Log("Interacting with object");
            dialogue.activeObject = obj;
            dialogue.StartDescription();
        } else {
            return;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, new Vector3(1, 1, 0));
        Gizmos.DrawWireSphere(Vector3.zero, interactionRadius);
    }


}

