using UnityEngine;
using System.Collections;

public class CallElevator : MonoBehaviour {
    public GameObject doorRight;
    public GameObject doorLeft;
    private bool pressed = false;
	// Use this for initialization
	void Start () {
        doorRight = GameObject.Find("Door_Right");
        doorLeft = GameObject.Find("Door_Left");
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F) && !pressed)
        {
            Debug.Log("Button pressed");
            pressed = true;
            StartCoroutine(ExecuteAfterTime(3));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        doorRight.transform.Rotate(0, 0, -20);
        doorLeft.transform.Rotate(0, 0, 20);
        
    }
}
