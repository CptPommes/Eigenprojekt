using UnityEngine;
using System.Collections;

    /**
     * Enemy Floor
     * 
     * Script that goes on the invisible floors only the enemy is allowed on. Disables the collision if the player enters it, so he falls through.
     **/
public class EnemyFloor : MonoBehaviour {

	void OnCollisionEnter(Collision col)
    {
        /**
        * When the collision tag is from the player, disable collision. Else, enable it so it's definetly enabled.
        **/
        if (col.gameObject.tag == "Player")
        {
            GetComponent<Collider>().enabled = false;
        } else GetComponent<Collider>().enabled = true;
    }
}
