using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10;
    public float jumpForce = 5;
    public LayerMask groundLayer;
    public Vector2 checkBoxSize = new Vector2(0.5f, 0.2f);
    public Transform groundCheck;

    private float moveInput;
    private Rigidbody2D rigidbody2D;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapBox(groundCheck.position, checkBoxSize, 0f, groundLayer);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            rigidbody2D.velocity = Vector2.up * jumpForce; 
        }
        
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(moveInput * playerSpeed, rigidbody2D.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Color gizmoColor = Color.magenta;
        gizmoColor.a = 0.5f;
        Gizmos.color = gizmoColor;
        Gizmos.DrawCube(groundCheck.position, new Vector3(checkBoxSize.x, checkBoxSize.y, 0f));
    }
}
