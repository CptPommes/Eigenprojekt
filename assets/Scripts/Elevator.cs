using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {
    public GameObject doorRight;
    public GameObject doorLeft;
    // Use this for initialization
    void Start()
    {
        doorRight = GameObject.Find("Door_Right");
        doorLeft = GameObject.Find("Door_Left");
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Entered Elevator");
            StartCoroutine(ExecuteAfterTime(3));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        doorRight.transform.Rotate(0, 0, 20);
        doorLeft.transform.Rotate(0, 0, -20);

    }
}
