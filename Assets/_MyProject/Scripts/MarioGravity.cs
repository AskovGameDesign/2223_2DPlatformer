using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MarioGravity : MonoBehaviour
{
    public float highJumpFallMultiplier = 3f;
    public float lowJumpFallMultiplier = 2f;

    Rigidbody2D rb2d;
    bool isJumpkeyPressed;
    float rb2dStartGavityScale;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2dStartGavityScale = rb2d.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        isJumpkeyPressed = Input.GetButton("Jump");    
    }

    private void FixedUpdate()
    {
        // Moving down
        if (rb2d.velocity.y < 0f)
        {
            rb2d.gravityScale = rb2dStartGavityScale + highJumpFallMultiplier;
        }
        // if we are moving Up AND we release the jump key
        else if(rb2d.velocity.y > 0f && !isJumpkeyPressed)
        {
            rb2d.gravityScale = rb2dStartGavityScale + lowJumpFallMultiplier;
        }
        else
        {
            rb2d.gravityScale = rb2dStartGavityScale;
        }
    }
}
