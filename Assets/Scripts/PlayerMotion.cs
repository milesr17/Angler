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

    //For wall jump
    public LayerMask whatIsGround;
    private bool touchingRight;
    private bool touchingLeft;
    private bool wallJumping;
    private float touchingLeftOrRight;

    //RestartUI
    public GameObject youDiedText;
    public GameObject restartButton;

    //LevelWinUI
    public GameObject youWinText;
    public GameObject menuButton;


    bool facingRight = true;

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        //Reference for Rigidbody applied to player object for changing parameters
        rb = GetComponent<Rigidbody2D>();
        
        //Sets tempSpeed with the default speed
        tempSpeed = movementSpeed;

        //Disable death UI
        youDiedText.SetActive(false);
        restartButton.SetActive(false);

        //Disable win UI
        youWinText.SetActive(false);
        menuButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Displays the speed value in the console for testing
        //Debug.Log("Movement Speed: " + movementSpeed);

        //Detection variables
        grounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x , gameObject.transform.position.y - 0.3f), new Vector2(0.5f, 0.2f), 0f, whatIsGround);
        touchingLeft = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x - 0.3f, gameObject.transform.position.y), new Vector2(0.15f, 0.5f), 0f, whatIsGround);
        touchingRight = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x + 0.3f, gameObject.transform.position.y), new Vector2(0.15f, 0.5f), 0f, whatIsGround);

        //MOTION
        //Player jumps when user presses W

        if (Input.GetKeyDown(KeyCode.W))
        {
            //Checks if the player is on the ground
            if (grounded)
            {
                //Single jump
                rb.velocity = Vector2.up * jumpSpeed;
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
                    rb.velocity = Vector2.up * jumpSpeed;
                }
            }
        }

        //Check if stuck on wall jump
        if ((!touchingLeft && !touchingRight) || grounded)
        {
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

        //START WALL JUMP
        if (touchingLeft)
        {
            touchingLeftOrRight = 1;
        }
        else if (touchingRight)
        {
            touchingLeftOrRight = -1;
        }
        if (Input.GetKeyDown(KeyCode.W) && (touchingRight || touchingLeft) && !grounded)
        {
            wallJumping = true;
            Invoke("StopWallJump", 0.08f);
        }

        if (wallJumping)
        {
            rb.velocity = new Vector2(movementSpeed * touchingLeftOrRight, jumpSpeed);
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

    //See ground and wall detectors in scene
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.3f), new Vector2(0.5f, 0.2f));

        Gizmos.color = Color.blue;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x - 0.3f, gameObject.transform.position.y), new Vector2(0.15f, 0.5f));
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x + 0.3f, gameObject.transform.position.y), new Vector2(0.15f, 0.5f));
    }

    //End wall jump
    void StopWallJump()
    {
        wallJumping = false;
    }

    //Detect collisions
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Kill player if hit enemy
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            youDiedText.SetActive(true);
            restartButton.SetActive(true);
            gameObject.SetActive(false);
        }
        //End level if reached end
        else if (collision.gameObject.tag.Equals("Respawn"))
        {
            youWinText.SetActive(true);
            menuButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }


}