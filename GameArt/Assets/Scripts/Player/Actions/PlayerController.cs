using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text winText;
    private int maxJump = 2;
    int currJump;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        facingRight = true;
        winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(currJump);
        Movement();
    }

    // Use FixedUpdate for physics based function
    void FixedUpdate()
    {
        
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
        scale.x *= -1; //flip the object
        transform.localScale = scale; //update the z of the character's scaling
    }

    //function for checking if the player is grounded
    void groundCheck()
    {
        
        groundCollision = Physics.OverlapSphere(groundCheckObj.position, groundC_rad, whatIsGround);
        if(groundCollision.Length> 0)
        {
            isGrounded = true;
            currJump = 0;
        } else
        {
            isGrounded = false;
        }
    }

    //function for jumping 
    void Jump()
    {
        if(Input.GetButtonDown("Jump")  && (isGrounded || maxJump > currJump))
        {
            isGrounded = false;
            rb.AddForce(Vector3.up *jumpHeight, 0);
            currJump++;
           
        }


    }

    public bool giveDir()
    {
        if (facingRight)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //Destroy the gameObject when collide
            Destroy(other.gameObject);
            //Can alternatively set to inactive instead:
            //other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("EndTrigger"))
        {
            winText.text = "Level end!";
        }
    }

}

