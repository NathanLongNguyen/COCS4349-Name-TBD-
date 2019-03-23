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

    //inventory
    public Inventory inventory;
    private InteractableItemBase mInteractItem = null;
    public HUD hud;

    //Camera/Field of Vision
    Camera viewCamera;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        facingRight = true;

        //winText.text = "";

        //Field of Vision testing
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(currJump);
        Movement();

        //Field of vision testing
        //Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.z));
        //transform.LookAt(new Vector2(0,4));
        //transform.LookAt(mousePos + Vector3.left * transform.position.x);
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

        //Check to see if we need to flip the character0
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
        transform.Rotate(Vector3.up * -180);    //rotate the character left and right
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
            rb.velocity = Vector3.zero;
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
        InteractableItemBase item = other.GetComponent<InteractableItemBase>();

        if (other.gameObject.CompareTag("Pick Up"))
        {
            //Destroy the gameObject when collide
            Destroy(other.gameObject);
            //Can alternatively set to inactive instead:
            //other.gameObject.SetActive(false);
        }

        //End Level Tag Trigger
        if (other.gameObject.CompareTag("EndTrigger"))
        {
            //Replace with better text
            winText.text = "Level end!";
        }

        //Inventory item interact
        if (other.gameObject.CompareTag("Interactable"))
        {
            mInteractItem = item;
            InventoryItemBase inventoryItem = mInteractItem as InventoryItemBase;
            inventory.AddItem(inventoryItem);
            inventoryItem.OnPickup();
        }
    }
}

