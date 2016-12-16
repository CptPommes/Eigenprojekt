using UnityEngine;
using System.Collections;

public class EnemyFloor : MonoBehaviour {

	void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            GetComponent<Collider>().enabled = false;
        } else GetComponent<Collider>().enabled = true;
    }
}
