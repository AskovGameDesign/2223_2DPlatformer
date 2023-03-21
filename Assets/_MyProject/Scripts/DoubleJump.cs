using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public float playerSpeed = 4;
    public float jumpForce = 10;
    public int numberOfJumps = 2;

    public LayerMask groundLayer;
    public Vector2 groundCheckBoxSize = new Vector2(1f, 0.2f);
    public Transform groundCheckBoxCenter;

    public bool groundCheck;

    private Rigidbody2D rb2d;
    private float moveInput;
    private int jumpCounter = 0;
    private bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if( Input.GetKeyDown(KeyCode.Space) && jumpCounter < numberOfJumps )
        {
            if(IsGrounded())
            {
                jumpCounter += 1;
            }
            else
            {
                jumpCounter = numberOfJumps;
            }
            
            rb2d.velocity = Vector2.up * jumpForce;
        }

        if( IsGrounded() && rb2d.velocity.y <= 0 )
        {
            jumpCounter = 0;    
        }


        if(moveInput < 0f && !isFacingRight)
        {
            FlipPlayer();
        }
        else if(moveInput > 0f && isFacingRight)
        {
            FlipPlayer();
        }

    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(moveInput * playerSpeed, rb2d.velocity.y);
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheckBoxCenter.position, groundCheckBoxSize, 0f, groundLayer);
    }

    void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        Vector2 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    private void OnDrawGizmos()
    {
        if (!this.isActiveAndEnabled)
            return;

        Color gizmoColor = Color.magenta;
        gizmoColor.a = 0.5f;
        Gizmos.color = gizmoColor;
        Gizmos.DrawCube(groundCheckBoxCenter.position, new Vector3(groundCheckBoxSize.x, groundCheckBoxSize.y, 0f));
    }
}
