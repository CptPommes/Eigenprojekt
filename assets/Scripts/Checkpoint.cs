using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
    public Transform player;
    public static Vector3 checkPosition = new Vector3(0.37f, 6.64f, 28.78f);
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
