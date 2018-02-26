using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {
    public NavMeshAgent playerAgent;
    public float stoppingDistance = 1.5f;
    private bool hasInteracted;

    GameObject player;

    void Start()
    {
        
    }


    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = stoppingDistance;
        playerAgent.destination = transform.position;
      
    }

     void Update()
    {
        if (!hasInteracted && playerAgent != null && !playerAgent.pathPending){
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                Interact();
                hasInteracted = true;
            }
        }


    }

    public virtual void Interact()
    {
        Debug.Log("Interacted");
    }

   
	
}
