using UnityEngine;
using System.Collections;


    /**
     * Checkpoint
     * 
     * Stores the player position and rotation in global static variables that can be accessed from outside.
     **/
public class Checkpoint : MonoBehaviour {
    public Transform player;
    public static Vector3 checkPosition = new Vector3(-0.26f, 1.16f, 3.72f); //Starting position for level01 start
    public static Quaternion checkRotation;

    void Start()
    {
        checkRotation = player.transform.rotation; //Store starting rotation for consistency of respawn before first checkpoint
    }

    /**
    * When the player enters, it saves the current location and rotation globally. 
    **/
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            checkPosition = transform.position;
            checkRotation = player.transform.rotation;
            Debug.Log("Checked");

        }
    }
}
