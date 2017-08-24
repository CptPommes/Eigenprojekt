using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
    public Transform target;
    NavMeshAgent agent;
    public bool dontMove = false;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        agent.updateRotation = true;
        agent.SetDestination(target.position);
        //transform.LookAt(target);
        //Debug.Log(target.position);
        float dot = Vector3.Dot(target.forward, (transform.position - target.position).normalized);
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
