using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour


    //initializing the components i will need
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Animator anim;

    [SerializeField] public float pushAway;

    //calling game manager game object to use the game over method inside
    public gameManager gameManager;

    //declaring a speed variable
    public float moveSpeed;

    //getting ground check game object i will need to check if the player is on the platform
    public Transform GroundCheck;

    //declaring a layer mask that will be set on unity as ground
    public LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //player movement with rigidbody and joystick
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed * Time.deltaTime, rb.velocity.y, joystick.Vertical * moveSpeed * Time.deltaTime);


        //rotating the player to moving point
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);


            //activating walking animation on animator by setting the isMoving parameter to true
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }


        //checking if the player is touching the ground layer on platform
        if (!IsGrounded())
        {
            //activating falling animation on animator 
            anim.SetBool("isFalling", true);

            //using invoke to delay the game over screen
            gameManager.Invoke("gameOver", 2);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy") 
        {
            // getting the rigidbody of the collided object
            Rigidbody rigid = collision.gameObject.GetComponent<Rigidbody>();

            //normalizing the vector3 parameters  
            Vector3 direction = (collision.transform.position - gameObject.transform.position).normalized;

            // adding force to rigid variable to push the other object
            rigid.AddForce(new Vector3(direction.x, 0, direction.z) * pushAway, ForceMode.Impulse);
        }

        if(collision.gameObject.tag == "collectable")
        {
            pushAway += 2;
            Destroy(collision.gameObject);
        }
    }

    //function for checking if the game object is touching the ground layer
    public bool IsGrounded()
    {
        return Physics.CheckSphere(GroundCheck.position, .1f, ground);

    }

}
