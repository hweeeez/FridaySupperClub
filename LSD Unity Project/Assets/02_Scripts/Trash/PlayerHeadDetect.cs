using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadDetect : MonoBehaviour
{
    GameObject parentGameObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        //var parentGameObject = this.transform.parent.gameObject;
        if (collision.gameObject.tag == "Head")
        {
            parentGameObject = collision.transform.parent.gameObject;
            Debug.Log("hit!");
            parentGameObject.SetActive(false);
        }
    }
}
