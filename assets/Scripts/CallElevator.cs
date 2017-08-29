using UnityEngine;
using System.Collections;

/**
 * CallElevator
 * 
 * Goes onto the button infront of the elevator in level one.
 * Handles the button press and the call of the elevator.
 **/
public class CallElevator : MonoBehaviour {
    public GameObject doorRight;
    public GameObject doorLeft;
    public GameObject button;
    public GameObject enemy;
    public Transform player;
    public AudioSource elevatorAudio;
    public AudioClip closingElevator;
    public AudioClip ding;
    public AudioClip movingElevator;
    public AudioClip scare;
    public AudioSource enemyAudio;
    EnemyMovement stop;
    private bool pressed = false;
	// Use this for initialization
	void Start () {
        doorRight = GameObject.Find("Door_Right");
        doorLeft = GameObject.Find("Door_Left");

        stop = (EnemyMovement)enemy.GetComponent(typeof(EnemyMovement)); //Enemy Movement script, so that the dontStop bool can be called from here.
    }
	
	// Update is called once per frame
	void Update () {

        /**
        * Check for the scripted event that is triggered by the button, if the dontMove bool is true, play the scare sound when the player turns towards the enemy and enable movement again. 
        **/
        if (stop.dontMove)
        {
            float dot = Vector3.Dot(player.forward, (enemy.transform.position - player.position).normalized); //Angle between enemy position and player camera
            if (dot > 0.4f)
            {
                elevatorAudio.PlayOneShot(scare);
                stop.dontMove = false;
            }
        }
	}

    /**
    * When the player is inside the collider, he can press the button via the F key once. Also spawns the enemy behind the player and disables its movement
    **/
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F) && !pressed)
        {
            Debug.Log("Button pressed");
            StartCoroutine(buttonPress(1.5f));
            pressed = true;
            StartCoroutine(ExecuteAfterTime(17));
            enemy.transform.localPosition = new Vector3(-167.3f, -8, -28.5f);
            enemy.transform.LookAt(player);
             
            stop.dontMove = true;
            
        }
    }

    /**
    * After the specified time, opens the doors of the elevator, after playing the belonging sounds
    **/
    IEnumerator ExecuteAfterTime(float time)
    {
        GetComponent<AudioSource>().PlayOneShot(movingElevator);
        yield return new WaitForSeconds(time);
        GetComponent<AudioSource>().PlayOneShot(ding);
        StartCoroutine(RotateDoor(new Vector3(0, 0, -20), 2, doorRight));
        StartCoroutine(RotateDoor(new Vector3(0, 0, 20), 2, doorLeft));
       
        
    }

    /**
    *   Rotate the doors 
    **/
    IEnumerator RotateDoor(Vector3 angles, float inTime, GameObject door)
    {
        Quaternion fromAngle = door.transform.rotation;
        Quaternion toAngle = Quaternion.Euler(door.transform.eulerAngles + angles);
        for(float t = 0f; t< 1f; t += Time.deltaTime / inTime)
        {
            door.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }
        
    }

    /**
    * Animate the button press, button going down then up again
    **/
    IEnumerator buttonPress(float inTime)

    {
        bool down = false;
        Vector3 topPosition = button.transform.position;
        Vector3 bottomPosition = topPosition + new Vector3(-.1f, -.2f, 0);
        
        for (float t = 0f; t < 1f; t += Time.deltaTime / inTime)
        {
            //After half the time, change the movement from down to up
            if (t > .5f && !down)
            {
                bottomPosition = topPosition;
                topPosition = button.transform.position;
                down = true;
            }
            
            button.transform.position = Vector3.Lerp(topPosition, bottomPosition, t);

            yield return false;

            

        }
            
        
        
        
    }
}
