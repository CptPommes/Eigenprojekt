using UnityEngine;

/**
 * PlayerController
 * 
 * Reads the inputs the player makes and hands them over to the PlayerMover.
 * 
 * Required: PlayerMover, because it uses some of the methods.
 **/
[RequireComponent(typeof(PlayerMover))]
public class PlayerController : MonoBehaviour {
    public float speed = 5f;
    public float mouseSensitivity = 3f;
    private float distToGround;
    public ParticleSystem spray;
    private PlayerMover move;
    
    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        move = GetComponent<PlayerMover>();
    }

    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
       

        float zMov = Input.GetAxisRaw("Vertical");

        
        //When left mouesbutton is pressed, enable the particle system emission for spraycan effect. Else, disable again.
        if (Input.GetMouseButton(0))
        {
            Debug.Log("LeftClick");
            spray.enableEmission = true ;
        }
        else spray.enableEmission = false;

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;

        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;
        move.Move(velocity); //Hands over velocity for movement to PlayerMover

        float yRot = Input.GetAxisRaw("Mouse X");
        float xRot = Input.GetAxisRaw("Mouse Y");


        Vector3 rotation = new Vector3(0f, yRot, 0f) * mouseSensitivity;
        Vector3 camRotation = new Vector3(xRot, 0f, 0f)* mouseSensitivity;

        //Jump if the player is standing on the ground and space key is pressed
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        { 
            move.Jump();
        }

        //Hands over x and y rotation seperatly, so the playermodel doesnt rotate y-wise.
        move.Rotate(rotation);
        move.CamRotate(camRotation);


    }

    //Checks if the player is standing on the ground
    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
