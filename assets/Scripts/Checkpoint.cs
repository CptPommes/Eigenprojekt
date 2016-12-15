using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    public static Vector3 check = new Vector3(0.37f, 6.64f, 28.78f);

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            check = transform.position;
            Debug.Log("Checked");

        }
    }
}
