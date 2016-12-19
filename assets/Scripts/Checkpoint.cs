using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
    public Transform player;
    public static Vector3 checkPosition = new Vector3(-0.26f, 1.16f, 3.72f);
    public static Quaternion checkRotation;

    void Start()
    {
        checkRotation = player.transform.rotation;
    }

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
