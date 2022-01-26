using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump_01 : MonoBehaviour
{
    //hweeeez ver 01
    public Rigidbody2D rb;
    public float buttonTime = 0.5f;
    public float jumpHeight = 5;
    public float cancelRate = 100;
    float jumpTime;
    bool jumping;
    bool jumpCancelled;
    bool canJump = true;
    void Start()
    {
        
    }

  

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumping = true;
            jumpCancelled = false;
            jumpTime = 0;
           
        }
      

        if (jumping)
        {
            
            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpCancelled = true;
            }

            if (jumpTime > buttonTime)
            {
                jumping = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (jumpCancelled && jumping && rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * cancelRate);
            canJump = false;
        }
        
    }
}
