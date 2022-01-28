using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_01 : MonoBehaviour
{

    public float moveSpeed = 1;

    //Private Fields
    Rigidbody2D rb;
    float horizontalValue;

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
        float xVal = dir * moveSpeed * 100 * Time.deltaTime;
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        //y value remains the same, only x changes
        rb.velocity = targetVelocity;
    }
}
