using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerLives = 3;

    public float playerSpeed = 10;
    public float jumpForce = 5;
    public LayerMask groundLayer;
    public Vector2 checkBoxSize = new Vector2(0.5f, 0.2f);
    public Transform groundCheck;

    private float moveInput;
    private Rigidbody2D rb2d;
    private bool isGrounded;
    private Animator animator;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        // Check if the player is standing on the ground - ground defined by layername 
        isGrounded = Physics2D.OverlapBox(groundCheck.position, checkBoxSize, 0f, groundLayer);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            rb2d.velocity = Vector2.up * jumpForce;
            isJumping = true;
            animator.SetBool("Jumping", isJumping);
        }

        // Quick short tap == short jump solution
        // check if jump button is released AND the player is moving up
        // moving up: velocity > 0 : moving down: velocity < 0f 
        if(Input.GetKeyUp(KeyCode.Space) && rb2d.velocity.y > 0f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
            
        }

        if(isGrounded)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
        }

        if(isGrounded && isJumping && rb2d.velocity.y <= 0)
        {
            isJumping = false;
            animator.SetBool("Jumping", isJumping);
        }

    }

    public void Damage(int damage)
    {
        playerLives -= damage;

        if(playerLives <= 0)
        {
            Debug.Log("Player died");
        }
    }

    public void Test()
    {
        Debug.Log("Did i die?");
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(moveInput * playerSpeed, rb2d.velocity.y);
        
    }

    private void OnDrawGizmos()
    {
        // OnDrawGizmo is drawn/called even if the script is disabled in the editor
        // the 2 lines below makes sure only to call the drawCube part if the script is enabled
        if (!this.isActiveAndEnabled)
            return;

        Color gizmoColor = Color.magenta;
        gizmoColor.a = 0.5f;
        Gizmos.color = gizmoColor;
        Gizmos.DrawCube(groundCheck.position, new Vector3(checkBoxSize.x, checkBoxSize.y, 0f));
    }
}
