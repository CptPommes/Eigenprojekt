using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerController : MonoBehaviour {
    public float speed = 5f;
    public float mouseSensitivity = 3f;
    private float distToGround;

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

        //Prevent user from moving forward (DELETE LATER!!!)
        /**if (Input.GetKey(KeyCode.W))
        {
            zMov = 0;
        }**/

        
        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;

        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;
        move.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");
        float xRot = Input.GetAxisRaw("Mouse Y");


        Vector3 rotation = new Vector3(0f, yRot, 0f) * mouseSensitivity;
        Vector3 camRotation = new Vector3(xRot, 0f, 0f)* mouseSensitivity;

        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        { 
            move.Jump();
        }

        move.Rotate(rotation);
        move.CamRotate(camRotation);


    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
