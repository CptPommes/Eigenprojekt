using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

    void PlayerDeath()
    {
        transform.position = new Vector3(0, 6.64f, 28.78f);
        transform.localEulerAngles = new Vector3(0,180f,0);
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Death")
        {
            PlayerDeath();
        }
    }
}
