using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed, jumpHeight; //That determine player's max speed
    Rigidbody rb; //Refer to the player's rigidbody
    public bool snappy; //Choose if we want a snappy vs fluid type movement (testing purposes)
    bool facingRight; //See if player is facing right
    bool isGrounded = false; //Check to is grounded
    Collider[] groundCollision;
    float groundC_rad;
    public LayerMask whatIsGround;
    public Transform groundCheckObj;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Use FixedUpdate for physics based function
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        moveHorizontal();
        groundCheck();
        Jump();

    }

    //fucntion for moving horizontally
    void moveHorizontal()
    {
        float move;
        
        //See which type of movement we want
        if (!snappy)
        {
            move = Input.GetAxis("Horizontal");
        }
        else
        {
            move = Input.GetAxisRaw("Horizontal");
        }

        //move by changing the velocity of the rigidbody
        rb.velocity = new Vector3(move * speed, rb.velocity.y, 0);

        //Check to see if we need to flip the character
        if(move > 0 && !facingRight)
        {
            Flip();
        } else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    //function for flipping
    void Flip()
    {
        facingRight = !facingRight; //switch true to false or false to true
        Vector3 scale = transform.localScale; //grabbing the z value of the character
        scale.z *= -1; //flip the object
        transform.localScale = scale; //update the z of the character's scaling
    }

    //function for checking if the player is grounded
    void groundCheck()
    {
        Debug.Log(isGrounded);
        groundCollision = Physics.OverlapSphere(groundCheckObj.position, groundC_rad, whatIsGround);
        if(groundCollision.Length> 0)
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
    }

    //function for jumping 
    void Jump()
    {
        if(isGrounded && Input.GetAxis("Jump") > 0)
        {
            isGrounded = false;
            rb.AddForce(new Vector3(0, jumpHeight, 0));
        }
    }
    
}

