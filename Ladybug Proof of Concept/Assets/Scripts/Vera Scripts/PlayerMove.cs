using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour{
    public float interactionRadius, objInteract, speed;
    public bool dossierActive = false;
    bool particlesActive;
    public GameObject particles;
    DialogueManager dialogue;
    public void Start()
    {
        dialogue = FindObjectOfType<DialogueManager>();
        transform.GetChild(0).gameObject.SetActive(false);
    }
    public void Update()
    {
        if (dialogue == null || dialogue.currentGameState != DialogueManager.GameState.OverworldActive || dossierActive)
        {
            return;
        } else {
            MovePlayer();  
            if (dialogue.currentGameState==DialogueManager.GameState.OverworldActive)
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

        if (target != null && dialogue.activeNPC == null && target.currentStatus != NPC.NPCStatus.Heated && Input.GetKeyDown(KeyCode.E) && target.treeToLoad!=null)
        {
           
                Debug.Log("Interacting with npc");
                dialogue.activeNPC = target;
                dialogue.StartDialogue(dialogue.activeNPC.treeToLoad);

        } 

    }

    void CheckForNearbyObjects()
    {
        var allObjects = new List<EnvObjectManager>(FindObjectsOfType<EnvObjectManager>());
        var obj = allObjects.Find(delegate (EnvObjectManager env)
        {
            //print("here");
            return (env.transform.position - this.transform.position).magnitude <= (objInteract);
           

        });

        if(obj!=null){
            transform.GetChild(0).gameObject.SetActive(true);
            if(!particlesActive){
                print("Particles in");
                Instantiate(particles, obj.transform);
                particlesActive = true;
            }
        } else {
            transform.GetChild(0).gameObject.SetActive(false);
            foreach(var o in allObjects){
                for (int i = 0; i < o.transform.childCount; i++){
                    Destroy(o.transform.GetChild(i).gameObject);
                }
            }
            particlesActive = false;
            print("Particles out");
        }

        if(obj != null && Input.GetKeyDown(KeyCode.E) && dialogue.currentGameState == DialogueManager.GameState.OverworldActive){
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

