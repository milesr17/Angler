using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{

    //For motion force
    public float movementSpeed = 10f;
    public float jumpSpeed = 70f;
    public float slamSpeed = 20f;
    public float dashSpeed = 30f;
    float tempSpeed;

    //For dash reset 
    private float dashCooldown = 3f;
    public float dashDuration = 0.5f;

    //For checking double jump
    public bool grounded;
    public bool doubleJump;

    bool facingRight = true;

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        //Reference for Rigidbody applied to player object for changing parameters
        rb = GetComponent<Rigidbody2D>();
        //Sets tempSpeed with the default speed
        tempSpeed = movementSpeed;
    }

    //Checks if player is colliding with the ground or not
    void GroundedUpdater()
    {
        grounded = false;
        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(transform.position, Vector2.down, 0.6f);
        foreach (var hited in hit)
        {
            if (hited.collider.gameObject == gameObject)
                continue;
            if (hited.collider.gameObject.tag == "Ground")
            {
                grounded = true;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        //Displays the speed value in the console for testing
        Debug.Log("Movement Speed: " + movementSpeed);

        //MOTION
        //Player jumps when user presses W
        GroundedUpdater();

        if (Input.GetKeyDown(KeyCode.W))
        {
            //Checks if the player is on the ground
            if (grounded)
            {
                //Single jump
                rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
                grounded = false;
                doubleJump = true;
            }
            else
            {
                //Checks if doubleJump is possible
                if (doubleJump)
                {
                    //Double jump
                    doubleJump = false;
                    rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
                }
            }
        }

        //Player moves left when user presses A
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            //Checks if facing right
            if (facingRight)
            {
                flip();
            }
        }


        //Player moves right when user presses D 
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            //Checks if facing left
            if (!facingRight)
            {
                flip();
            }
        }

        //Player ground slams when user presses S
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0, -slamSpeed);
        }

        //SIDE DASH
        //Increases the speed when LeftShift is pressed
        //Checks if cooldown is over
        if (Time.time > dashCooldown)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("Dash cooldown started");
                //Increase speed to dash speed
                movementSpeed = dashSpeed;
                StartCoroutine(DashDelay());
                //Resets cooldown
                dashCooldown = Time.time + dashDuration;
            }
        }

        //END MOTION
        if (Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }

    //Adds the duration for the dash then returns the player to normal speed
    IEnumerator DashDelay()
    {
        yield return new WaitForSeconds(1);
        movementSpeed = tempSpeed;
        Debug.Log("Dash ended");
    }

    //Rotates the player to face opposite direction
    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }


}