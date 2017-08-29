using UnityEngine;
using System.Collections;

/**
 * Enemy Movement
 * 
 * Specifies the target for NavMeshAgent, stops movement when player is looking towards the enemy.
 **/
public class EnemyMovement : MonoBehaviour {
    public Transform target;    //The player
    NavMeshAgent agent;
    public bool dontMove = false;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        agent.updateRotation = true;
        agent.SetDestination(target.position); //Set destination to player every frame
        
        float dot = Vector3.Dot(target.forward, (transform.position - target.position).normalized); //Get the angle between the player view and the enemy

        //If the angle is bigger than .4f, the agent stops. If not, it resumes. Also handles the dontMove variable from the call of the elevator event.
        if (dot > 0.4f)
        {
            Debug.Log("isvisible");
            agent.Stop();
        }
        else if (dontMove)
        {
            Debug.Log("Dont move");
            agent.Stop();
        } else

            agent.Resume();
    
        
    }
}
