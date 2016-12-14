using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour {

    public Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 camRotation = Vector3.zero;
    private bool jumping = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
        PerformJump();
    }

    public void Move (Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void CamRotate(Vector3 _camRotation)
    {
        camRotation = _camRotation;
    }

    

    void PerformMovement()
    {
        if (velocity != Vector3.zero) { 
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null)
        {
            cam.transform.Rotate(-camRotation);
        }
    }

    void PerformJump()
    {
        if(!jumping && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            jumping = true;
        }
    }
}
