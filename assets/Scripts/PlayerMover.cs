using UnityEngine;

/**
 * PlayerMover
 * 
 * Moves the player in a fixed update, so its independet from the framerate. Gets inputs from PlayerController.
 * 
 * Required: Rigidbody for movement by force.
 **/
[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour {

    public Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 camRotation = Vector3.zero;
    public AudioSource footSteps;
    private bool jump = false;
    public float jumpHeight = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
        if (jump)
        {
            

            rb.AddForce(Vector3.up * jumpHeight , ForceMode.Impulse);
            
        }
        jump = false;
    }

    /**
     * Performs the movement of the player. Also plays footsteps sound when moving.
     **/
    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            //Only start footsteps once, so it isn't stacking
            if (!footSteps.isPlaying)
            {
                footSteps.Play();

            }
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
        else footSteps.Stop();

    }

    /**
    * Performs rotation of the player
    **/
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (cam != null)
        {
            cam.transform.Rotate(-camRotation);

        }
    }

    /**
   * Methods used by the PlayerController for handing over the inputs.
   **/

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

    

   

   public void Jump()
    {
        jump = true;
    }
}
