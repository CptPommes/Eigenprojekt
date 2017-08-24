using UnityEngine;
using System.Collections;

public class CallElevator : MonoBehaviour {
    public GameObject doorRight;
    public GameObject doorLeft;
    public GameObject button;
    public GameObject enemy;
    public Transform player;
    EnemyMovement stop;
    private bool pressed = false;
	// Use this for initialization
	void Start () {
        doorRight = GameObject.Find("Door_Right");
        doorLeft = GameObject.Find("Door_Left");

        stop = (EnemyMovement)enemy.GetComponent(typeof(EnemyMovement));
    }
	
	// Update is called once per frame
	void Update () {
        if (stop.dontMove)
        {
            float dot = Vector3.Dot(player.forward, (enemy.transform.position - player.position).normalized);
            if (dot > 0.4f)
            {
                stop.dontMove = false;
            }
        }
	}

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F) && !pressed)
        {
            Debug.Log("Button pressed");
            StartCoroutine(buttonPress(1.5f));
            pressed = true;
            StartCoroutine(ExecuteAfterTime(3));
            enemy.transform.localPosition = new Vector3(-167.3f, -8, -28.5f);
            enemy.transform.LookAt(player);
             
            stop.dontMove = true;
            
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(RotateDoor(new Vector3(0, 0, -20), 2, doorRight));
        StartCoroutine(RotateDoor(new Vector3(0, 0, 20), 2, doorLeft));
       
        
    }

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

    IEnumerator buttonPress(float inTime)

    {
        bool down = false;
        Vector3 topPosition = button.transform.position;
        Vector3 bottomPosition = topPosition + new Vector3(-.1f, -.2f, 0);
        
        for (float t = 0f; t < 1f; t += Time.deltaTime / inTime)
        {
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
