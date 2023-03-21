using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioJumpNew : MonoBehaviour
{

    public float playerSpeed = 5f;
    public float jumpForce = 10f;
    public float jumptime = 1f;
    public Vector2 groundCheckBoxSize = new Vector2(1f, 0.3f);

    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb2d;
    private float moveInput;
    private bool isGrounded;
    private float jumpTimeCounter;
    private bool isJumping;

    private float startGavityScale;
    private bool isJumpKeyPressed;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startGavityScale = rb2d.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckBoxSize, 0f, groundLayer);

        moveInput = Input.GetAxisRaw("Horizontal");
        isJumpKeyPressed = Input.GetKey(KeyCode.Space);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //rb2d.velocity = 
        }

        // The player is falling //
        //if (rb2d.velocity.y < 0f)
        //{
        //    rb2d.velocity += Vector2.up * Physics2D.gravity.y * (3f - 1f) * Time.deltaTime;
        //}
        //// Check for quick release jump //
        //else if (rb2d.velocity.y > 0f && !Input.GetKey(KeyCode.Space))  
        //{
        //    rb2d.velocity += Vector2.up * Physics2D.gravity.y * (2f - 1f) * Time.deltaTime;
        //}
    }

    private void FixedUpdate()
    {
        if(rb2d.velocity.y < 0f )
        {
            rb2d.gravityScale = startGavityScale * 3f;
        }
        else if (rb2d.velocity.y > 0f && !isJumpKeyPressed)
        {
            rb2d.gravityScale = startGavityScale * 2f;
        }
        else
        {
            rb2d.gravityScale = startGavityScale;
        }


        rb2d.velocity = new Vector2(moveInput * playerSpeed, rb2d.velocity.y);
    }
}
