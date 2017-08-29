using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/**
 * Elevator
 * 
 * Goes on the elevator in the end of the first level. Handles the door closing and leaving level.
 **/
public class Elevator : MonoBehaviour {
    public GameObject doorRight;
    public GameObject doorLeft;
    public AudioClip closingDoors;
    public AudioClip movingElevator;

   /**
    * Get the two doors of the elevator as references.
    **/
    void Start()
    {
        doorRight = GameObject.Find("Door_Right");
        doorLeft = GameObject.Find("Door_Left");
    }

    // Update is called once per frame
    void Update () {
	
	}

    /**
     * When the player enters, start the coroutine to close the doors
     **/
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Entered Elevator");
            StartCoroutine(ExecuteAfterTime(2));
            
        }
    }

    /**
     * Closes the doors after the specified amount of time, then plays the elevator sound and after some time loads back into the specified scene (mainmenu)
     **/
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        GetComponent<AudioSource>().PlayOneShot(closingDoors);
        StartCoroutine(RotateDoor(new Vector3(0, 0, 20), 2, doorRight));
        StartCoroutine(RotateDoor(new Vector3(0, 0, -20), 2, doorLeft));
        yield return new WaitForSeconds(2);
        GetComponent<AudioSource>().PlayOneShot(movingElevator);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);  //Load MainMenu, change to level two later!


    }

    /**
    * Rotates the two doors by the specified angle, after the specified time
    **/
    IEnumerator RotateDoor(Vector3 angles, float inTime, GameObject door)
    {
        Quaternion fromAngle = door.transform.rotation;
        Quaternion toAngle = Quaternion.Euler(door.transform.eulerAngles + angles);
       
        /**
        *   Used for fluent movement of the doors 
        **/    
        for (float t = 0f; t < 1f; t += Time.deltaTime / inTime)
        {
            door.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }

    }

    

    
}
