using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_01 : MonoBehaviour
{

    public float moveSpeed = 1;

    //Private Fields
    Rigidbody2D rb;
    float horizontalValue;
    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        Debug.Log(horizontalValue);
    }

    void FixedUpdate()
    {
        Move(horizontalValue);
    }

    void Move(float dir)
    {
        #region Move
        float xVal = dir * moveSpeed * 100 * Time.deltaTime;
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y); //y value remains the same, only x changes
        rb.velocity = targetVelocity;

        //If looking right and clicked left, flip to the left
        if (facingRight && dir<0) //dir<0 means going left (dir = -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        //If looking left and clicked right, flip to the right
        else if (!facingRight && dir>0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }
        #endregion


    }
}
