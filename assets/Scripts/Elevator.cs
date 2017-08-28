using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Elevator : MonoBehaviour {
    public GameObject doorRight;
    public GameObject doorLeft;
    public AudioClip closingDoors;
    public AudioClip movingElevator;
    
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
            StartCoroutine(ExecuteAfterTime(2));
            
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        GetComponent<AudioSource>().PlayOneShot(closingDoors);
        StartCoroutine(RotateDoor(new Vector3(0, 0, 20), 2, doorRight));
        StartCoroutine(RotateDoor(new Vector3(0, 0, -20), 2, doorLeft));
        yield return new WaitForSeconds(2);
        GetComponent<AudioSource>().PlayOneShot(movingElevator);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);


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

    IEnumerator loadNext(int next, int time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(next);

    }

    
}
