using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour{
    public float interactionRadius, speed;
    DialogueManager dialogue;
    public void Start()
    {
        dialogue = FindObjectOfType<DialogueManager>();
    }
    public void Update()
    {
        if(dialogue.dialogueActive || dialogue == null){
            return;
        }else{
            MovePlayer();  
        } 
       
        if (Input.GetKeyUp(KeyCode.E))
        {
            CheckForNPC();
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

        if (target != null)
        {
            Debug.Log("Interacting with npc");
            dialogue.activeNPC = target;
            dialogue.StartDialogue(dialogue.activeNPC.treeToLoad);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, new Vector3(1, 1, 0));
        Gizmos.DrawWireSphere(Vector3.zero, interactionRadius);
    }


}

