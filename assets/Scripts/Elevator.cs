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
        StartCoroutine(RotateDoor(new Vector3(0, 0, 20), 2, doorRight));
        StartCoroutine(RotateDoor(new Vector3(0, 0, -20), 2, doorLeft));


    }

    IEnumerator RotateDoor(Vector3 angles, float inTime, GameObject door)
    {
        Quaternion fromAngle = door.transform.rotation;
        Quaternion toAngle = Quaternion.Euler(door.transform.eulerAngles + angles);
        for (float t = 0f; t < 1f; t += Time.deltaTime / inTime)
        {
            door.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }

    }

    
}
