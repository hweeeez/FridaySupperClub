using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player");
        Debug.Log("hit!");
    }
}
